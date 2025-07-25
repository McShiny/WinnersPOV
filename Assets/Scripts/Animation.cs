using UnityEngine;

public class Animation : MonoBehaviour
{

    [SerializeField] private Player player;
    [SerializeField] private Transform shootPosition;

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
            shootPosition.transform.position = player.transform.position - new Vector3(0.6f, 0f, 0f);
            playerAnim.SetBool(WALK_ANIMATION, true);

        }
        else if (player.IsWalkingRight())
        {
            renderCharacter.flipX = false;
            shootPosition.transform.position = player.transform.position + new Vector3(0.6f, 0f, 0f);
            playerAnim.SetBool(WALK_ANIMATION, true);
        }
        else
        {
            playerAnim.SetBool(WALK_ANIMATION, false);
        }
    }
}
