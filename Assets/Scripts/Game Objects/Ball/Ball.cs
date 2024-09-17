using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    
    // Header for the serialized fields
    [Header("Ball Movement")]
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float deltaSpeed = 0.05f;
    [SerializeField] private float jumpingForce = 5.0f;
    [SerializeField] private ParticleSystem explosionEffect;

    [Header("Threshold")]
    [SerializeField] private float threshold = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public float GetCurrentSpeed()
    {
        return speed;
    }
    public bool IsFalling() {
        return rb.velocity.y < -5.0f;
    }

    public void Explode()
    {
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
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
    public void AutoMoveForward()
    {
        // Auto run forward with speed increase over time
        rb.velocity = new Vector3(0, 0, speed);
        Debug.Log("Speed: " + rb.velocity.z);
        speed += Time.deltaTime * deltaSpeed;
    }
}
