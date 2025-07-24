using UnityEngine;

public class Goo : MonoBehaviour
{

    [SerializeField] private Player player;
    [SerializeField] private float bulletSpeed = 1f;

    private void Update()
    {

        transform.position += new Vector3(bulletSpeed, 0f, 0f);

    }

}
