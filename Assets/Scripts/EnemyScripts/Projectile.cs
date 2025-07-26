using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float bulletSpeed;
    [SerializeField] private Rigidbody2D vialBody;
    [SerializeField] private float vialDamage;


    private void Start()
    {

        vialBody.linearVelocityX = bulletSpeed * transform.right.x;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(vialDamage);
            Destroy(gameObject);
        }

    }


}
