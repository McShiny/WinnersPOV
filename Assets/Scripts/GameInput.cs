using UnityEngine;

public class GameInput : MonoBehaviour
{

    public Vector2 GetMovementVector()
    {
         Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x += 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x -= 1;
        }

        return inputVector;
    }

}
