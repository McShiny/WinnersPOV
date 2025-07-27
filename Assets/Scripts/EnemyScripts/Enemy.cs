using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float health = 100f;
    [SerializeField] private Animator enemyAnim;

    private bool hasDied;

    private string DAMAGE_ANIMATION = "isHit";

    public void TakeDamage(float damage)
    {
        health -= damage;
        DamageAnimation();

        if (health <= 0)
        { 
            Die();
        }
    }

    private void Die()
    {
        hasDied = true;
    }

    public bool HasDied()
    {
        return hasDied;
    }

    public void EnemyDie()
    {
        Destroy(gameObject);

    }

    public void DamageAnimation()
    {

        enemyAnim.SetBool(DAMAGE_ANIMATION, true);
        StartCoroutine(DamageTimer());

    }

    IEnumerator DamageTimer()
    {

        while (true)
        {
            yield return new WaitForSeconds(0.25f);

            enemyAnim.SetBool(DAMAGE_ANIMATION, false);
        }

    }

}
