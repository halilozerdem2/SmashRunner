using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private Vector3 leftBoundry;
    private Vector3 rightBoundry;
    private Vector3 currentPosition;

    public PlayerController player;
    private Rigidbody rb;

    [SerializeField] float movingSpeed=6f;

    private void Awake()
    {
        player=FindObjectOfType<PlayerController>();
        rb=GetComponent<Rigidbody>();
    }
    private void Start()
    {
        rightBoundry = transform.position;
        leftBoundry = new Vector3(-rightBoundry.x, rightBoundry.y, rightBoundry.z);   
    }
   
    private void LateUpdate()
    {
        currentPosition = transform.position;
        if(Mathf.Abs(player.GetPlayerPosition().z - currentPosition.z) < 100f)
        {
            if (currentPosition == rightBoundry)
                MoveLeft();
            else if (currentPosition == leftBoundry)
                MoveRight();
        }
    }

    private void MoveLeft()
    {
        rb.velocity=Vector3.left*movingSpeed;
    }

    private void MoveRight()
    {
        rb.velocity= Vector3.right * movingSpeed;
    }
}
