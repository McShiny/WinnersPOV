using UnityEngine;

public class Vial : MonoBehaviour
{

    [SerializeField] private float bulletSpeed = 100f;
    [SerializeField] private Rigidbody2D vialBody;

    private float vialDamage = 25f;

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
