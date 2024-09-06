using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 10.0f;
    public float jumpingForce = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(Horizontal, 0, Vertical);
        Vector3 velocity = rb.velocity;
        velocity.x = direction.x * speed;
        velocity.z = direction.z * speed;
        rb.velocity = velocity;

        // press space to jump
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpingForce, ForceMode.Impulse);
        }
    }
}
