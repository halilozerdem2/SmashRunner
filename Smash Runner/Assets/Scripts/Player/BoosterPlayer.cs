using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterPlayer : MonoBehaviour
{
    private BoxCollider playerCollider, boosterCollider;
    private Booster booster;

    private void Awake()
    {
        playerCollider= GetComponent<BoxCollider>();
        booster= FindObjectOfType<Booster>();
        boosterCollider = booster.GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if(booster.triggered)
        {
            playerCollider.size = new Vector3(playerCollider.size.x, playerCollider.size.y+0.7f, playerCollider.size.z+0.7f) ;
        }
        
    }
}
