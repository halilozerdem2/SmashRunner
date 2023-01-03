using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Touch touch;
    private float speedModifier;
    private Rigidbody playerRb;
    private Vector3 playerPos;

    private void Awake()
    {
        playerRb= GetComponent<Rigidbody>();    
    }

    private void Start()
    {
        speedModifier= 0.01f;
    }
    private void FixedUpdate()
    {
        MoveForward();
        playerPos= transform.position;

        if (Input.touchCount > 0)
            ControlCharacter();
        
    }
    private void Update()
    {
    }
    private void ControlCharacter()
    {
        touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Moved)
        {
            transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * 
                                            speedModifier,
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
