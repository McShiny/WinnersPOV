using Unity.VisualScripting;
using UnityEngine;

public class Goo : MonoBehaviour
{

    [SerializeField] private float bulletSpeed = 100f;
    [SerializeField] private Player player;
    [SerializeField] private Rigidbody2D gooBody;

    private float gooDamage = 20f;

    private void Start()
    {

        gooBody.linearVelocityX = bulletSpeed * transform.right.x;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(gooDamage);
        }
        
        Destroy(gameObject);
        
            

    }

}
