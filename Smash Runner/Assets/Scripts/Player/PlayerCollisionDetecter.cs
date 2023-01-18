using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetecter : MonoBehaviour
{ 
    public bool isHitWall;
    public bool isPlayerTriggered=false;
    public GameObject triggeredBooster;
    PlayerController controller;

    private void Awake()
    {
        controller= GetComponent<PlayerController>();
    }
    private void LateUpdate()
    {
        if (isPlayerTriggered)
        {
            isPlayerTriggered= false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Booster"))
        {
            isPlayerTriggered= true;
            triggeredBooster = other.gameObject;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            controller.isGrounded = true;

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Invoke("SetGroundedFalse", 0.5f);
        }
    }

    void SetGroundedFalse()
    {
        controller.isGrounded = false;
    }
}
