using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed = 1.0f;
    private Rigidbody rb;
    private int pickupCount;
    private int totalPickups;
    private float pickupChunk;
    private Timer timer;
    private bool gameOver = false;

    [Header("UI")]
    public GameObject inGamePanel;
    public TMP_Text pickupText;
    public TMP_Text timerText;
    public Image pickupImage;
    public GameObject winPanel;
    public TMP_Text winTimeText;

    void Start()
    {
        //Gets the Rigibody component attached to this game object 
        rb = GetComponent<Rigidbody>();
        //gets the number of pickups in our scene
        pickupCount = GameObject.FindGameObjectsWithTag("Pickup").Length;
        //asign the total amount of pickups
        totalPickups = pickupCount;
        //set the pick up image amount to 0
        pickupImage.fillAmount = 0;
        //work out the pickup chunkfill ab=mount
        pickupChunk = 1.0f / totalPickups;
        // run the check pick ups function
        CheckPickups();
        // gets the timer object
        timer = FindObjectOfType<Timer>();
        //starts the timer object
        timer.StartTimer();

        //turn on ingame panel
        inGamePanel.SetActive(true);

        //when game starts we turn off the panel
        winPanel.SetActive(false);
    }

    private void Update()
    {
        timerText.text = "Time: " + timer.currentTime.ToString("F2");
    }

    void FixedUpdate()
    {
        if (gameOver == true)
            return;

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
            //increase the fill amount of our pickup image
            pickupImage.fillAmount = pickupImage.fillAmount + pickupChunk;
            // run the check pickup function again
            CheckPickups();
        }
    }

    private void CheckPickups()
    {
       
        //do text stuff
        print("Pickups Left: " + pickupCount);
        pickupText.text = "Pickups Left: " + pickupCount.ToString();
        if (pickupCount == 0)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        //set our game over to be true
        gameOver = true;
        //stop the timer
        timer.StopTimer();


        print("You Are Victorious. Your time was: " + timer.GetTime(). ToString("F2"));

        //display the final time on the win panel
        winTimeText.text = "Your time was: " + timer.GetTime(). ToString("F2");

        //turn on the panel
        winPanel.SetActive(true);

        //turn off in game panel
        inGamePanel.SetActive(false);

        //stop the ball from running
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    //temporary restart function
    public void ResetGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

}
