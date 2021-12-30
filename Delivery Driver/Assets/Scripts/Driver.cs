using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float movespeed;
    [SerializeField] float steerspeed;
    [SerializeField] float slowspeed;
    [SerializeField] float fastspeed;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "pick")
        {
            movespeed =  fastspeed;
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "slowdown")
        {
            movespeed = slowspeed;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //old movement 
        /*  if (Input.GetKey(KeyCode.A))
          {
              transform.Rotate(0, 0, steerspeed);
          }
          if(Input.GetKey(KeyCode.D))
          {
              transform.Rotate(0, 0, -steerspeed);
          }
          if (Input.GetKey(KeyCode.W))
          {
              transform.Translate(0, movespeed, 0);
          }
          if (Input.GetKey(KeyCode.S))
          {
              transform.Translate(0, -movespeed, 0);
          }
        */


        //new method to move
        float steerAmt = Input.GetAxis("Horizontal") * steerspeed * Time.deltaTime;
        float moveAmt = Input.GetAxis("Vertical") * movespeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmt);
        transform.Translate(0, moveAmt, 0);
       
    }
}
