/*
COPYRIGHT Kyle Crombie 2016
This Scirpt was written for a College Capstone Project.
All rights reserved.
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ButtonStuff : MonoBehaviour {

    public GameObject temp;
    public CameraScript cameraScript;
    public WalkingScript walkingScript;
    public Flashlight flashlight;
    public Collectable collectable;
    public PauseMenu pauseMenu;

    public GameObject resume;
    public GameObject play;

    //for the objective pause menu
    public bool objective = false;

    //public static void LoadScene(int sceneBuildIndex, SceneManagement.LoadSceneMode mode = LoadSceneMode.Single);

    // Use this for initialization
    void Start () {
        cameraScript = GameObject.FindObjectOfType(typeof(CameraScript)) as CameraScript;
        walkingScript = GameObject.FindObjectOfType(typeof(WalkingScript)) as WalkingScript;
        flashlight = GameObject.FindObjectOfType(typeof(Flashlight)) as Flashlight;
        collectable = GameObject.FindObjectOfType(typeof(Collectable)) as Collectable;
        pauseMenu = GameObject.FindObjectOfType(typeof(PauseMenu)) as PauseMenu;

        resume = GameObject.Find("Resume");
        play = GameObject.Find("Play");
        //resume = Button.FindObjectOfType<Button>();

    }

    public void Click()
    {
        cameraScript.CanMove = true;
        walkingScript.CanMove = true;
        flashlight.IsON = true;
        //collectable.Destroyer();
        Destroy(this.temp);
    }

    void Update()
    {
        
    }

    public void ClickStart()
    {
        EventSystem.current.SetSelectedGameObject(play.gameObject, new BaseEventData(EventSystem.current));
        //SceneManager.LoadScene(SceneManager.LoadScene(1));
        SceneManager.LoadScene("LoadingScreen");
    }

    public void ClickCredits()
    {
        SceneManager.LoadScene("CreditsScreen");
    }

    public void ClickExit()
    {
        Application.Quit();
    }

    public void ClickMain()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void ClickResume()
    {
        EventSystem.current.SetSelectedGameObject(resume.gameObject, new BaseEventData(EventSystem.current));
        pauseMenu.PauseStuff(false);
        flashlight.IsON = true;
    }

    public void ClickObjective()
    {
        objective = true;
        //pauseMenu.canvasPause.SetActive(false);
        //pauseMenu.objective.SetActive(true);
    }

    public void ClickQuit()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
