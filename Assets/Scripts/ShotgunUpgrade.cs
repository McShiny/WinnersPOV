using Unity.VisualScripting;
using UnityEngine;

public class ShotgunUpgrade : MonoBehaviour
{
    [SerializeField] private Player player;

    private string PLAYER_TAG = "Player";


    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag(PLAYER_TAG))
        {
            Destroy(gameObject);
        }

    }

}
