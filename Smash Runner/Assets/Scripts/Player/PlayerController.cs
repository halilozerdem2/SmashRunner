using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private PlayerCollisionDetecter detecter;

    private Touch touch;
    private Vector3 playerPos;

    public bool isGrounded;
    public bool isMovingInYAxis;

    [SerializeField] private float directingSpeed = 0.3f;
    [SerializeField] private float movingSpeed = 15f;
    [SerializeField] private float threshold = 0.3f;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        detecter = GetComponent<PlayerCollisionDetecter>();
    }

    private void FixedUpdate()
    {
        playerPos = transform.position;

        if (!detecter.isStageOver)
        {
            MoveForward();
        }
        else
        {

        }

        if (Input.touchCount > 0)
        {
            ControlCharacter();

        }
        SetBoolMovingZAxis();
    }

    private void SetBoolMovingZAxis()
    {
        float zAxisValue = playerRb.velocity.z;

        if (Mathf.Abs(playerRb.velocity.y) > threshold)
        {
            isMovingInYAxis = true;
        }
        else
        {
            isMovingInYAxis = false;
        }
    }

    private void ControlCharacter()
    {
        touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Moved)
        {
            Vector3 movement = new Vector3(touch.deltaPosition.x * directingSpeed * Time.deltaTime, 0, 0);
            playerRb.MovePosition(playerRb.position + movement);
        }

    }
    private void MoveForward()
    {
        Vector3 movement = new Vector3(0, 0, movingSpeed * Time.deltaTime);
        playerRb.MovePosition(transform.position + movement);
    }

    public Vector3 GetPlayerPosition()
    {
        return playerPos;
    }



}
