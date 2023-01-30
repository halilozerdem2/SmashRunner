using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
        followerList.Add(collisionDetecter.gameObject);
        lastFollower = collisionDetecter.gameObject;
    }
    private void Update()
    {

        followerCount = followerList.Count;
        counterText.text = (followerCount - 1).ToString();
        AssignLastFollower();
        GameOver();
    }

    private void GameOver()
    {
        if (followerCount==1 && collisionDetecter.isDamaged)
        {
            isGameOver = true;
        }
        else
        {
            isGameOver = false;
        }

        if(isGameOver)
        {
            LoadTheScene("GameOver");
        }
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
        if(SceneManager.GetActiveScene().name!=aSceneName)
        {
            SceneManager.LoadScene(aSceneName);
        }
    }
}
