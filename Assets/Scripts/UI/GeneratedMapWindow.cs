using UnityEngine;

public class GeneratedMapWindow : MonoBehaviour
{
    [SerializeField] private GameObject SelectBtn;
    [SerializeField] private GameObject SelectBtnParent;

    [SerializeField] private GameObject mainMenuWindow;
    [SerializeField] private GameObject generatedMapsWindows;

    void Start()
    {
        Data data = Data.GetInstance;
        foreach (WorldGenerationSetup wgs in data.GetWorldGenerationSetups())
        {
            GameObject btn = Instantiate(SelectBtn, SelectBtnParent.transform);
            WorldGenerationSetupBtn wgsbtn = btn.GetComponent<WorldGenerationSetupBtn>();
            wgsbtn.worldGenerationSetup = wgs;
            wgsbtn.SetName(wgs.name);
            wgsbtn.SetSeed(wgs.seed);
        }
    }

    public void ToMainMenu()
    {
        mainMenuWindow.SetActive(true);
        generatedMapsWindows.SetActive(false);
    }
}
