using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private Rigidbody2D playerBody;
    [SerializeField] private Transform gooBallPosition;
    [SerializeField] private Transform goo;



    private bool hasJumped;
    private bool isGrounded;
    private bool hasFired;
    private float currentTime;
    private Vector3 moveDir;

    private string GROUND_TAG = "Ground";


    private bool isWalkingLeft;
    private bool isWalkingRight;
    private bool lastDirectionRight;

    private void Awake()
    { 

    }

    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVector();
        moveDir = new Vector3(inputVector.x, 0f, 0f);

        if (moveDir.x < 0)
        {
            isWalkingLeft = true;
            isWalkingRight = false;
            lastDirectionRight = false;
        }
        else if (moveDir.x > 0)
        {
            isWalkingRight = true;
            isWalkingLeft = false;
            lastDirectionRight = true;
        }
        else
        {
            isWalkingLeft = false;
            isWalkingRight = false;
        }

            transform.position += moveDir * Time.deltaTime * moveSpeed;

        if (gameInput.GetJump() && isGrounded)
        {
            hasJumped = true;
            isGrounded = false;
        }

        PlayerFireProjectile();


    }

    private void FixedUpdate()
    {
        
        if (hasJumped)
        {
            playerBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            playerBody.gravityScale = 3f;
            hasJumped = false;
        }

        if (playerBody.linearVelocityY <= 0)
        {
            playerBody.gravityScale = 4.5f;
        }
    }

    public bool IsWalkingLeft()
    {
        return isWalkingLeft;
    }

    public bool IsWalkingRight()
    {
        return isWalkingRight;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
            isGrounded = true;
    }

    private void PlayerFireProjectile()
    {
        


        if (gameInput.IsFire() && !hasFired)
        {

            if(lastDirectionRight)
            {
                Instantiate(goo, gooBallPosition.position, gooBallPosition.rotation);
            }
            else
            {
                Instantiate(goo, gooBallPosition.position, Quaternion.Euler(0, 180, 0));
            }

                hasFired = true;
            currentTime = Time.time;

        }
        else if (Time.time - currentTime > 0.75f)
        {
            hasFired = false;
        }
            

    }

    public bool HasJumped()
    {
        return hasJumped;
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }

}
