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
    [SerializeField] private float jumpingForce = 5.0f;

    [Header("Threshold")]
    [SerializeField] private float threshold = 0.5f;

    private bool isPlayable = false;

    private KeyboardController keyboardController = null;
    private MouseTracking mouseTracking = null;

    void Awake()
    {
        GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");

        // check if GameManager is found    
        if( gameManager != null )
        {
            keyboardController = gameManager.GetComponent<KeyboardController>();
            mouseTracking = gameManager.GetComponent<MouseTracking>();

            // check if KeyboardController is found
            if( keyboardController == null )
            {
                Debug.LogError("KeyboardController not found");
            }

            // check if MouseTracking is found
            if( mouseTracking == null )
            {
                Debug.LogError("MouseTracking not found");
            }
        }
        else {
            Debug.LogError("GameManager not found");
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isPlayable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if( keyboardController == null || mouseTracking == null ) return;
        if (!keyboardController.inGame || !isPlayable) return;                                                         // if not in game, abort

        // Move the ball forward
        AutoMoveForward();
    }

    void FixedUpdate()
    {
        if( transform.position.y < threshold )
        {
            isPlayable = false;
        }

        if (keyboardController == null || mouseTracking == null) return;
        if (!keyboardController.inGame || !isPlayable) return;                                                         // if not in game, abort

        // Move the ball to the mouse position
        MouseFollowed();
    }

    private void MouseFollowed()
    {
        if( keyboardController == null || mouseTracking == null ) return;
        if (!keyboardController.inGame || !isPlayable) return;                                                         // if not in game, abort

        float xValue = mouseTracking.getXValue();                                                       // get the z value from the mouse position
        transform.position = new(xValue, transform.position.y, transform.position.z);                   // move the ball to the target position
    }

    private void AutoMoveForward()
    {
        if( keyboardController == null ) return;
        if (!keyboardController.inGame || !isPlayable) return;                                                         // if not in game, abort

        // Auto run forward with speed increase over time
        rb.velocity = new Vector3(0, 0, speed);
        speed += Time.deltaTime * deltaSpeed;
    }
}
