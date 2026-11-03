using UnityEngine;

public class DeathTriggerer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var movement = other.gameObject.GetComponent<CharacterMovement>();
            if (movement == null)
            {
                return;
            }
            movement.Death();
        }
    }
}
