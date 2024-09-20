using System;
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
    [SerializeField] private float maxSpeed = 15.0f; 
    [SerializeField] private float deltaSpeed = 0.05f;
    [SerializeField] private float jumpingForce = 5.0f;
    [SerializeField] private float minimumJumpingForce = 5.0f;

    [SerializeField] private float initialJumpingForce = 5.0f;
    [SerializeField] private ParticleSystem explosionEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public float GetCurrentSpeed()
    {
        return speed;
    }
    public bool IsFalling() {
        return transform.position.y < -10.0f;
    }
    public void StartJumping()
    {
        Vector3 velocity = rb.velocity;
        velocity.y = initialJumpingForce;
        rb.velocity = velocity;
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

        // Update speed
        UpdateSpeed();
    }

    private void UpdateSpeed()
    {
        if (speed < maxSpeed) speed += Time.deltaTime * deltaSpeed;
        if (jumpingForce > minimumJumpingForce ) jumpingForce -= Time.deltaTime * deltaSpeed / 4.0f;
    }

    public void StartGravity()
    {
        rb.useGravity = true;
    }
}
