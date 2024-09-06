using UnityEngine;

public class MouseTracking : MonoBehaviour
{
    [SerializeField] private Camera mainCamera = null;
    public float depthValue = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamera != null)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = depthValue;
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            transform.position = worldPosition;
            Debug.Log("Mouse Position: " + worldPosition);
        }
    }
}
