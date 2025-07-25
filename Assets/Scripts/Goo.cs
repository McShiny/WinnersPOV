using UnityEngine;

public class Goo : MonoBehaviour
{

    [SerializeField] private float bulletSpeed = 25f;
    [SerializeField] private Player player;
    [SerializeField] private Rigidbody2D gooBody;

    private Vector3 fireDirection;

    private void Start()
    {

        if (player.IsWalkingLeft())
        {
            gooBody.linearVelocityX = bulletSpeed * Time.deltaTime * -1;
        }
        else if (player.IsWalkingRight())
        {
            gooBody.linearVelocityX = bulletSpeed * Time.deltaTime;
        }
        else
        {
            if (player.LastDirectionRight())
            {
                gooBody.linearVelocityX = bulletSpeed * Time.deltaTime;
            }
            else
            {
                gooBody.linearVelocityX = bulletSpeed * Time.deltaTime * -1;
            }
        }

    }
    
}
