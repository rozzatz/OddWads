using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OswaldController : MonoBehaviour
{
    public float WalkSpeed = 5f;
    public float JumpForce = 10f;
    bool somersault = false;
    bool somersaultKick = false;
    bool LeftKeyPressed = false;
    bool RightKeyPressed = false;
    bool IsOnGround = true;
    public Rigidbody2D Rb;

    // change all key codes into the thing that universal for unity  i foget what its called.
    void Start()
    {
        // lets me use my rigigf body in the script
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if you press spacebar you can jump
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround == true)
        {
            Rb.AddForce(Vector3.up * JumpForce , ForceMode2D.Impulse);
            IsOnGround = false;
        }
        // detecting wether the left key is pressed so i can add continuious movement
        if (Input.GetKeyDown(KeyCode.A))
        {
            LeftKeyPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {  
            LeftKeyPressed = false;
        }
        //same thing for right key
        if (Input.GetKeyDown(KeyCode.D))
        {
            RightKeyPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            RightKeyPressed = false;
        }
        //movement scripts
        if (LeftKeyPressed == true)
        {
            Rb.AddForce(Vector3.left * WalkSpeed  , ForceMode2D.Force);
        }

        if (RightKeyPressed == true)
        { Rb.AddForce(Vector3.right * WalkSpeed , ForceMode2D.Force); }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
        }
    }
}
