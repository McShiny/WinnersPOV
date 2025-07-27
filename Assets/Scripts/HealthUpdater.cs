using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthUpdater : MonoBehaviour
{

    public TextMeshProUGUI health;
    private Player player;
    private int maxHealth = 100;

    private void Awake()
    {
        player = FindAnyObjectByType<Player>();
    }

    private void Start()
    {
        health.text = maxHealth.ToString();
    }

    private void Update()
    {
        health.text = player.getHealth().ToString();
    }

}
