using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallCamera : MonoBehaviour
{
    public GameObject Ball;
    public Vector3 offset = new Vector3(0, 8, -10);
    public float CameraVerticalRotation = 30;
    public float MaximumHorizontalCameraRange = 6;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(CameraVerticalRotation, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //float yPos = Ball.transform.position.y;
        float yPos = 0;
        float zPos = Ball.transform.position.z;
        float xPos = Ball.transform.position.x / 2f;

        if (xPos < 0) xPos = Mathf.Max(xPos, -MaximumHorizontalCameraRange);
        else xPos = Mathf.Min(xPos, MaximumHorizontalCameraRange);

        offset.x = xPos;

        transform.position = new Vector3(0, yPos, zPos) + offset;
    }
}
