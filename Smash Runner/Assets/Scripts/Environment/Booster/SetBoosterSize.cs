using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBoosterSize : MonoBehaviour
{
    private Vector3 boosterSize;
    private GameManager manager;
    private int followerCount;

    private void Awake()
    {
        manager=FindObjectOfType<GameManager>();
    }
    private void Start()
    {
        followerCount=manager.followerList.Count-1;
        boosterSize = new Vector3(0.5f, 0.5f, 05f);
    }

    private void Update()
    {
        SetSize();   
    }
    private void SetSize()
    {
        for (int i = 0; i < followerCount; i++)
        {
            Vector3 newBoosterSize = boosterSize + new Vector3(i * 0.1f, i * 0.1f, i * 0.1f);
        }
    }

}
