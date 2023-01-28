using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    GameManager manager;
    PlayerCollisionDetecter detecter;

    private void Awake()
    {
        detecter = GetComponent<PlayerCollisionDetecter>();
        manager = FindObjectOfType<GameManager>();
    }


    public void Damaged()
    {
        if (manager.followerCount > 1)
        {
            GameObject followerToRemove = manager.followerList[manager.followerList.Count - 1];
            if (followerToRemove != null)
            {
                Destroy(followerToRemove);
                manager.followerList.RemoveAt(manager.followerList.Count - 1);
            }
        }
        else if (manager.followerCount == 1)
        {
            GameObject followerToRemove = manager.followerList[manager.followerList.Count - 1];
            if (followerToRemove != null)
            {
                Destroy(followerToRemove);
                manager.followerList.RemoveAt(manager.followerList.Count - 1);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
