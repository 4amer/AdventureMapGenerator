using UnityEngine;

public class MainMenuWindow : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuWindow;
    [SerializeField] private GameObject newGenerationWindow;
    [SerializeField] private GameObject GeneratedMapsWindow;

    private void Awake()
    {
        Data.GetInstance.LoadGenerationSetups();
    }

    public void GoToNewGeneration()
    {
        mainMenuWindow.SetActive(false);
        newGenerationWindow.SetActive(true);
    }

    public void GoToGeneratedMaps()
    {
        mainMenuWindow.SetActive(false);
        GeneratedMapsWindow.SetActive(true);
    }
}
