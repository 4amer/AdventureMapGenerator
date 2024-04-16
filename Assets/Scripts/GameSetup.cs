using UnityEngine;

public class GameSetup : MonoBehaviour
{
    [SerializeField] private int fps = 60;


    void Awake()
    {
        Application.targetFrameRate = fps;
    }
}
