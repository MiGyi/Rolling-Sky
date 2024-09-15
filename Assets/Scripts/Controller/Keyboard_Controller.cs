using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{

    public bool inGame = false;
    private bool controlMouse = false; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.P) )
        {
            Debug.Log("P is pressed");
        }

        if( controlMouse )
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            controlMouse = false;
        }

        if (!inGame && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space is pressed");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
            inGame = true;
            controlMouse = true;
        }
    }
}
