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
    public TextAsset[] mapFile;

    private Vector3 spawnPosition = Vector3.zero;  // Position where the next chunk of platforms will spawn
    private List<GameObject> activePlatforms = new List<GameObject>();  // Keep track of active platforms
    private List<GameObject> activeObstacles = new List<GameObject>();  // Keep track of active obstacles
    private float lastGeneratedZ = 0;  // The Z-position of the last generated platform

    private Queue<string> mapDataQueue = new Queue<string>(); // To store lines from the file
    private GameData gameData = new GameData();

    private bool skipNextRows = false;
    private int rowsToSkip = 0;
    private int preventSpawnJumping = 0;
    private int preventSpawnObstacle = 0;
    private bool rowToSpawnAtStart = true;

    public void InitMap()
    {
        spawnPosition = Vector3.zero;
        LoadMapDataFromFile();
        GenerateInitialPlatforms();
    }

    public void UpdateMap()
    {
        if (player == null)
        {
            return;
        }
        if (player.position.z + generationDistanceAhead > lastGeneratedZ)
        {
            GenerateChunkFromData();
        }

        RemoveOldPlatforms();
    }
    public void UpdateEndless()
    {
        if (player.position.z + generationDistanceAhead > lastGeneratedZ)
        {
            GenerateChunk();
        }

        RemoveOldPlatforms();
    }

    private void LoadMapDataFromFile()
    {
        int level = gameData.choosingMapIndex;
        string[] lines = mapFile[level - 1].text.Split('\n');
        
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
            
            // Empty platform
            if (element == 6) 
            {
                continue;
            }
            else
            {
                Vector3 lanePosition = spawnPosition + new Vector3((lane - (rowElements.Length / 2)) * platformWidth, -0.25f, 0);
                if (element != 1) 
                {

                    GameObject platform = Instantiate(platformPrefab, lanePosition, Quaternion.identity);
                    platform.transform.parent = this.transform;
                    activePlatforms.Add(platform);
                }

                if (element == 1) {
                    GameObject platform = Instantiate(jumpingPlatformPrefab, lanePosition, Quaternion.identity);
                    platform.transform.parent = this.transform;
                    activePlatforms.Add(platform);
                }

                if (element >= 2 && element <= obstaclePrefabs.Length + 1)
                {
                    Vector3 obstaclePosition = lanePosition + new Vector3(0, 0.5f, 0);

                    GameObject obstacle = Instantiate(obstaclePrefabs[element - 2], obstaclePosition, Quaternion.identity);
                    ObstacleMovement obstacleMovement = obstacle.GetComponent<ObstacleMovement>();
                    obstacleMovement.InitialPosition = obstaclePosition;

                    activeObstacles.Add(obstacle);
                }
            }
        }

        spawnPosition += new Vector3(0, 0, platformLength);
        lastGeneratedZ = spawnPosition.z;
    }

    private void GenerateChunk()
    {
        for (int i = 0; i < platformsPerChunk; i++)
        {
            GenerateRowOfPlatforms();
        }
    }

    private void GenerateObstaclesForRow(Vector3 rowSpawnPosition)
    {
        float platformWidth = GetPrefabWidth(platformPrefab);

        int obstaclesCount = 0;
        int maxObstacles = 3;

        if (preventSpawnObstacle > 0)
        {
            preventSpawnObstacle--;
            return;
        }

        for (int lane = -5; lane <= 5; lane++)
        {
            if (Random.Range(0, 5) == 0)
            {
                if (obstaclesCount >= maxObstacles)
                {
                    break;
                }

                Vector3 obstaclePosition = rowSpawnPosition + new Vector3(lane * platformWidth, 0.5f, 0);

                GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
                GameObject obstacle = Instantiate(obstaclePrefab, obstaclePosition, Quaternion.identity);

                ObstacleMovement obstacleMovement = obstacle.GetComponent<ObstacleMovement>();
                obstacleMovement.InitialPosition = obstaclePosition;

                activeObstacles.Add(obstacle);

                obstaclesCount++;
                lane += 4;
                preventSpawnObstacle = 2;
            }
        }
    }

    private void GenerateRowOfPlatforms()
    {
        float platformLength = GetPrefabLength(platformPrefab);
        float platformWidth = GetPrefabWidth(platformPrefab);

        bool hasJumpingPlatform = false;

        if (rowToSpawnAtStart) {
            for (int i = 0; i < 6; ++i)
            {
                for (int lane = -5; lane <= 5; lane++)
                {
                    Vector3 lanePosition = spawnPosition + new Vector3(lane * platformWidth, -0.25f, 0);

                    GameObject platform = Instantiate(platformPrefab, lanePosition, Quaternion.identity);
                    platform.transform.parent = this.transform;
                    activePlatforms.Add(platform);
                }
                spawnPosition += new Vector3(0, 0, platformLength);
                lastGeneratedZ = spawnPosition.z;
            }
            rowToSpawnAtStart = false;
            return;
        }

        if (skipNextRows)
        {
            rowsToSkip--;
            spawnPosition += new Vector3(0, 0, platformLength);
            if (rowsToSkip <= 0)
            {
                skipNextRows = false;
            }
            return;
        }

        Vector3 rowSpawnPosition = spawnPosition;

        if (preventSpawnJumping > 0)
        {
            for (int lane = -5; lane <= 5; lane++)
            {
                Vector3 lanePosition = spawnPosition + new Vector3(lane * platformWidth, -0.25f, 0);

                GameObject platform = Instantiate(platformPrefab, lanePosition, Quaternion.identity);
                platform.transform.parent = this.transform;
                activePlatforms.Add(platform);
            }
            preventSpawnJumping--;
        }
        else
        {
            for (int lane = -5; lane <= 5; lane++)
            {
                Vector3 lanePosition = spawnPosition + new Vector3(lane * platformWidth, -0.25f, 0);

                int random = Random.Range(0, 5);
                GameObject platform;

                if (random < 3)
                {
                    platform = Instantiate(platformPrefab, lanePosition, Quaternion.identity);
                }
                else
                {
                    platform = Instantiate(jumpingPlatformPrefab, lanePosition, Quaternion.identity);
                    skipNextRows = true;
                    hasJumpingPlatform = true;
                    rowsToSkip = 5;
                    preventSpawnJumping = 7;
                }

                platform.transform.parent = this.transform;
                activePlatforms.Add(platform);
            }
        }

        if (!hasJumpingPlatform)
        {
            GenerateObstaclesForRow(rowSpawnPosition);
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

    public float GetLastGeneratedZ()
    {
        return lastGeneratedZ;
    }
}
