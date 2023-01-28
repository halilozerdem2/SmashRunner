using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetecter : MonoBehaviour
{
    private PlayerController controller;
    private DamageDealer damageDealer;
    public GameObject triggeredBooster;

    public bool isDamaged;
    public bool isGameOver;
    public bool isPlayerTriggered = false;

    public int boosterCounter;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        damageDealer= GetComponent<DamageDealer>();
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            controller.isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Ground2"))
        {
            isGameOver = true;
        }
        if (collision.gameObject.CompareTag("Booster"))
        {
            boosterCounter++;
            isPlayerTriggered = true;
            triggeredBooster = collision.gameObject;
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            damageDealer.Damaged();
        }

    }
}
