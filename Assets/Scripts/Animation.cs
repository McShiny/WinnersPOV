using UnityEngine;

public class Animation : MonoBehaviour
{

    [SerializeField] private Player player;

    private SpriteRenderer renderCharacter;
    private Animator playerAnim;

    private string WALK_ANIMATION = "isWalking";

    private void Awake()
    {

        renderCharacter = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();

    }

    void Update()
    {

        CharacterWalking();

    }

    private void CharacterWalking()
    {
        if (player.IsWalkingLeft())
        {
            renderCharacter.flipX = true;
            playerAnim.SetBool(WALK_ANIMATION, true);

        }
        else if (player.IsWalkingRight())
        {
            renderCharacter.flipX = false;
            playerAnim.SetBool(WALK_ANIMATION, true);
        }
        else
        {
            playerAnim.SetBool(WALK_ANIMATION, false);
        }
    }
}
