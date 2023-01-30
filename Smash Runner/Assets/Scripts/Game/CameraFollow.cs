using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    PlayerController player;
    PlayerCollisionDetecter detecter;
    [SerializeField] Camera mainCam;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        detecter= FindObjectOfType<PlayerCollisionDetecter>();
    }
    private void Start()
    {
    }
    private void LateUpdate()
    {
        if (!detecter.isStageOver)
        {
            this.transform.position = player.GetPlayerPosition() + new Vector3(0, 5f, -5f);

        }
        else
        {
            this.transform.position = Vector3.Lerp(transform.position,player.GetPlayerPosition()+ new Vector3(0, 15f, -11f), 4f*Time.deltaTime);
            mainCam.fieldOfView = 45f;
        }

    }
    private void Update()
    {
    }
}
