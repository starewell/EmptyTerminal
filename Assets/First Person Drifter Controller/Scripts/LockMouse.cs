// by @torahhorse

using UnityEngine;
using System.Collections;

public class LockMouse : MonoBehaviour
{	
    public bool state = false;

    void Update()
    {
    	// lock when mouse is clicked
    	if(Input.GetMouseButtonDown(0) && Time.timeScale > 0.0f ) {
    		MouseLock();
    	}
    
    	// unlock when escape is hit
        if (Input.GetKeyDown(KeyCode.Escape)) {
        	MouseUnlock();
        }
    }

    public void MouseLock() {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void MouseUnlock() {
        Cursor.lockState = CursorLockMode.None;
    }
    public void ToggleLock() {       
        if (Cursor.lockState == CursorLockMode.None) Cursor.lockState = CursorLockMode.Locked;
        else if (Cursor.lockState == CursorLockMode.Locked) Cursor.lockState = CursorLockMode.None;
        Debug.Log("ToggleLock");
    }

}