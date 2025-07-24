using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private Rigidbody2D playerBody;
    [SerializeField] private Transform gooBallPosition;
    [SerializeField] private Transform goo;



    private bool hasJumped;
    private bool isGrounded;
    private bool hasFired;

    private string GROUND_TAG = "Ground";


    private bool isWalkingLeft;
    private bool isWalkingRight;

    private void Awake()
    { 

    }

    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVector();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, 0f);

        if (moveDir.x < 0)
        {
            isWalkingLeft = true;
            isWalkingRight = false;
        }
        else if (moveDir.x > 0)
        {
            isWalkingRight = true;
            isWalkingLeft = false;
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
            playerBody.gravityScale = 2.5f;
            hasJumped = false;
        }

        if (playerBody.linearVelocityY <= 0)
        {
            playerBody.gravityScale = 3.5f;
        }
    }

    public bool IsWalkingLeft()
    {
        return isWalkingLeft;
    }

    public bool IsWalkingRight()
    {
        return isWalkingLeft;
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

            Instantiate(goo, gooBallPosition);
            hasFired = true;

        }
        else
        {
            FireCooldown();
        }
            

    }

    IEnumerator FireCooldown()
    {

        yield return new WaitForSeconds(5);
        hasFired = false;

    }

}
