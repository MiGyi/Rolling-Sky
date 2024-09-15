using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour
{
    public GameObject player;

    public bool isTesting = true;
    public bool isFollowing = true;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 4, -10);
    }

    public void ToggleFollowing() {
        isFollowing = !isFollowing;
        if (isFollowing) {
            offset = new Vector3(0, 4, -10);
            transform.rotation = Quaternion.Euler(30, 0, 0);
        }
    }
    // Update is called once per frame
    void Update()
    {   
        if (isTesting) {
            if (isFollowing) {
                transform.position = player.transform.position + offset;
            }
        }
        
    }
}
