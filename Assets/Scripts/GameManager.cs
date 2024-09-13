using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject player = null;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if( player == null ) return;
        if( player.transform.position.y < -5.0f )
        {
            Time.timeScale = 0.0f;
        }
    }
}
