using UnityEngine;

public class Booster : MonoBehaviour
{
    private PlayerController player;
    private GameManager gameManager;

    public GameObject lastTarget;
    public BoxCollider boosterCollider;

    public bool triggered = false;
    public bool following = false;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        boosterCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        lastTarget = gameManager.lastFollower;
    }

    private void LateUpdate()
    {
        if (triggered)
        {
            transform.SetParent(lastTarget.transform);
            transform.localScale =new Vector3(1.02f, 1.02f, 1f);
            triggered = false;
            
        }
        if (following)
        {
            if (!player.isMovingInYAxis)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, 10f * Time.deltaTime);
                transform.localRotation = Quaternion.identity;
            }
            else
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 0f, -0.4f), 10f * Time.deltaTime);
                transform.LookAt(player.gameObject.transform);
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            triggered= true;
            following = true;
            this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }   
    }
}
