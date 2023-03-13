using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.Xml.Serialization;

public class GameManager : MonoBehaviour
{
    private PlayerCollisionDetecter collisionDetecter;
    public GameObject lastFollower;

    public List<GameObject> followerList;
    public TextMeshPro counterText;
    public int followerCount;
    public bool isGameOver;

    private void Awake()
    {
        followerList = new List<GameObject>();
        collisionDetecter = FindObjectOfType<PlayerCollisionDetecter>();
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        followerList.Add(collisionDetecter.gameObject);
        lastFollower = collisionDetecter.gameObject;
    }
    private void Update()
    {
        if (collisionDetecter != null)
        {
            followerCount = followerList.Count;
            counterText.text = (followerCount - 1).ToString();
            AssignLastFollower();
            
            if(followerCount==1 && collisionDetecter.isDamaged)
            {
                isGameOver= true;
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        followerList.Clear();
        //followerList.Add(collisionDetecter.gameObject);
        lastFollower= null;
        counterText.text = null;
        LoadTheScene("GameOver");
        isGameOver=false;

    }

    private void AssignLastFollower()
    {
        if (collisionDetecter.isPlayerTriggered)
        {
            followerList.Add(collisionDetecter.triggeredBooster);
        }
        lastFollower = followerList[followerList.Count - 1];
    }


    private void LoadTheScene(string aSceneName)
    {
        if (SceneManager.GetActiveScene().name != aSceneName)
        {
            SceneManager.LoadScene(aSceneName);
        }
    }
}
