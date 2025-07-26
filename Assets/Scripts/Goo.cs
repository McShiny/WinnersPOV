using Unity.VisualScripting;
using UnityEngine;

public class Goo : MonoBehaviour
{

    [SerializeField] private float bulletSpeed;
    [SerializeField] private Rigidbody2D gooBody;
    [SerializeField] private Player player;

    private float gooDamage = 20f;

    private void Start()
    {

        if (player.IsShotgun())
        {
            gooBody.linearVelocityX = bulletSpeed * Random.Range(1f, 1.5f) * transform.right.x;
            gooBody.linearVelocityY = Random.Range(0f, 1f) * transform.right.x;
        }
        else
        {
            gooBody.linearVelocityX = bulletSpeed * transform.right.x;
        }
            

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(gooDamage);
            Destroy(gameObject);
        }

    }

}
