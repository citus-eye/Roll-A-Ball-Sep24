using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 1.0f;
    private Rigidbody rb;
    private int pickupCount;

    void Start()
    {
        //Gets the Rigibody component attached to this game object 
        rb = GetComponent<Rigidbody>();
        //gets the number of pickups in our scene
        pickupCount = GameObject.FindGameObjectsWithTag("Pickup").Length;
        // run the check pick ups function
        CheckPickups();
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Pickup")
        {
            //destroy the collided object
            Destroy(other.gameObject);
            //decoment the pick up count
            pickupCount--;
            // run the check pickup function again
            CheckPickups();
        }
    }

    private void CheckPickups()
    {
        print("pickups left: " + pickupCount);
        if(pickupCount == 0)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        print("You are Victorious");
    }
}
