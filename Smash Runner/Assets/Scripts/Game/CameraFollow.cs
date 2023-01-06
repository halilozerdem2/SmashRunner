using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    PlayerController player;

    private void Awake()
    {
        player=FindObjectOfType<PlayerController>();
    }
    private void LateUpdate()
    {
        this.transform.position = player.GetPlayerPosition() + new Vector3(0,7,-10);
        
    }
    private void Update()
    {
    }
}
