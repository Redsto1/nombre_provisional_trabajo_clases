using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
public class CharacterMovement : MonoBehaviour {

    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private Rigidbody rigidBody;

    [SerializeField]
    private Animator playerAnimator;

    public float playerSpeed = 50;

    [SerializeField]
    Vector2 control_axis = new Vector2();

    [SerializeField]
    bool allow_movement = true;

    private void Start()
    {
        rigidBody.maxLinearVelocity = 5;
    }

    private void FixedUpdate()
    {
        if (allow_movement)
        {
            rigidBody.AddForce(new Vector3((control_axis.x * playerSpeed), 0, (control_axis.y * playerSpeed)));
        }
    }

    public void Movement(InputAction.CallbackContext context)
    {
        control_axis = context.ReadValue<Vector2>();
    }

    public void Death()
    {
        allow_movement = false;
        playerAnimator.SetTrigger("death");
    }

    public void Respawn()
    {
        playerAnimator.SetTrigger("respawn");
        allow_movement = true;
        transform.position = gameManager.respawn_position.position;
    }
    
    
}
