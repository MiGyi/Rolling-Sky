using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("References")]
    public GameObject platformPrefab;
    public GameObject jumpingPlatformPrefab;
    public GameObject[] obstaclePrefabs;
    public Transform player;

    [Header("Map Settings")]
    public int platformsPerChunk = 10;  // Number of platforms to generate in each chunk
    public float generationDistanceAhead = 50.0f;  // Distance ahead of the player to generate platforms
    public float maxDistanceBehind = 20.0f;  // Maximum distance behind the player to keep platforms
    public TextAsset mapFile;

    private Vector3 spawnPosition = Vector3.zero;  // Position where the next chunk of platforms will spawn
    private List<GameObject> activePlatforms = new List<GameObject>();  // Keep track of active platforms
    private List<GameObject> activeObstacles = new List<GameObject>();  // Keep track of active obstacles
    private float lastGeneratedZ = 0;  // The Z-position of the last generated platform

    private Queue<string> mapDataQueue = new Queue<string>(); // To store lines from the file

    public void InitMap()
    {
        spawnPosition = Vector3.zero;
        LoadMapDataFromFile();
        GenerateInitialPlatforms();
    }

    public void UpdateMap()
    {
        if (player.position.z + generationDistanceAhead > lastGeneratedZ && mapDataQueue.Count > 0)
        {
            GenerateChunkFromData();
        }

        RemoveOldPlatforms();
    }

    private void LoadMapDataFromFile()
    {
        string[] lines = mapFile.text.Split('\n');
        
        foreach (var line in lines)
        {
            mapDataQueue.Enqueue(line);
        }
    }

    private void GenerateInitialPlatforms()
    {
        for (int i = 0; i < platformsPerChunk && mapDataQueue.Count > 0; i++)
        {
            GenerateChunkFromData();
        }
    }

    private void GenerateChunkFromData()
    {
        if (mapDataQueue.Count == 0) return;

        string rowData = mapDataQueue.Dequeue();

        string[] rowElements = rowData.Trim().Split(' ');

        float platformLength = GetPrefabLength(platformPrefab);
        float platformWidth = GetPrefabWidth(platformPrefab);

        for (int lane = 0; lane < rowElements.Length; lane++)
        {
            int element = int.Parse(rowElements[lane]);

            Vector3 lanePosition = spawnPosition + new Vector3((lane - (rowElements.Length / 2)) * platformWidth, -0.25f, 0);

            GameObject platform = Instantiate(platformPrefab, lanePosition, Quaternion.identity);
            platform.transform.parent = this.transform;
            activePlatforms.Add(platform);

            if (element >= 1 && element <= obstaclePrefabs.Length)
            {
                Vector3 obstaclePosition = lanePosition + new Vector3(0, 0.5f, 0);

                GameObject obstacle = Instantiate(obstaclePrefabs[element - 1], obstaclePosition, Quaternion.identity);
                ObstacleMovement obstacleMovement = obstacle.GetComponent<ObstacleMovement>();
                obstacleMovement.InitialPosition = obstaclePosition;

                activeObstacles.Add(obstacle);
            }
        }

        spawnPosition += new Vector3(0, 0, platformLength);
        lastGeneratedZ = spawnPosition.z;
    }

    private float GetPrefabLength(GameObject prefab)
    {
        Renderer renderer = prefab.GetComponent<Renderer>();
        if (renderer != null)
        {
            return renderer.bounds.size.z;
        }
        return 5.0f;
    }

    private float GetPrefabWidth(GameObject prefab)
    {
        Renderer renderer = prefab.GetComponent<Renderer>();
        if (renderer != null)
        {
            return renderer.bounds.size.x;
        }
        return 2.0f;
    }

    private void RemoveOldPlatforms()
    {
        for (int i = activePlatforms.Count - 1; i >= 0; i--)
        {
            GameObject platform = activePlatforms[i];
            if (platform.transform.position.z < player.position.z - maxDistanceBehind)
            {
                activePlatforms.RemoveAt(i);
                Destroy(platform);
            }
        }
        for (int i = activeObstacles.Count - 1; i >= 0; i--)
        {
            GameObject obstacle = activeObstacles[i];
            if (obstacle.transform.position.z < player.position.z - maxDistanceBehind)
            {
                activeObstacles.RemoveAt(i);
                Destroy(obstacle);
            }
        }
    }
}
