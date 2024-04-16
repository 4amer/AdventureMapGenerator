using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldGenerationSetupBtn : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI seed;
    public WorldGenerationSetup worldGenerationSetup { get; set; }

    public void SetSeed(int seed)
    {
        this.seed.text = "Ключ: " + seed.ToString();
    }

    public void SetName(string name)
    {
        this.name.text = "Имя: " + name; 
    }

    public void Generate()
    {
        Data.GetInstance.currentWorldGenerationSetup = worldGenerationSetup;

        SceneManager.LoadScene(1);
    }
}
