using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class Wall : MonoBehaviour
{
    public PlayerController player;
    public Booster booster;

    [SerializeField] private bool canMove = false;
    [SerializeField] private float movingSpeed = 6f;

    public bool isHit=false;

    private Vector3 leftBoundry;
    private Vector3 rightBoundry;

    private Rigidbody rb;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        booster=FindObjectOfType<Booster>();
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        rightBoundry = transform.position;
        leftBoundry = new Vector3(-rightBoundry.x, rightBoundry.y, rightBoundry.z);
    }
    private void Update()
    {
        if(isHit)
        {
            Destroy(this.gameObject);
        }
    }
    private void LateUpdate()
    {
        if (canMove)
        {
            if (Mathf.Abs(player.GetPlayerPosition().z - transform.position.z) < 100f)
            {
                if (transform.position == rightBoundry)
                    MoveLeft();
                else if (transform.position == leftBoundry)
                    MoveRight();
            }
        }

    }

    private void MoveLeft()
    {
        rb.velocity = Vector3.left * movingSpeed;
    }

    private void MoveRight()
    {
        rb.velocity = Vector3.right * movingSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isHit = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isHit = false;
        }
    }

}
