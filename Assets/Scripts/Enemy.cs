using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float health = 100f;

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
        Destroy(gameObject);
    }

}
