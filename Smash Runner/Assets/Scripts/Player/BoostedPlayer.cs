using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostedPlayer : MonoBehaviour
{
    private BoxCollider playerCollider, boosterCollider;
    private PlayerCollisionDetecter collisionDetecter;

    private void Awake()
    {
        playerCollider = GetComponent<BoxCollider>();
        collisionDetecter=FindObjectOfType<PlayerCollisionDetecter>();
    }

    private void Update()
    {
        if (collisionDetecter.isPlayerTriggered)
        {
            playerCollider.size =new Vector3(playerCollider.size.x+0.115f, playerCollider.size.y + 0.115f, playerCollider.size.z+0.115f);
        }

    }
}
