using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DocumentTextScript : MonoBehaviour
{

    public Text buttonPress;
    public string textKeyboard;
    public string textController;
    public static bool pickedUp;
    public static bool enableded;

    //public KeyCollect keyCollect;

    public enum ControllerState { keyboard, controller };

    // Use this for initialization
    void Start()
    {
        //keyCollect = GameObject.FindObjectOfType(typeof(KeyCollect)) as KeyCollect;

        //buttonPress = GameObject.Find("KeyPress"+this.keyCollect.keyNumber).GetComponent<Text>();

        buttonPress.enabled = false;
        pickedUp = false;
        enableded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(enableded)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        if (Input.GetAxis("Horizontal") != 0 || (Input.GetAxis("Vertical")) != 0)
        {
            buttonPress.text = textKeyboard;
        }

        if (Input.GetAxis("LeftJoystickX") != 0 || (Input.GetAxis("LeftJoystickY")) != 0)
        {
            buttonPress.text = textController;
        }

        if (pickedUp)
        {
            buttonPress.enabled = true; 
        }
        else
        {
            buttonPress.enabled = false;
        }

    }
}
