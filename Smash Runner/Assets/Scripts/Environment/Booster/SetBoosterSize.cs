using UnityEngine;

public class SetBoosterSize : MonoBehaviour
{
    private Booster booster;
    private GameManager manager;
    private PlayerCollisionDetecter playerCollisionDetecter;
    private GameObject player, ground;

    private Vector3 boosterSize;

    private void Awake()
    {
        booster = GetComponent<Booster>();
        player = FindObjectOfType<PlayerController>().gameObject;
        ground = GameObject.Find("Ground");
        manager = FindObjectOfType<GameManager>();
        playerCollisionDetecter = FindObjectOfType<PlayerCollisionDetecter>();
    }

    private void Update()
    {
        SetSize();
    }
    private void SetSize()
    {

        if (!booster.following)
        {
            boosterSize = player.GetComponent<BoxCollider>().size / 2;

            if (playerCollisionDetecter.isPlayerTriggered)
            {
                transform.position = new Vector3(transform.position.x,
                    transform.position.y+manager.followerCount*0.0028f,
                    transform.position.z);
            }
        }
        else
        {
            boosterSize = new Vector3(1.05f, 1.05f, 1f);
        }
        this.gameObject.transform.localScale = boosterSize;
    }

}
