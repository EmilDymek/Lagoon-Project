using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 startPos;                                               //Variable for position before tracking
    private Vector3 targetPos;                                              //Variable for target position
    public Transform playerTarget;                                          //Gameobject (Put the player object in here)
    public Transform crosshairTarget;
    public float followSpeed;
    
    void Awake()
    {
        startPos = transform.position;                                      //Stores the starting position
    }


    void FixedUpdate()
    {
        //targetPos = playerTarget.position + (crosshairTarget.position - playerTarget.position) / 2;
        //transform.position = targetPos;

        targetPos = new Vector3(playerTarget.position.x, playerTarget.position.y, transform.position.z);                    //Updates target position to the FollowTarget's position
        Vector3 cameraVelocity = (targetPos - transform.position) * followSpeed;                                            //Stores the distance between the current possition and the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref cameraVelocity, 1.0f, Time.deltaTime);   //Moves the Camera to the target position using Smoothdamp function

    }
}
