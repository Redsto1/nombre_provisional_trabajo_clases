using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    public float speed = 50;

    [SerializeField]
    private PlayerInput input;
    [SerializeField]
    Vector2 control_axis = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        rb.maxLinearVelocity = 5;
    }
    
    
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(new Vector3((control_axis.x * speed) * Time.deltaTime,0,(control_axis.y * speed) * Time.deltaTime));
        Debug.Log(new Vector3((control_axis.x * speed) * Time.deltaTime, 0, (control_axis.y * speed) * Time.deltaTime));
    }

    public void Movement(InputAction.CallbackContext context)
    {
        control_axis = context.ReadValue<Vector2>();
    }

    public void respawn()
    {

    }
}
