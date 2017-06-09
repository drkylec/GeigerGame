/*
COPYRIGHT Kyle Crombie 2016
This Scirpt was written for a College Capstone Project.
All rights reserved.
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour {

    public Text loadingProgress;
    public Text pressButton;
    public string level;
    private string progress = "Geiger";    // Name of scene to load.
    private bool isLoading = false;
    private bool doneLoading = false;
    private bool doneLoading2 = false;
    private bool allowLoading = false;
    private bool finishedLoading = false;

    // Use this for initialization
    void Start () {
        //SceneManager.LoadScene("Level_One");
        loadingProgress.text = "Progress: 0";
        pressButton.text = "";
    }

    void Update()
    {
        if (!isLoading)
        {
            //if (GUILayout.Button("Begin Load"))
            //{
                isLoading = true;
                StartCoroutine(LoadRoutine());
            //}
        }
        if (doneLoading)
        {
            //if (GUILayout.Button("Actually Load"))
            //{
            allowLoading = true;
            StartCoroutine(LoadRoutine());
            //}
        }
        if (doneLoading2)
        {
            if(Input.GetKeyDown(KeyCode.Return) || (Input.GetButtonDown("A")))
            {
                finishedLoading = true;
            }
        }

        if (doneLoading2)
        {
            //GUILayout.Label("Press Buttone");
            pressButton.text = "Press Enter or A \nto Continue";
        }
        loadingProgress.text = progress;
    }
    //private void OnGUI()
    //{
        //GUILayout.BeginVertical("box");
        //if (!isLoading)
        //{
            //if (GUILayout.Button("Begin Load"))
            //{
                //isLoading = true;
                //StartCoroutine(LoadRoutine());
            //}
        //}
        //else
        //{
            //if (doneLoading)
           // {
                //if (GUILayout.Button("Actually Load"))
                //{
                    //allowLoading = true;
                    //StartCoroutine(LoadRoutine());
                //}
            //}

            //if(doneLoading2)
            //{
            //    GUILayout.Label("Press Buttone");
            //}
            //GUILayout.Label(progress);
        //}

        //GUILayout.EndVertical();
    //}
    private IEnumerator LoadRoutine()
    {
        AsyncOperation op = Application.LoadLevelAsync(level);
        op.allowSceneActivation = false;
        while (op.progress < 0.9f)
        {
            // Report progress etc.
            progress = "Progress: " + op.progress.ToString();
            yield return null;
        }
        // Show the UI button to actually start loaded level
        doneLoading = true;
        while (!allowLoading)
        {
            // Wait for allow button to be pushed.
            progress = "Progress: " + op.progress.ToString();
            yield return null;
        }

        
        //if(op.progress >= 0.9f)
        //{
            doneLoading2 = true; 
            //yield return null;
        //}
        while (!finishedLoading)
        {
            op.allowSceneActivation = false;
            yield return null;
        }
        // Allow the activation of the scene again.
        op.allowSceneActivation = true;
    }
}
