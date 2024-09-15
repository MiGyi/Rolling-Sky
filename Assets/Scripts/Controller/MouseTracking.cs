using Unity.VisualScripting;
using UnityEngine;

public class MouseTracking : MonoBehaviour
{
    [SerializeField] Camera mainCamera = null;
    private GameObject player = null;
    
    private float yPosition = Screen.height / 2f;
    public float depthValue = 12.0f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        // Check if the main camera is not set in the inspector
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        // Check if the player is not found
        if (player == null)
        {
            Debug.LogError("Player not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (mainCamera != null && player != null)
        {
            Vector3 playerToCamera = player.transform.position - mainCamera.transform.position;
            yPosition = mainCamera.WorldToScreenPoint(player.transform.position).y;

            depthValue = playerToCamera.magnitude;
            
        }
    }

    public float getXValue()    {

        if (mainCamera != null && player != null)
        {
            Vector3 mousePosition = Input.mousePosition;

            // Set y position to the center of the screen
            mousePosition.y = yPosition;

            // Set the depth value to the distance between the player and the camera
            mousePosition.z = depthValue;

            // Convert the mouse position to world position
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            // Debug.Log("world position: " + worldPosition);
            
            return worldPosition.x;
        }

        return 0f;
    }
}
