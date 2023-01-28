using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    private PlayerCollisionDetecter collisionDetecter;
    private Wall wall;
    public GameObject lastFollower;

    public List<GameObject> followerList;
    public TextMeshPro counterText;
    public int followerCount;

    private void Awake()
    {
        followerList = new List<GameObject>();
        collisionDetecter = FindObjectOfType<PlayerCollisionDetecter>();
        wall = FindObjectOfType<Wall>();
    }
    private void Start()
    {
        followerList.Add(collisionDetecter.gameObject);
        lastFollower = collisionDetecter.gameObject;
    }
    private void Update()
    {
        followerCount = followerList.Count;
        counterText.text = (followerCount - 1).ToString();
        AssignLastFollower();
    }

    private void AssignLastFollower()
    {
        if (collisionDetecter.isPlayerTriggered)
        {
            followerList.Add(collisionDetecter.triggeredBooster);
        }
        lastFollower = followerList[followerList.Count - 1];
    }
}
