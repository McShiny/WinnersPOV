using System.Collections;
using UnityEngine;

public class Animation : MonoBehaviour
{

    [SerializeField] private Player player;
    [SerializeField] private Transform shootPosition;

    private SpriteRenderer renderCharacter;
    private Animator playerAnim;

    private string WALK_ANIMATION = "isWalking";
    private string JUMP_ANIMATION = "isJump";
    private string LAND_ANIMATION = "doneJump";
    private string SPIT_ANIMATION = "isSpit";
    private string DEATH_ANIMATION = "isDead";

    private void Awake()
    {

        renderCharacter = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();

    }

    void Update()
    {

        CharacterWalking();
        CharacterJump();
        DeathAnimation();
        //CharacterSpit();

    }

    private void CharacterWalking()
    {
        if (player.IsWalkingLeft())
        {
            renderCharacter.flipX = true;
            shootPosition.transform.position = player.transform.position - new Vector3(0.6f, -1f, 0f);
            playerAnim.SetBool(WALK_ANIMATION, true);

        }
        else if (player.IsWalkingRight())
        {
            renderCharacter.flipX = false;
            shootPosition.transform.position = player.transform.position + new Vector3(0.6f, 1f, 0f);
            playerAnim.SetBool(WALK_ANIMATION, true);
        }
        else
        {
            playerAnim.SetBool(WALK_ANIMATION, false);
        }
    }

    private void CharacterJump()
    {
        if (player.HasJumped())
        {
            playerAnim.SetBool(JUMP_ANIMATION, true);
        }
        else if (!player.IsGrounded())
        {
            playerAnim.SetBool(JUMP_ANIMATION, false);
            playerAnim.SetBool(LAND_ANIMATION, true);
        }
        else
        {
            playerAnim.SetBool(LAND_ANIMATION, false);
        }
    }

    //private void CharacterSpit()
    //{
    //    if (player.HasFired())
    //    {
    //        playerAnim.SetBool(SPIT_ANIMATION, true);
    //    }
    //    else
    //    {
    //        playerAnim.SetBool(SPIT_ANIMATION, false);
    //    }

    private void DeathAnimation()
    {
        if (player.HasDied())
        {
            playerAnim.SetBool(DEATH_ANIMATION, true);
            StartCoroutine(DeathTimer());
        }
    }

    IEnumerator DeathTimer()
    {

        while (true)
        {
            yield return new WaitForSeconds(1f);

            player.PlayerDie();

        }

    }

}
