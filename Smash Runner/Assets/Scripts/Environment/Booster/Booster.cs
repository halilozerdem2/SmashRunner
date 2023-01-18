using Newtonsoft.Json.Converters;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEditor.UI;
using UnityEngine;

public class Booster : MonoBehaviour
{
    private Vector3 boosterPosition;
    private PlayerController player;
    public GameObject lastTarget;
    public BoxCollider boosterCollider;

    private GameManager gameManager;

    public bool triggered=false;
    private bool following = false;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        boosterCollider = GetComponent<BoxCollider>();
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Start()
    {
        boosterPosition = this.transform.position;
    }
    private void Update()
    {
        lastTarget = gameManager.lastFollower;
    }
    private void LateUpdate()
    {
        if (triggered)
        {
            transform.SetParent(lastTarget.transform);
            triggered = false;
        }
        if (following && !player.isMovingInZAxis)
        {
            transform.localPosition = Vector3.zero;
            transform.LookAt(player.gameObject.transform);
        }
        else if(following && player.isMovingInZAxis)
        {
            transform.localPosition = new Vector3(0, 0, -0.3f);
            transform.LookAt(player.gameObject.transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggered = true;
            following = true;
        }
    }
}
