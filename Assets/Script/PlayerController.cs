using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public VariableJoystick joystick;
    private Rigidbody playerRigidbody;
    public float speed = 8f;
    public float jumpForce = 5f;



    private bool isGrounded = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //float xInput = Input.GetAxis("Horizontal");
        //float zInput = Input.GetAxis("Vertical");

        float xInput = joystick.Horizontal;
        float zInput = joystick.Vertical;

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;


        if(xInput != 0 || zInput !=0) // 이동 방향이 존재할 때만 회전 처리리
        {
            Vector3 moveDirection = new Vector3(xInput, 0f, zInput).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }


        Vector3 newVelocity = new Vector3(xSpeed, playerRigidbody.linearVelocity.y, zSpeed);

        playerRigidbody.linearVelocity = newVelocity;

        //if(isGrounded /*&& Input.GetButtonDown("Jump")*/)
        //{
          //  playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
          //  isGrounded = false;
        //}

    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Goal"))
        {
            GameManager gameManager = FindFirstObjectByType<GameManager>();
            gameManager.GameClear();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindFirstObjectByType<GameManager>();
        gameManager.EndGame();
    }
}
