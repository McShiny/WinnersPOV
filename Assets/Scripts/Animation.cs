using UnityEngine;

public class Animation : MonoBehaviour
{

    [SerializeField] private Player player;

    private SpriteRenderer renderCharacter;

    private void Awake()
    {

        renderCharacter = GetComponent<SpriteRenderer>();

    }

    void Update()
    {

        if (player.IsWalkingLeft())
        {
            renderCharacter.flipX = true;
        }
        else
        {
            renderCharacter.flipX = false;
        }

    }
}
