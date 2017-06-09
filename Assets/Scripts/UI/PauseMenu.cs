using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class PauseMenu : MonoBehaviour {

    public GameObject playerObject;
    public CameraScript cameraScript;
    public WalkingScript walkingScript;
    public Flashlight flashlight;
    public ButtonStuff bs;
    public PlayerFilterLevel pfl;
    public PlayerRadiationLevel prl;
    public Collectable collectable;

    public GameObject canvasPause;
    public GameObject objective;
    private bool paused;
    private bool pausedObj;

    public Blur blur;

    private float fakeTimer = 0;
    private float fakeTimerMax = 1.0f;

    public CursorLockMode wantedMode;
    public bool lockCursor;


    // Use this for initialization
    void Start () {
        cameraScript = GameObject.FindObjectOfType(typeof(CameraScript)) as CameraScript;
        walkingScript = GameObject.FindObjectOfType(typeof(WalkingScript)) as WalkingScript;
        flashlight = GameObject.FindObjectOfType(typeof(Flashlight)) as Flashlight;
        bs = GameObject.FindObjectOfType(typeof(ButtonStuff)) as ButtonStuff;
        pfl = GameObject.FindObjectOfType(typeof(PlayerFilterLevel)) as PlayerFilterLevel;
        prl = GameObject.FindObjectOfType(typeof(PlayerRadiationLevel)) as PlayerRadiationLevel;
        collectable = GameObject.FindObjectOfType(typeof(Collectable)) as Collectable;
        blur = GameObject.FindObjectOfType(typeof(Blur)) as Blur;
        paused = false;
        pausedObj = false;
        canvasPause.SetActive(paused);
        objective.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        //get the input and disable/enable the pause menu
        if (!collectable.collected)
        {
            if (Input.GetKey(KeyCode.Escape) || (Input.GetButtonDown("StartButton")))
            {
                if (fakeTimer >= fakeTimerMax)
                {
                    fakeTimer = 0;
                    paused = !paused;

                    if (bs.objective)
                    {
                        bs.objective = false;
                    }

                    if (!paused)
                    {
                        flashlight.IsON = true;
                    }
                }
            }
            if (Input.GetKey(KeyCode.Tab) || (Input.GetButtonDown("SelectButton")))
            {
                if (fakeTimer >= fakeTimerMax)
                {
                    fakeTimer = 0;
                    pausedObj = !pausedObj;

                    //if (bs.objective)
                    //{
                        //bs.objective = false;
                    //}

                    if (!pausedObj)
                    {
                        flashlight.IsON = true;
                    }
                }
            }
        }
        SetCursorState();
        ShowPause();
        HidePause();
        ShowObj();
        HideObj();

        if(bs.objective)
        {
            canvasPause.SetActive(false);
            objective.SetActive(true);
        }
        else
        {
            //canvasPause.SetActive(false);
            //objective.SetActive(true);
        }

        fakeTimer += Time.deltaTime;
	}

    //when enabled show the pause menu and disable everything else in the game
    void ShowPause()
    {
        if(paused)
        {
            prl.paused = true;
            pfl.paused = true;
            cameraScript.CanMove = false;
            walkingScript.CanMove = false;
            flashlight.IsON = false;
            canvasPause.SetActive(true);
            blur.enabled = true;
            blur.blurSpread = 0.6f;
            blur.iterations = 2;
        }
    }

    //when disabled hide the menu and enable everything in the game.
    void HidePause()
    {
        if (!paused)
        {
            prl.paused = false;
            pfl.paused = false;
            cameraScript.CanMove = true;
            walkingScript.CanMove = true;
            //flashlight.IsON = true;
            canvasPause.SetActive(false);
            objective.SetActive(false);
            blur.enabled = false;
            blur.blurSpread = 0.0f;
            blur.iterations = 0;
        }
    }

    //when enabled show the objective menu and disable everything else in the game
    void ShowObj()
    {
        if (pausedObj)
        {
            prl.paused = true;
            pfl.paused = true;
            cameraScript.CanMove = false;
            walkingScript.CanMove = false;
            flashlight.IsON = false;
            objective.SetActive(true);
            blur.enabled = true;
            blur.blurSpread = 0.6f;
            blur.iterations = 2;
        }
    }

    //when disabled hide the Objective and enable everything in the game.
    void HideObj()
    {
        if (!pausedObj)
        {
            prl.paused = false;
            pfl.paused = false;
            cameraScript.CanMove = true;
            walkingScript.CanMove = true;
            //flashlight.IsON = true;
            canvasPause.SetActive(false);
            objective.SetActive(false);
            blur.enabled = false;
            blur.blurSpread = 0.0f;
            blur.iterations = 0;
        }
    }

    public void PauseStuff(bool pause)
    {
        paused = pause;
    }

    void SetCursorState()
    {
        Cursor.lockState = wantedMode;
        // Hide cursor when locking
        wantedMode = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
