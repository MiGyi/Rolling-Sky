using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("References")]
    public GameObject platformPrefab;
    public GameObject[] obstaclePrefabs;
    public Transform player;

    [Header("Map Settings")]
    public float platformLength = 5.0f;  // Length of each platform
    public float laneSpacing = 2.0f;    // Distance between lanes
    public int platformsPerChunk = 10;  // Number of platforms to generate in each chunk
    public float generationDistanceAhead = 50.0f;  // Distance ahead of the player to generate platforms
    public float maxDistanceBehind = 20.0f;  // Maximum distance behind the player to keep platforms

    private Vector3 spawnPosition = Vector3.zero;  // Position where the next chunk of platforms will spawn
    private List<GameObject> activePlatforms = new List<GameObject>();  // Keep track of active platforms
    private List<GameObject> activeObstacles = new List<GameObject>();  // Keep track of active obstacles
    private float lastGeneratedZ = 0;  // The Z-position of the last generated platform

    private void Start()
    {
        spawnPosition = Vector3.zero;
        GenerateInitialPlatforms();
    }

    private void Update()
    {
        if (player.position.z + generationDistanceAhead > lastGeneratedZ)
        {
            GenerateChunk();
            GenerateObstacle();

            GenerateChunk();
            GenerateObstacle();

            GenerateChunk();
            GenerateObstacle();

            GenerateChunk();
            GenerateObstacle();
        }

        RemoveOldPlatforms();
    }

    private void GenerateInitialPlatforms()
    {
        for (int i = 0; i < platformsPerChunk; i++)
        {
            GenerateRowOfPlatforms();
        }
    }

    private void GenerateChunk()
    {
        for (int i = 0; i < platformsPerChunk; i++)
        {
            GenerateRowOfPlatforms();
        }
    }

    private void GenerateObstacle()
    {
        float lane = Random.Range(-3, 4) * laneSpacing;
        float distance = Random.Range(-2, -4) * laneSpacing;
        float distance2 = Random.Range(2, 4) * laneSpacing;
        
        Vector3 lanePosition = new Vector3(lane, 0.5f, lastGeneratedZ);
        Vector3 lanePosition2 = new Vector3(lane + distance, 0.5f, lastGeneratedZ);
        Vector3 lanePosition3 = new Vector3(lane + distance2, 0.5f, lastGeneratedZ);

        GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        GameObject obstaclePrefab2 = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        GameObject obstaclePrefab3 = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        
        GameObject obstacle = Instantiate(obstaclePrefab, lanePosition, Quaternion.identity);
        GameObject obstacle2 = Instantiate(obstaclePrefab2, lanePosition2, Quaternion.identity);
        GameObject obstacle3 = Instantiate(obstaclePrefab3, lanePosition3, Quaternion.identity);
        
        ObstacleMovement obstacleMovement = obstacle.GetComponent<ObstacleMovement>();
        obstacleMovement.InitialPosition = lanePosition;

        ObstacleMovement obstacleMovement2 = obstacle2.GetComponent<ObstacleMovement>();
        obstacleMovement2.InitialPosition = lanePosition2;

        ObstacleMovement obstacleMovement3 = obstacle3.GetComponent<ObstacleMovement>();
        obstacleMovement3.InitialPosition = lanePosition3;

        activeObstacles.Add(obstacle);
        activeObstacles.Add(obstacle2);
        activeObstacles.Add(obstacle3);
    }

    private void GenerateRowOfPlatforms()
    {
        for (int lane = -5; lane <= 5; lane++)
        {
            Vector3 lanePosition = spawnPosition + new Vector3(lane * laneSpacing, 0, 0);
            GameObject platform = Instantiate(platformPrefab, lanePosition, Quaternion.identity);
            platform.transform.parent = this.transform;
            activePlatforms.Add(platform);
        }

        spawnPosition += new Vector3(0, 0, platformLength);
        lastGeneratedZ = spawnPosition.z;
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
