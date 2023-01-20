using Newtonsoft.Json.Converters;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Networking.PlayerConnection;
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
            transform.localScale =new Vector3(1.05f, 1.05f, 1f);
            triggered = false;
        }
        if(following)
        {
            transform.localRotation = Quaternion.identity;
            
            if(!player.isMovingInZAxis)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition,Vector3.zero,10f*Time.deltaTime);
            }
            else
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition,new Vector3(0, 0f,-0.4f), 10f*Time.deltaTime);
            }
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
