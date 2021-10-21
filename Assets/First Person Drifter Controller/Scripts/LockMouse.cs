﻿// by @torahhorse

using UnityEngine;
using System.Collections;

public class LockMouse : MonoBehaviour
{	
    public bool state = false;

    void Update()
    {
    	// lock when mouse is clicked
    	if( Input.GetMouseButtonDown(0) && Time.timeScale > 0.0f )
    	{
    		Cursor.lockState = CursorLockMode.Locked;

            state = true;
    	}
    
    	// unlock when escape is hit
        if  ( Input.GetKeyDown(KeyCode.Escape) )
        {
        	Cursor.lockState = CursorLockMode.None;
            state = false;
        }
    }

}