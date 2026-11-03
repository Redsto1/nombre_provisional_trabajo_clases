using UnityEngine;

public class WallCollisionDetector : MonoBehaviour
{
    float redening = 0f;
    Color originalColor;

    private void Start()
    {
        originalColor = gameObject.GetComponent<Renderer>().material.color;
    }
    private void Update()
    {
        redening -= Time.deltaTime;
        if (redening > 0f)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(originalColor.r + redening,originalColor.g,originalColor.b,originalColor.a);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            redening = 2.5f;
        }
    }
}
