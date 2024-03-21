using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    const float walkingSpeed = 5;
    const float runningSpeed = 7;

    public float MoveSpeed;
    public float jumpForce = 5;
    public bool grounded = false;

    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        //define rigidbody
        rb = transform.GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //run if holding down shift
        if(Input.GetKey("left shift")){
            MoveSpeed = runningSpeed;
        } 
        else 
        {
            MoveSpeed = walkingSpeed;
        }

        //player jump
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector3(0, jumpForce, 0);
        }

        //if press esc then show cursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Confined;
        }

        transform.Translate((Input.GetAxisRaw("Horizontal") * MoveSpeed * Time.deltaTime), 0, (Input.GetAxisRaw("Vertical") * MoveSpeed * Time.deltaTime));
        
        //rotate player leftright with mouse input
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 360 * Time.deltaTime);
    }


    //ground collision checks

    private void OnCollisionEnter(Collision collision)
    {
        //if collided with ground or checkpoint and not falling then grounded is true
        //else is false
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Checkpoint")
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //set grounded to false since you are not touching anything
        grounded = false;
    }
}
