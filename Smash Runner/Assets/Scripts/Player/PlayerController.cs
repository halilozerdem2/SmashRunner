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

    [SerializeField] private float directingSpeed = 0.3f;
    [SerializeField] private float movingSpeed = 15f;
    [SerializeField] private float threshold = 0.1f;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        playerPos = transform.position;

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

        if (Mathf.Abs(playerRb.velocity.y) > threshold)
        {
            isMovingInYAxis = true;
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
            Vector3 movement = new Vector3(touch.deltaPosition.x * directingSpeed * Time.deltaTime, 0, 0);
            playerRb.MovePosition(playerRb.position + movement);
        }

    }
    private void MoveForward()
    {
        Vector3 movement = new Vector3(0, 0, movingSpeed * Time.deltaTime);
        playerRb.MovePosition(transform.position + movement);
    }
    public Vector3 GetPlayerPosition()
    {
        return playerPos;
    }


}
