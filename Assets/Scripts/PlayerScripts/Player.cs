using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private Rigidbody2D playerBody;
    [SerializeField] private Transform gooBallPosition;
    [SerializeField] private Transform goo;
    [SerializeField] private Animator playerAnim;

    private GameInput gameInput;

    private bool hasJumped;
    private bool isGrounded;
    private bool hasFired;
    private float currentTime;
    private Vector3 moveDir;
    private float gooCooldown = 0.75f;
    private float health = 150f;
    private bool hasDied;
    private bool isShotgun;

    private string GROUND_TAG = "Ground";
    private string DAMAGE_ANIMATION = "isHit";
    private string SHOTGUN_TAG = "ShotgunUpgrade";
    private string END_TAG = "EndGame";

    private bool isWalkingLeft;
    private bool isWalkingRight;
    private bool lastDirectionRight;

    

    private void Awake()
    { 
        gameInput = FindAnyObjectByType<GameInput>();
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

        if (gameInput.GetJump() && isGrounded && playerBody.linearVelocityY <= 0)
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

    public bool HasDied()
    {
        return hasDied;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
            isGrounded = true;
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag(SHOTGUN_TAG))
        {
            isShotgun = true;
        }

        if (trigger.gameObject.CompareTag(END_TAG))
        {
            WinGame();
        }

    }


    private void PlayerFireProjectile()
    {
        

        if (gameInput.IsFire() && !hasFired)
        {

            if(lastDirectionRight)
            {
                if (isShotgun)
                {
                    Instantiate(goo, gooBallPosition.position + new Vector3(0f, 0.66f, 0f), gooBallPosition.rotation);
                    Instantiate(goo, gooBallPosition.position, gooBallPosition.rotation);
                    Instantiate(goo, gooBallPosition.position - new Vector3(0f, 0.66f, 0f), gooBallPosition.rotation);
                }
                else
                {
                    Instantiate(goo, gooBallPosition.position, gooBallPosition.rotation);
                }   
            }
            else
            {
                if (isShotgun)
                {
                    Instantiate(goo, gooBallPosition.position + new Vector3(0f, 0.66f, 0f), Quaternion.Euler(0, 180, 0));
                    Instantiate(goo, gooBallPosition.position, Quaternion.Euler(0, 180, 0));
                    Instantiate(goo, gooBallPosition.position - new Vector3(0f, 0.66f, 0f), Quaternion.Euler(0, 180, 0));
                }
                else
                {
                    Instantiate(goo, gooBallPosition.position, Quaternion.Euler(0, 180, 0));
                }
                    
            }

                hasFired = true;
            currentTime = Time.time;

        }
        else if (Time.time - currentTime > gooCooldown)
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

    public bool HasFired()
    {
        return gameInput.IsFire();
    }

    public void TakeDamage(float damage)
    {
        if (health - damage < 0)
        {
            health = 0;
        }
        else if(health - damage > 150)
        {
            health = 150;
        }
        else
        {
            health -= damage;
        }
            
        DamageAnimation();

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        hasDied = true;
    }

    public void DamageAnimation()
    {

        playerAnim.SetBool(DAMAGE_ANIMATION, true);
        StartCoroutine(DamageTimer());

    }

    IEnumerator DamageTimer()
    {

        while (true)
        {
            yield return new WaitForSeconds(0.25f);

            playerAnim.SetBool(DAMAGE_ANIMATION, false);
        }

    }

    public void PlayerDie()
    {
        Destroy(gameObject);

    }

    public bool IsShotgun()
    {
        return isShotgun;
    }

    public int getHealth()
    {
        return (int)health;
    }

    public void WinGame()
    {
        SceneManager.LoadScene("WinScreen");
    }

}
