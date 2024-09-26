using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    public float speed = 1.0f;
    private Rigidbody rb;

    void Start()
    {
        //Gets the Rigibody component attached to this game object 
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //store the horizontal axis vaule in a float 
        float moveHorizontal = Input.GetAxis("Horizontal");
        //store the vertical axis value in a float
        float moveVertical = Input.GetAxis("Vertical");

        //create a new vertor3 based on the horizontal and vertical values
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        //add force to our rigibody from our movement vector times speed veriable
        rb.AddForce(movement * speed * Time.deltaTime);

        
    }
}
