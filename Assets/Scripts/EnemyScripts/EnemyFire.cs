using UnityEngine;

public class EnemyFire : MonoBehaviour
{

    [SerializeField] private Transform vialPosition;
    [SerializeField] private Transform vial;
    [SerializeField] private EnemyMove enemyMove;
    [SerializeField] private float vialCooldown;

    private bool hasFired;
    private float currentTime;


    private void Update()
    {
        if (!hasFired)
        {

            if (enemyMove.IsMovingRight())
            {
                Instantiate(vial, vialPosition.position, vialPosition.rotation);
            }
            else
            {
                Instantiate(vial, vialPosition.position, Quaternion.Euler(0, 180, 0));
            }

            hasFired = true;
            currentTime = Time.time;
        }
        
        else if (Time.time - currentTime > vialCooldown)
        {
            hasFired = false;
        }
    }
}
