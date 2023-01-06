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
        lastTarget = player.gameObject;
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
            Debug.Log(lastTarget.name);
            triggered = false;
        }
        if (following)
            transform.localPosition = Vector3.zero;
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
