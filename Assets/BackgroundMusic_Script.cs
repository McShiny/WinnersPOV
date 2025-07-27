using UnityEngine;

public class BackgroundMusic_Script : MonoBehaviour
{
    public static BackgroundMusic_Script instance;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
