using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        // set the offset of the camera based on the players position
        offset = transform.position - player.transform.position;
    }

   
    void LateUpdate()
    {
        // Make the transform possion of the camera follow the players transform posstion
        transform.position = player.transform.position + offset;
    }
}
