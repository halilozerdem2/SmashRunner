using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayerCollisionDetecter collisionDetecter;
    public GameObject lastFollower;

    public List<GameObject> followerList; 

    private bool oneTime = false;

    private void Awake()
    {
        followerList = Chain.Singleton_Game_Obje_Zinciri_Dondur();
        collisionDetecter = FindObjectOfType<PlayerCollisionDetecter>();
    }
    private void Start()
    {
        followerList.Add(collisionDetecter.gameObject);
        //lastFollower = collisionDetecter.gameObject;
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
            Debug.Log(followerList.Count);
        }
        lastFollower = followerList[followerList.Count-1];

        //collisionDetecter.isPlayerTriggered = false;
    }
}
