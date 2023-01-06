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
    private GameObject lastFollower;
    public BoxCollider boosterCollider;

    public bool triggered=false;
    private bool following = false;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        boosterCollider = GetComponent<BoxCollider>();
    }
    private void Start()
    {
        boosterPosition = this.transform.position;
        lastFollower = player.gameObject;
    }

    private void LateUpdate()
    {
        if (triggered)
        {
            //Debug.Log("a");
            transform.SetParent(player.gameObject.transform);
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
