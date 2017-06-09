using UnityEngine;
using System.Collections;

public class ShowCursor : MonoBehaviour {

    public CursorLockMode wantedMode;
    public bool lockCursor;

    // Use this for initialization
    void Start () {
	
	}

    void SetCursorState()
    {
        Cursor.lockState = wantedMode;
        // Hide cursor when locking
        wantedMode = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update () {

        SetCursorState();

    }
}
