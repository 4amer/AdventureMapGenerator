using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldGeneration : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] Tilemap tilemapNature;

    [SerializeField] private int heightMap;
    [SerializeField] private int widthMap;
    [SerializeField] private int seed = 0;

    [SerializeField] AnimatedTile[] darkGrasses;
    [SerializeField] AnimatedTile[] lightGrasses;
    [SerializeField] AnimatedTile sand;
    [SerializeField] AnimatedTile softWater;
    [SerializeField] AnimatedTile lightWater;
    [SerializeField] AnimatedTile water;
    [SerializeField] AnimatedTile darkWater;

    [SerializeField] private int zoomFloor;

    [Space]

    [SerializeField] AnimatedTile[] trees;
    [SerializeField] AnimatedTile[] palmes;
    [SerializeField] AnimatedTile[] whealFields;
    [SerializeField] AnimatedTile mill;
    [SerializeField] AnimatedTile[] boaths;
    [SerializeField] private int zoomDecoration;

    [Space]

    [SerializeField] AnimatedTile[] houses;
    [SerializeField] AnimatedTile custle;
    [SerializeField] AnimatedTile[] towers;
    [SerializeField] private int zoomBuildings;

    private float perlinNoiceFloor;
    private float perlinNoiceDecoration;
    private float perlinNoiceBuildings;

    public void Start()
    {
        WorldGenerationSetup worldGenerationSetup = Data.GetInstance.currentWorldGenerationSetup;

        if (worldGenerationSetup != null)
        {
            zoomBuildings = worldGenerationSetup.zoomBuildings;
            zoomDecoration = worldGenerationSetup.zoomDecoration;
            zoomFloor = worldGenerationSetup.zoomFloor;
            seed = worldGenerationSetup.seed;
            Debug.Log(zoomBuildings);
            Debug.Log(zoomDecoration);
            Debug.Log(zoomFloor);
            Debug.Log(seed);
        } else
        {
            seed = Random.Range(0, 999999);
        }

        for (int x = 0; x < widthMap; x++)
        {
            for (int y = 0; y < heightMap; y++)
            {
                perlinNoiceFloor = Mathf.PerlinNoise(((float)x + seed) / zoomFloor, ((float)y + seed) / zoomFloor);
                Debug.Log(perlinNoiceFloor);

                //water tiles

                if (perlinNoiceFloor < 0.2f)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), darkWater);
                } 
                else if (perlinNoiceFloor >= 0.2f && perlinNoiceFloor < 0.3f)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), water);
                }
                else if(perlinNoiceFloor >= 0.3f && perlinNoiceFloor < 0.4f)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), lightWater);
                }
                else if (perlinNoiceFloor >= 0.4f && perlinNoiceFloor < 0.5f)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), softWater);
                }

                //ground tiles

                else if (perlinNoiceFloor >= 0.5f && perlinNoiceFloor < 0.55f)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), sand);
                }
                else if (perlinNoiceFloor >= 0.55f && perlinNoiceFloor < 0.7f)
                {
                    int tileNum = Random.Range(0, darkGrasses.Length);
                    tilemap.SetTile(new Vector3Int(x, y, 0), darkGrasses[tileNum]);
                }
                else if (perlinNoiceFloor >= 0.7f)
                {
                    int tileNum = Random.Range(0, lightGrasses.Length);
                    tilemap.SetTile(new Vector3Int(x, y, 0), lightGrasses[tileNum]);
                }

                //Decoration
                perlinNoiceDecoration = Mathf.PerlinNoise(((float)x - seed) / zoomDecoration, ((float)y - seed) / zoomDecoration);

                
                if(perlinNoiceDecoration < 0.4f && perlinNoiceFloor >= 0.55f)
                {
                    int tileNum = Random.Range(0, trees.Length);
                    tilemapNature.SetTile(new Vector3Int(x, y, 0), trees[tileNum]);
                }
                else if (perlinNoiceDecoration < 0.4f && perlinNoiceFloor >= 0.5f && perlinNoiceFloor < 0.55f)
                {
                    int tileNum = Random.Range(0, palmes.Length);
                    tilemapNature.SetTile(new Vector3Int(x, y, 0), palmes[tileNum]);
                }
                else if (perlinNoiceDecoration >= 0.8f && perlinNoiceDecoration < 0.97f && perlinNoiceFloor >= 0.55f)
                {
                    int tileNum = Random.Range(0, whealFields.Length);
                    tilemapNature.SetTile(new Vector3Int(x, y, 0), whealFields[tileNum]);
                }
                else if (perlinNoiceDecoration >= 0.97f && perlinNoiceFloor >= 0.55f)
                {
                    tilemapNature.SetTile(new Vector3Int(x, y, 0), mill);
                }
                //boath

                perlinNoiceDecoration = Mathf.PerlinNoise(((float)x - seed) / (zoomDecoration / 4), ((float)y - seed) / (zoomDecoration / 4));
                
                if (perlinNoiceDecoration < 0.05f && perlinNoiceFloor <= 0.4f)
                {
                    int tileNum = Random.Range(0, boaths.Length);
                    tilemapNature.SetTile(new Vector3Int(x, y, 0), boaths[tileNum]);
                }

                //Buildings

                perlinNoiceBuildings = Mathf.PerlinNoise(((float)x + seed) / (zoomBuildings), ((float)y - seed) / (zoomBuildings));

                if (perlinNoiceBuildings >= 0.8f && perlinNoiceFloor >= 0.55f)
                {
                    int tileNum = Random.Range(0, houses.Length);
                    tilemapNature.SetTile(new Vector3Int(x, y, 0), houses[tileNum]);
                } else if (perlinNoiceBuildings >= 0.78f && perlinNoiceBuildings < 0.8f && perlinNoiceFloor >= 0.55f)
                {
                    int tileNum = Random.Range(0, towers.Length);
                    tilemapNature.SetTile(new Vector3Int(x, y, 0), towers[tileNum]);
                }
            }
        }
    }
}
