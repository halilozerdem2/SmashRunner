using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Touch touch;
    private Vector3 playerPos;

    public bool isGrounded;
    public bool isMovingInYAxis;

    [SerializeField] private float directingSpeed=0.5f;
    [SerializeField] private float movingSpeed = 15f;
    [SerializeField] private float threshold = 0.2f;

    private void Awake()
    {
        playerRb=GetComponent<Rigidbody>();    
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
        
        if(Mathf.Abs(playerRb.velocity.y)>threshold)
        {
            isMovingInYAxis= true;
        }
        else
        {
            isMovingInYAxis = false;
        }
    }

    private void ControlCharacter()
    {
        touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Moved)
        {
           transform.position = new Vector3(transform.position.x + touch.deltaPosition.x *
                                            directingSpeed * Time.deltaTime,
                                            transform.position.y, transform.position.z);
        }
    }
    private void MoveForward()
    {
        transform.position += new Vector3(0,0, movingSpeed * Time.deltaTime);
    }
    public Vector3 GetPlayerPosition()
    {
        return playerPos;
    }


}
