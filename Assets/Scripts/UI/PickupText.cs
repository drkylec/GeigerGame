using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickupText : MonoBehaviour {

    public Text buttonPress;
    public string collectKeyboard;
    public string collectController;

    //public KeyCollect keyCollect;

    // Use this for initialization
    void Start () {
        //keyCollect = GameObject.FindObjectOfType(typeof(KeyCollect)) as KeyCollect;

        //buttonPress = GameObject.Find("KeyPress"+this.keyCollect.keyNumber).GetComponent<Text>();

        buttonPress.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetAxis("Horizontal") != 0 || (Input.GetAxis("Vertical")) != 0)
        {
            buttonPress.text = collectKeyboard;
        }
        if (Input.GetAxis("LeftJoystickX") != 0 || (Input.GetAxis("LeftJoystickY")) != 0)
        {
            buttonPress.text = collectController;
        }

    }

    void OnTriggerStay(Collider col)
    {
        buttonPress.enabled = true;
    }

    void OnTriggerExit(Collider col)
    {
        buttonPress.enabled = false;
    }
}
