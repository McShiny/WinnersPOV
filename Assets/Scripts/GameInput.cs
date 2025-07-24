using UnityEngine;

public class GameInput : MonoBehaviour
{

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

    }

    public Vector2 GetMovementVector()
    {

        Vector2 inputVector = new Vector2(playerInputActions.Player.Move.ReadValue<float>(), 0f);

        return inputVector;
    }
    
    public bool GetJump()
    {

        return 0 < playerInputActions.Player.Jump.ReadValue<float>();

    }

    public bool IsFire()
    {

        return 0 < playerInputActions.Player.FireGoo.ReadValue<float>();

    }

}
