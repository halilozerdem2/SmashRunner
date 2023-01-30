using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetecter : MonoBehaviour
{
    private PlayerController controller;
    public GameObject triggeredBooster;

    public bool isDamaged;
    public bool isStageOver;
    public bool isPlayerTriggered = false;

    public int boosterCounter;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }
    private void Start()
    {
        triggeredBooster = this.gameObject;

    }
    private void LateUpdate()
    {
        if (isPlayerTriggered)
        {
            isPlayerTriggered = false;
        }
        if(isDamaged) 
        {
            isDamaged = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            controller.isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Ground2"))
        {
            isStageOver = true;
        }
        if (collision.gameObject.CompareTag("Booster"))
        {
            boosterCounter++;
            isPlayerTriggered = true;
            triggeredBooster = collision.gameObject;
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            isDamaged=true;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground2"))
        {
            isStageOver = false;
        }
    }
}
