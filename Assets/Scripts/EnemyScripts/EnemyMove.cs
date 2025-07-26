using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    [SerializeField] private float rightPos;
    [SerializeField] private float leftPos;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveDistance;

    private bool lastDirectionRight;
    private bool isRight;
    private bool movingRight;
    private bool movingLeft;

    private void Update()
    {

        if (transform.position.x < rightPos && isRight)
        {
            MoveRight();
        }
        else
        {
            isRight = false;
        }

        if (transform.position.x > leftPos && !isRight)
        {
            MoveLeft();
        }
        else
        {
            isRight = true;
        }


    }

    private void MoveRight()
    {
        movingRight = true;
        movingLeft = false;
        transform.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
    }

    private void MoveLeft() 
    {
        movingLeft = true;
        movingRight = false;
        transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
    }

    public bool IsMovingRight()
    {
        return movingRight;
    }

    public bool IsMovingLeft()
    {
        return movingLeft;
    }

}
