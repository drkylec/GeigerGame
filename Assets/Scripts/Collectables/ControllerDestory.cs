using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControllerDestory : MonoBehaviour {

    //public GameObject temp;
    public CameraScript cameraScript;
    public WalkingScript walkingScript;
    public Flashlight flashlight;
    public Collectable collectable;
    public Image[] paper;
    public Text text;
    public string textKeyboard;
    public string textController;

    // Use this for initialization
    void Start () {
        cameraScript = GameObject.FindObjectOfType(typeof(CameraScript)) as CameraScript;
        walkingScript = GameObject.FindObjectOfType(typeof(WalkingScript)) as WalkingScript;
        flashlight = GameObject.FindObjectOfType(typeof(Flashlight)) as Flashlight;
        collectable = GameObject.FindObjectOfType(typeof(Collectable)) as Collectable;
        paper[0] = GameObject.Find("Document0").GetComponent<Image>();
        paper[1] = GameObject.Find("Document1").GetComponent<Image>();
        paper[2] = GameObject.Find("Document2").GetComponent<Image>();

        text = GameObject.Find("PressQorA").GetComponent<Text>();

        paper[0].enabled = false;
        paper[1].enabled = false;
        paper[2].enabled = false;


    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetAxis("Vertical") != 0 || (Input.GetAxis("Horizontal")) != 0)
        {
            text.text = textKeyboard;
        }
        if (Input.GetAxis("LeftJoystickX") != 0 || (Input.GetAxis("LeftJoystickY")) != 0)
        {
            text.text = textController;
        }

        if (Input.GetButtonDown("A") || (Input.GetKeyDown(KeyCode.Q)))
        {
            collectable.collected = false;
            cameraScript.CanMove = true;
            walkingScript.CanMove = true;
            flashlight.IsON = true;
            //Destroy(this.gameObject);
            paper[0].enabled = false;
            paper[1].enabled = false;
            paper[2].enabled = false;
            text.enabled = false;
        }

	}
}
