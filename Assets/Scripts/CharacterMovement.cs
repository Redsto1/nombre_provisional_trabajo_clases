using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float speed = 50;

   

    // Start is called before the first frame update
    void Start()
    {
        rb.maxLinearVelocity = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 control_axis = new Vector2();
        if (Input.GetKey(KeyCode.A))
        {
            control_axis.x = -1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            control_axis.y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            control_axis.y = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            control_axis.x = 1;
        }
        rb.AddForce(new Vector3((control_axis.x * speed) / Time.deltaTime,0,(control_axis.y * speed)) / Time.deltaTime);
    }
}
