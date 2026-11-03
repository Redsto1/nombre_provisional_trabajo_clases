using UnityEngine;

public class movement_wall : MonoBehaviour
{
    [SerializeField]
    float rotation_speed = 0.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,1,0), rotation_speed);
    }

    
}
