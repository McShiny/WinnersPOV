using System.Collections;
using UnityEngine;

public class EnemyMoveAnimation : MonoBehaviour
{

    [SerializeField] private EnemyMove enemyMove;
    [SerializeField] private Enemy enemy;
    [SerializeField] private Transform shootPosition;

    private SpriteRenderer renderEnemy;
    private Animator enemyAnim;

    private string DEATH_ANIMATION = "isDead";

    private void Awake()
    {
        
        renderEnemy = GetComponent<SpriteRenderer>();
        enemyAnim = GetComponent<Animator>();

    }

    private void Update()
    {

        MovementAnimation();

        DeathAnimation();

    }

    private void MovementAnimation()
    {
        if (enemyMove.IsMovingLeft())
        {
            renderEnemy.flipX = true;
            shootPosition.transform.position = enemy.transform.position - new Vector3(0.6f, -1f, 0f);

        }
        else if (enemyMove.IsMovingRight())
        {
            renderEnemy.flipX = false;
            shootPosition.transform.position = enemy.transform.position + new Vector3(0.6f, 1f, 0f);

        }
    }

    private void DeathAnimation()
    {
        if (enemy.HasDied())
        {
            enemyAnim.SetBool(DEATH_ANIMATION, true);
            StartCoroutine(DeathTimer());
        }
    }

    IEnumerator DeathTimer()
    {

        while (true)
        {
            yield return new WaitForSeconds(1f);

            enemy.EnemyDie();

        }

    }

}
