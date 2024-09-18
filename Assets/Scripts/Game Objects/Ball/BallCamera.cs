using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallCamera : MonoBehaviour
{
    public GameObject ball;
    public Vector3 offset = new Vector3(0, 8, -10);
    public float CameraVerticalRotation = 30;
    public float MaximumHorizontalCameraRange = 6;
    public float originalVelocity;
    public float reduceSpeed = 100f;
    private float shakeDuration = 0;
    public float shakeAmount = 1f;

    public Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(CameraVerticalRotation, 0, 0);
    }
    public void HandleLose()
    {
        shakeDuration = 0.5f;
        originalPos = ball.transform.position;
        originalVelocity = ball.GetComponent<Ball>().GetCurrentSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        //float yPos = Ball.transform.position.y;
        if (originalVelocity > 0)
        {
            float yPos = 0;
            float zPos = originalPos.z;
            float xPos = originalPos.x / 2f;
            if (xPos < 0) xPos = Mathf.Max(xPos, -MaximumHorizontalCameraRange);
            else xPos = Mathf.Min(xPos, MaximumHorizontalCameraRange);
            offset.x = xPos;
            transform.position = new Vector3(0, yPos, zPos) + offset + (shakeDuration > 0 ? Random.insideUnitSphere * shakeAmount : Vector3.zero);
            originalPos += new Vector3(0, 0, originalVelocity) * Time.deltaTime;
            originalVelocity -= reduceSpeed * Time.deltaTime;
            Debug.Log(originalVelocity);
            shakeDuration -= Time.deltaTime;
        }
        else
        {
            if (ball == null) return;
            float yPos = 0;
            float zPos = ball.transform.position.z;
            float xPos = ball.transform.position.x / 2f;

            if (xPos < 0) xPos = Mathf.Max(xPos, -MaximumHorizontalCameraRange);
            else xPos = Mathf.Min(xPos, MaximumHorizontalCameraRange);

            offset.x = xPos;
            transform.position = new Vector3(0, yPos, zPos) + offset;
        }

    }
}
