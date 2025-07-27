using Unity.Cinemachine;
using UnityEngine;

public class AssignCamera : MonoBehaviour
{
    private CinemachineCamera virtualCamera;
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
        virtualCamera = FindAnyObjectByType<CinemachineCamera>();
    }

    private void Start()
    {
        
        if (player != null)
        {
            virtualCamera.Follow = player.transform;
            virtualCamera.LookAt = player.transform;
        }
        else
        {
            Debug.Log("No Camera Asigned");
        }

    }

}
