using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayerCollisionDetecter collisionDetecter;
    public GameObject lastFollower;

    public List<GameObject> followerList; 

    private void Awake()
    {
        followerList = new List<GameObject>();
        collisionDetecter = FindObjectOfType<PlayerCollisionDetecter>();
    }
    private void Start()
    {
        followerList.Add(collisionDetecter.gameObject);
        lastFollower =collisionDetecter.gameObject;
    }
    private void Update()
    {
        AssignLastFollower();

    }
    private void AssignLastFollower()
    {
        if (collisionDetecter.isPlayerTriggered)
        {
            followerList.Add(collisionDetecter.triggeredBooster);
        }
        lastFollower = followerList[followerList.Count-1];
    }
}
