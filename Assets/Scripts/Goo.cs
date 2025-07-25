using Unity.VisualScripting;
using UnityEngine;

public class Goo : MonoBehaviour
{

    [SerializeField] private float bulletSpeed = 100f;
    [SerializeField] private Player player;
    [SerializeField] private Rigidbody2D gooBody;

    private string ENEMY_TAG = "Enemy";

    private void Start()
    {

        gooBody.linearVelocityX = bulletSpeed * transform.right.x;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
            

    }

}
