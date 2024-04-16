using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseWindow : MonoBehaviour
{
    [SerializeField] private GameObject pousePanel;
    [SerializeField] private GameObject pouseBtn;

    public void PouseOn()
    {
        pouseBtn.SetActive(false);
        pousePanel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void PouseOff()
    {
        pouseBtn.SetActive(true);
        pousePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void SaveGenerationSetup()
    {
        Data data = Data.GetInstance;
        data.AddToGenerationSetupList(data.currentWorldGenerationSetup);
        data.SaveGenerationSetups();
    }
}
