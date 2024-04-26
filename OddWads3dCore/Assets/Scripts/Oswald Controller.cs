using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OswaldController : MonoBehaviour
{
    public float WalkSpeed = 5f;
    public float JumpForce = 10f;
    bool somersault = false;
    bool somersaultKick = false;
    bool IsOnGround = true;
    public Rigidbody Rb;
    public float health = 5;
    bool Invincible = false;
    float invinvibleTimer = 2f;
    public bool GameOver = false;


    // change all key codes into the thing that universal for unity  i foget what its called.
    void Start()
    {
        // lets me use my rigigf body in the script
        Rb = GetComponent<Rigidbody>();
        WalkSpeed = WalkSpeed * 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != transform.position)
        { }
        //if you press spacebar you can jump
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround == true)
        {
            Rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            IsOnGround = false;
        }
       //movement code
        if (Input.GetKey(KeyCode.A))
        {
            Rb.AddForce(Vector3.left * Time.deltaTime * WalkSpeed, ForceMode.Force);
        }
       
        if (Input.GetKey(KeyCode.D))
        {
            Rb.AddForce(Vector3.right * Time.deltaTime * WalkSpeed, ForceMode.Force);
        }
    
       

        if (Invincible == true)
        {
            invinvibleTimer -= Time.deltaTime;
            if (invinvibleTimer < 0)
            {
                Invincible = false;
                invinvibleTimer = 2;

            }
        }
        if (health < 1)
        {

            GameOver = true;

        }

        if (GameOver == true)
        {
            Debug.Log("game over");
            Rb.AddForce(Vector3.up * 200, ForceMode.Impulse);
            Rb.AddForce(Vector3.left * 200, ForceMode.Impulse);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
        }

        if (collision.gameObject.CompareTag("Enemy") && Invincible == false)
        {
            health -= 1f;
            Debug.Log("healt is " + health);
            Invincible = true;
        }

        if (collision.gameObject.CompareTag("Death"))
        {
            GameOver = true;
        }
    }
}
