using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{
    bool directionleft;
    public float Speed = 5f;
    public Rigidbody2D Rb;
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (directionleft == true)
        {
            Rb.AddForce(Vector3.left * Speed , ForceMode2D.Force);
        }
        if (directionleft == false) 
        {
            Rb.AddForce(Vector3.right * Speed , ForceMode2D.Force);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
          if (directionleft == true ) { directionleft = false; }
          else if (directionleft == false ) {  directionleft = true; }
        }
    }
}
