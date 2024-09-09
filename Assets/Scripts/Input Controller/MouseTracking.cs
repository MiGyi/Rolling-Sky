using Unity.VisualScripting;
using UnityEngine;

public class MouseTracking : MonoBehaviour
{
    [SerializeField] Camera mainCamera = null;
    private float yPosition = Screen.height / 2f;
    private float depthValue = 12.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if( mainCamera != null )
        {
            Vector3 playerToCamera = transform.position - mainCamera.transform.position;
            yPosition = mainCamera.WorldToScreenPoint(transform.position).y;

            depthValue = playerToCamera.magnitude;
        }
    }

    public float getZValue()    {

        if (mainCamera != null)
        {
            Vector3 mousePosition = Input.mousePosition;

            // Set y position to the center of the screen
            mousePosition.y = yPosition;

            // Set the depth value to the distance between the player and the camera

            mousePosition.z = depthValue;

            // Convert the mouse position to world position
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

            return worldPosition.z;
        }

        return 0f;
    }
}
