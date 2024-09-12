using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManagerLevel1 : MonoBehaviour
{
    public GameObject platformPrefab;  // Platform prefab to instantiate
    public GameObject obstaclePrefab;  // Obstacle prefab to instantiate

    public int numberOfPlatforms = 10;  // Number of platforms to generate
    public float platformLength = 5.0f;  // Length of each platform
    public float obstacleFrequency = 0.3f;  // Chance to spawn an obstacle
    public float gapFrequency = 0.1f;  // Chance to create a gap between platforms

    private Vector3 spawnPosition = new Vector3(0, 0, 0);  // Starting point for platforms
    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }

    // Method to generate the map based on the input
    void GenerateMap()
    {
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            // Random chance to create a gap
            if (Random.value > gapFrequency)
            {
                // Instantiate a new platform
                GameObject platform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);

                // Random chance to spawn an obstacle on the platform
                if (Random.value < obstacleFrequency)
                {
                    // Calculate the obstacle position
                    Vector3 obstaclePosition = spawnPosition + new Vector3(0, 1, 0);  // Adjust y-axis if needed
                    Instantiate(obstaclePrefab, obstaclePosition, Quaternion.identity);
                }

                // Move the spawn position forward for the next platform
                spawnPosition += new Vector3(0, 0, platformLength);
            }
            else
            {
                // If a gap is created, skip to the next position
                spawnPosition += new Vector3(0, 0, platformLength);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
