using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetecter : MonoBehaviour
{ 
    public bool isHitWall;
    public bool isPlayerTriggered=false;
    public GameObject triggeredBooster;

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
}
