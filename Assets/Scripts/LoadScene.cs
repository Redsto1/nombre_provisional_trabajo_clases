using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField]
    public string destinationScene;

    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(destinationScene);
    }
}
