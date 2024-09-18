using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlatform : MonoBehaviour
{
    bool isJumping = false;
    private void OnCollisionEnter(Collision other) {
        if (isJumping) {
            return;
        }
        if (other.gameObject.GetComponent<Ball>() != null) {
            isJumping = true;
            other.gameObject.GetComponent<Ball>().Jump();
        }
    }
}
