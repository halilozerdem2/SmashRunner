using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Touch touch;
    private Rigidbody playerRb;
    public bool isGrounded;
    private float directingSpeedModifier;
    private float threshold = 0.2f;
    public bool isMovingInZAxis;
    private Vector3 playerPos;

    private void Awake()
    {
        playerRb=GetComponent<Rigidbody>();    
    }
    private void Start()
    {
        directingSpeedModifier = 0.5f;
    }
    private void FixedUpdate()
    {
        playerPos= transform.position;
        
        MoveForward();
        
        if (Input.touchCount > 0)
        {
            ControlCharacter();

        }
        SetBoolMovingZAxis();
    }

    private void SetBoolMovingZAxis()
    {
        float zAxisValue = playerRb.velocity.z;
        
        if(Mathf.Abs(playerRb.velocity.z)>threshold)
        {
            isMovingInZAxis= true;
        }
        else
        {
            isMovingInZAxis = false;
        }
    }

    private void ControlCharacter()
    {
        touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Moved)
        {
           transform.position = new Vector3(transform.position.x + touch.deltaPosition.x *
                                            directingSpeedModifier * Time.deltaTime,
                                            transform.position.y, transform.position.z);
        }
    }
    private void MoveForward()
    {
        transform.position += new Vector3(0,0,15f*Time.deltaTime);
    }
    public Vector3 GetPlayerPosition()
    {
        return playerPos;
    }


}
