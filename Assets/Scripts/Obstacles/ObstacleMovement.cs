using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleMovement : MonoBehaviour
{
    [Header("Initial Attributes")]
    public Vector3 InitialDirection;
    public Vector3 InitialPosition;

    [Header("Spinning")]
    public bool isSpinning = false;
    public Vector3 SpinSpeed;

    [Header("GoStraight")]
    public bool isGoingStraight = false;
    public Vector3 Movement;

    [Header("HorizontalMotion")]
    public bool isMovingHorizontally = false;
    public float HorizontalRange = 0;
    public float HorizontalSpeed = 0;
    public float HAngle = 0;

    [Header("VerticalMotion")]
    public bool isMovingVertically = false;
    public float VerticalRange = 0;
    public float VerticalSpeed = 0;
    public float VAngle = 0;

    // Start is called before the first frame update

    void SpinAround()
    {
        transform.Rotate(SpinSpeed * Time.deltaTime);
    }
    void GoStraight()
    {
        transform.position += Movement * Time.deltaTime;
    }
    void DoHorizontalMotion()
    {
        HAngle += HorizontalSpeed * Time.deltaTime;
        transform.position = InitialPosition + new Vector3(Mathf.Cos(HAngle + 1f) * HorizontalRange, 0, 0);
    }
    void DoVerticalMotion()
    {
        VAngle += VerticalSpeed * Time.deltaTime;
        transform.position = InitialPosition + new Vector3(0, Mathf.Sin(VAngle) * VerticalRange, 0);
    }

    private void Start()
    {
        transform.position = InitialPosition;
        transform.rotation = Quaternion.Euler(InitialDirection.x, InitialDirection.y, InitialDirection.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpinning) SpinAround();
        if (isGoingStraight) GoStraight();
        if (isMovingHorizontally) DoHorizontalMotion();
        if (isMovingVertically) DoVerticalMotion();
    }
}
