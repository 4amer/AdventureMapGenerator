using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGenerationWindow : MonoBehaviour
{
    [SerializeField] private Scrollbar sliderIslads;
    [SerializeField] private Scrollbar sliderBuildings;
    [SerializeField] private Scrollbar sliderForestsAndFields;

    [SerializeField] private TextMeshProUGUI valueIslands;
    [SerializeField] private TextMeshProUGUI valueBuildings;
    [SerializeField] private TextMeshProUGUI valueForestAndFields;

    [SerializeField] private TMP_InputField generationKey;
    [SerializeField] private TMP_InputField worldName;

    [SerializeField] private GameObject mineMenuWindow;
    [SerializeField] private GameObject newGenerationWindow;

    public void Back()
    {
        newGenerationWindow.SetActive(false);
        mineMenuWindow.SetActive(true);
    }

    public void OnIslandScrollBarChanged()
    {
        valueIslands.text = "Размер: " + MathScale(sliderIslads.value);
    }

    public void OnDecorationScrollBarChanged()
    {
        valueForestAndFields.text = "Размер: " + MathScale(sliderForestsAndFields.value);
    }

    public void OnBuildingsScrollBarChanged()
    {
        valueBuildings.text = "Размер: " + MathScale(sliderBuildings.value);
    }

    private int MathScale(float value)
    {
        return (int) (value * 100);
    }

    public void Generate()
    {
        int seed = 0;
        int zoomIsland = (int)(sliderIslads.value * 100);
        int zoomNature = (int)(sliderForestsAndFields.value * 100);
        int zoomBuilds = (int)(sliderBuildings.value * 100);
        string name = worldName.text;

        if (zoomIsland <= 1) zoomIsland = 2;
        if (zoomNature <= 1) zoomNature = 2;
        if (zoomBuilds <= 1) zoomBuilds = 2;
        try
        {
            seed = int.Parse(generationKey.text);
        }
        catch (FormatException)
        {
            seed = UnityEngine.Random.Range(0,1000000);
        }

        if (seed == 0)
        {
            seed = UnityEngine.Random.Range(0, 1000000);
        }

        WorldGenerationSetup worldGenerationSetup = 
            new WorldGenerationSetup(name, seed, zoomIsland, zoomNature, zoomBuilds);
        Data.GetInstance.currentWorldGenerationSetup = worldGenerationSetup;

        SceneManager.LoadScene(1);
    }
}
