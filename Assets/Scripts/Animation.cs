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

    private void Awake()
    {

        renderCharacter = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();

    }

    void Update()
    {

        CharacterWalking();
        CharacterJump();
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
    //        playerAnim.SetBool(JUMP_ANIMATION, true);
    //    }
    //    else
    //    {
    //        playerAnim.SetBool(JUMP_ANIMATION, false);
    //    }
    //}
}
