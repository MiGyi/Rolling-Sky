using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("References")]
    public GameObject platformPrefab;  // Reference to the platform prefab
    public Transform player;           // Reference to the player's transform (the ball)

    [Header("Map Settings")]
    public float platformLength = 5.0f;  // Length of each platform
    public float laneSpacing = 2.0f;    // Distance between lanes
    public int platformsPerChunk = 10;  // Number of platforms to generate in each chunk
    public float generationDistanceAhead = 50.0f;  // Distance ahead of the player to generate platforms
    public float maxDistanceBehind = 20.0f;  // Maximum distance behind the player to keep platforms

    private Vector3 spawnPosition = Vector3.zero;  // Position where the next chunk of platforms will spawn
    private List<GameObject> activePlatforms = new List<GameObject>();  // Keep track of active platforms
    private float lastGeneratedZ = 0;  // The Z-position of the last generated platform

    // Start is called before the first frame update
    private void Start()
    {
        spawnPosition = Vector3.zero;  // Initialize spawn position at the start
        GenerateInitialPlatforms();    // Generate the initial platforms at the start
    }

    // Update is called once per frame
    private void Update()
    {
        // Check if the player is getting close to the last generated platform
        if (player.position.z + generationDistanceAhead > lastGeneratedZ)
        {
            GenerateChunk();  // Generate a new chunk of platforms
        }

        // Check and remove platforms that are too far behind the player
        RemoveOldPlatforms();
    }

    // Generate initial platforms at the start of the game
    private void GenerateInitialPlatforms()
    {
        for (int i = 0; i < platformsPerChunk; i++)
        {
            GenerateRowOfPlatforms();
        }
    }

    // Generate a new chunk of platforms
    private void GenerateChunk()
    {
        for (int i = 0; i < platformsPerChunk; i++)
        {
            GenerateRowOfPlatforms();
        }
    }

    // Generate a row of platforms in the three lanes
    private void GenerateRowOfPlatforms()
    {
        // Loop through the 11 lanes (left, center, right)
        for (int lane = -5; lane <= 5; lane++)
        {
            // Calculate lane position by adjusting X based on the lane
            Vector3 lanePosition = spawnPosition + new Vector3(lane * laneSpacing, 0, 0);

            // Instantiate the platform in the current lane
            GameObject platform = Instantiate(platformPrefab, lanePosition, Quaternion.identity);

            // Set the Map GameObject as the parent of the platform
            platform.transform.parent = this.transform;

            // Add the platform to the list of active platforms
            activePlatforms.Add(platform);
        }

        // Update the spawn position for the next row of platforms
        spawnPosition += new Vector3(0, 0, platformLength);
        lastGeneratedZ = spawnPosition.z;  // Update the Z-position of the last generated platform
    }

    // Remove platforms that are too far behind the player
    private void RemoveOldPlatforms()
    {
        // Iterate through the list of active platforms
        for (int i = activePlatforms.Count - 1; i >= 0; i--)
        {
            GameObject platform = activePlatforms[i];
            if (platform.transform.position.z < player.position.z - maxDistanceBehind)
            {
                // Remove the platform from the list and destroy it
                activePlatforms.RemoveAt(i);
                Destroy(platform);
            }
        }
    }
}
