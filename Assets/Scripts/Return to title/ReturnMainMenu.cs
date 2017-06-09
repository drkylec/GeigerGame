using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReturnMainMenu : MonoBehaviour {

    public float wait;
    private float waitTime;

	// Use this for initialization
	void Start () {
        wait = 0;
        waitTime = 10;
	}
	
	// Update is called once per frame
	void Update () {
        if((wait >= waitTime)||(Input.GetMouseButton(0)))
        {
            SceneManager.LoadScene("TitleScreen");
        }
        wait += Time.deltaTime;
	}
}
