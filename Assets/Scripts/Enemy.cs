using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float health = 100f;
    //[SerializeField] GameObject deathEffect;

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
