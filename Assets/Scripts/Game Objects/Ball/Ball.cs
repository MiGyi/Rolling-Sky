using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    
    // Header for the serialized fields
    [Header("Ball Movement")]
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float deltaSpeed = 0.05f;
    [SerializeField] private float jumpingForce = 100.0f;

    [Header("Threshold")]
    [SerializeField] private float threshold = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public bool IsFalling() {
        return transform.position.y < -10.0f;
    }
    public void FollowMousePosition(Vector3 mousePosition)
    {
        Vector3 worldHorizontalPosition = GetWorldPosition(mousePosition);                                                       
        transform.position = new Vector3(worldHorizontalPosition.x, transform.position.y, transform.position.z);
    }

    private Vector3 GetWorldPosition(Vector3 mousePosition) {
            Camera mainCamera = Camera.main;

            mousePosition.y = transform.position.y;

            Vector3 playerToCamera = transform.position - mainCamera.transform.position;
            mousePosition.z = playerToCamera.magnitude;

            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            return worldPosition;
    }
    public void Jump()
    {
        Vector3 velocity = rb.velocity;
        velocity.y = jumpingForce;
        rb.velocity = velocity;
    }
    public void AutoMoveForward()
    {
        // Auto run forward with speed increase over time
        Vector3 velocity = rb.velocity;
        velocity.z = speed;
        rb.velocity = velocity;
        speed += Time.deltaTime * deltaSpeed;
    }
}
