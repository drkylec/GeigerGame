/*
COPYRIGHT Kyle Crombie 2016
This Scirpt was written for a College Capstone Project.
All rights reserved.
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour {
    #region Variables
    public bool canMove = true;

    public float rotSpeed; // rotate speed in degrees/second loads in through xml file
    public Transform player;
    public Transform lookAtTarget;
    public Vector3 playerPos = Vector3.zero;
    //public float distance = 1.66f;
    //public float hight = 0.10f;
    //public float depth = 1.24f;
    //private float distanceDefault = 1.66f;
    //private float hightDefault = 0.10f;
    //private float depthDefault = 1.24f;

    //rays
    public float rayLength;
    private Vector3 rayLeft;
    private Vector3 rayRight;
    private Vector3 rayBack;
    private Vector3 rayFront;
    public float collisionOffset = 0.5f;
    Ray rayL;
    Ray rayR;
    Ray rayB;
    Ray rayF;
    RaycastHit hit;
    public GameObject camDefaultPos;

    public Vector3 offset;
    private Vector3 defaultOffset;
    public float offsetX = 0.5f;
    public float offsetY = 1.0f;
    public float offsetZ = 1.0f;

    public float turnSpeed = 4.0f;
    public CursorLockMode wantedMode;

    public bool firstPerson = false;
    public float speed;
    public Transform target;
    //public Transform lookAtMovingTarget;

    Vector2 _mouseAbsolute;
    Vector2 _controllerAbsolute;
    Vector2 _smoothMouse;
    Vector2 _smoothController;

    public Vector2 clampInDegrees = new Vector2(360, 180);
    public bool lockCursor;
    public Vector2 sensitivity = new Vector2(2, 2);
    public Vector2 smoothing = new Vector2(3, 3);
    public Vector2 targetDirection;
    public Vector2 targetDirectionC;
    public Vector2 targetCharacterDirection;
    public Vector2 targetCharacterDirectionC;
    public GameObject characterBody;

    public Text firstText;

    public string stringKeyboard;
    public string stringController;

    public float textTimer;
    private float textTimerMax;

    private bool startup;

    Camera camera;

    private uint oldMask;
    private int camLook;
    #endregion

    void SetCursorState()
    {
        Cursor.lockState = wantedMode;
        // Hide cursor when locking
        wantedMode = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    void Start()
    {
        startup = true;
        textTimer = 0;
        textTimerMax = 5.0f;
        firstText = GameObject.Find("ObjectiveUpdate").GetComponent<Text>();
        firstText.enabled = false;
        canMove = true;
        camLook = 0;
        oldMask = 0xffffffff;
        firstPerson = true;
        rayLeft = new Vector3(-rayLength, 0, 0);
        rayRight = new Vector3(rayLength, 0, 0);
        rayBack = new Vector3(0, 0, -rayLength);
        rayFront = new Vector3(0, 0, rayLength);
        //defaultOffset = new Vector3(offsetX, offsetY, offsetZ);

        transform.LookAt(lookAtTarget, Vector3.up);
        //transform.LookAt(lookAtTarget, new Vector3(0, 217.2175f, 0));
        this.transform.rotation = Quaternion.LookRotation(new Vector3(player.rotation.x,player.rotation.y,player.rotation.z),Vector3.up);
        Debug.Log(this.transform.rotation);
        //offset = defaultOffset;
    }

    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("RightJoystickX") != 0 || Input.GetAxis("Vertical") != 0 || Input.GetAxis("RightJoystickY") != 0)
        {
            if (startup)
            {
                firstText.enabled = true;
                startup = false;
            }
            if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                firstText.text = stringKeyboard;
            }

            if(Input.GetAxis("RightJoystickX") != 0 || Input.GetAxis("RightJoystickY") != 0)
            {
                firstText.text = stringController;
            }
        }

        if(textTimer >= textTimerMax)
        {
            firstText.enabled = false;
        }

        textTimer += Time.deltaTime;
    }

    void LateUpdate()
    {
        if (canMove)
        {
            SetCursorState();
            if (!firstPerson)
            {

                //camera.cullingMask = (int)oldMask;
                //moves the camera
                //offset = Quaternion.AngleAxis((Input.GetAxis("Mouse X") * Input.GetAxis("RightJoystickX")) * turnSpeed, Vector3.up) * offset;
                //transform.position = player.position + offset;
                //transform.LookAt(lookAtTarget);

                //RayCaster();
                //Debug.DrawRay(rayL.origin, rayL.direction, Color.blue);
                //Debug.DrawRay(rayR.origin, rayR.direction, Color.red);
                //Debug.DrawRay(rayB.origin, rayB.direction, Color.green);
                //Debug.DrawRay(rayF.origin, rayF.direction, Color.yellow);
            }

            if(firstPerson)
            {
                //camera.cullingMask = (1 << LayerMask.NameToLayer("TransparentFX")) | (1 << LayerMask.NameToLayer("Player"));
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);
                
                // Ensure the cursor is always locked when set
                //Screen.lockCursor = lockCursor;

                // Allow the script to clamp based on a desired target value.
                var targetOrientation = Quaternion.Euler(targetDirection);
                var targetOrientationC = Quaternion.Euler(targetDirectionC);
                var targetCharacterOrientation = Quaternion.Euler(targetCharacterDirection);
                var targetCharacterOrientationC = Quaternion.Euler(targetCharacterDirectionC);
                //added controller deltas
                var controllerDelta = new Vector2(Input.GetAxis("RightJoystickX"), Input.GetAxis("RightJoystickY"));
                // Get raw mouse input for a cleaner reading on more sensitive mice.
                var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

                

                // Scale input against the sensitivity setting and multiply that against the smoothing value.
                mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity.x * smoothing.x, sensitivity.y * smoothing.y));
                controllerDelta = Vector2.Scale(controllerDelta, new Vector2(sensitivity.x * smoothing.x, sensitivity.y * smoothing.y));

                // Interpolate mouse movement over time to apply smoothing delta.
                _smoothMouse.x = Mathf.Lerp(_smoothMouse.x, mouseDelta.x, 1f / smoothing.x);
                _smoothMouse.y = Mathf.Lerp(_smoothMouse.y, mouseDelta.y, 1f / smoothing.y);

                _smoothController.x = Mathf.Lerp(_smoothController.x, controllerDelta.x, 1f / smoothing.x);
                _smoothController.y = Mathf.Lerp(_smoothController.y, controllerDelta.y, 1f / smoothing.y);

                // Find the absolute mouse movement value from point zero.
                _mouseAbsolute += _smoothMouse;
                _controllerAbsolute += _smoothController;

                // Clamp and apply the local x value first, so as not to be affected by world transforms.
                if (clampInDegrees.x < 360)
                {
                    _mouseAbsolute.x = Mathf.Clamp(_mouseAbsolute.x, -clampInDegrees.x * 0.5f, clampInDegrees.x * 0.5f);
                    _controllerAbsolute.x = Mathf.Clamp(_controllerAbsolute.x, -clampInDegrees.x * 0.5f, clampInDegrees.x * 0.5f);
                }
                var xRotation = Quaternion.AngleAxis(-_mouseAbsolute.y, targetOrientation * Vector3.right);
                //transform.localRotation = xRotation;

                //if (clampInDegrees.x < 360)
                    
                var xRotationC = Quaternion.AngleAxis(-_controllerAbsolute.y, targetOrientationC * Vector3.right);
                transform.localRotation = xRotationC * xRotation;
                // Then clamp and apply the global y value.
                if (clampInDegrees.y < 360)
                {
                    _mouseAbsolute.y = Mathf.Clamp(_mouseAbsolute.y, -clampInDegrees.y * 0.5f, clampInDegrees.y * 0.5f);
                    _controllerAbsolute.y = Mathf.Clamp(_controllerAbsolute.y, -clampInDegrees.y * 0.5f, clampInDegrees.y * 0.5f);
                }
                //if (clampInDegrees.y < 360)
                    

                transform.localRotation *= targetOrientation;
                transform.localRotation *= targetOrientationC;

                // If there's a character body that acts as a parent to the camera
                //if (characterBody)
                {
                    var yRotation = Quaternion.AngleAxis(_mouseAbsolute.x, characterBody.transform.up);
                    //characterBody.transform.localRotation = yRotation;
                    characterBody.transform.localRotation *= targetCharacterOrientation;

                    var yRotationC = Quaternion.AngleAxis(_controllerAbsolute.x, characterBody.transform.up);
                    characterBody.transform.localRotation = yRotationC * yRotation;
                    characterBody.transform.localRotation *= targetCharacterOrientationC;
                }
                //    //else
                {
                    var yRotation = Quaternion.AngleAxis(_mouseAbsolute.x, transform.InverseTransformDirection(Vector3.up));
                    //transform.localRotation *= yRotation;

                    var yRotationC = Quaternion.AngleAxis(_controllerAbsolute.x, transform.InverseTransformDirection(Vector3.up));
                    transform.localRotation *= yRotationC * yRotation;
                }
                //if (camLook == 0)
                //{
                //    float damping = 6.0f;
                //    //var yRotation = Quaternion.AngleAxis(_mouseAbsolute.x, characterBody.transform.up);
                //    //characterBody.transform.localRotation = yRotation;
                //    //characterBody.transform.localRotation *= targetCharacterOrientation;
                //    //transform.LookAt(lookAtMovingTarget);
                //    //Quaternion rotation = Quaternion.LookRotation(lookAtMovingTarget.position - transform.position);
                //    //this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rotation, damping);
                //    camLook = 1;
                //}
            }
            //reset camera
            if (Input.GetButtonDown("Fire2"))
            {
            //offset = defaultOffset;
            }

            if (Input.GetButtonDown("Fire1"))
            {
                /*
                //obsolete code now since the game will be all in first person
                offset = defaultOffset;
                // Set target direction to the camera's initial orientation.
                targetDirection = transform.localRotation.eulerAngles;

                // Set target direction for the character body to its inital state.
                if (characterBody) targetCharacterDirection = characterBody.transform.localRotation.eulerAngles;
                camLook = 0;
                firstPerson = !firstPerson;
                */
                
            }
        }
        else
        {
            wantedMode = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    #region RAY WORKS
    void RayCaster()
    {
        //ray origin spot and direction
        rayL.origin = transform.position;
        rayR.origin = transform.position;
        rayB.origin = transform.position;
        rayF.origin = transform.position;
        rayL.direction = rayLeft;
        rayR.direction = rayRight;
        rayB.direction = rayBack;
        rayF.direction = rayFront;

        if ((Physics.Raycast(rayL, out hit, rayLength)) && (hit.collider.gameObject.tag == "Wall")) //left side ray
        {
            float posX = transform.position.x;
            float posY = transform.position.y;
            float posZ = transform.position.z;

            transform.position = new Vector3(Mathf.Lerp(posX, posX + collisionOffset, Time.time), posY, posZ);

            rayL.origin = transform.position;
            rayR.origin = transform.position;
            rayB.origin = transform.position;
            rayF.origin = transform.position;
        }
        else if ((Physics.Raycast(rayR, out hit, rayLength)) && (hit.collider.gameObject.tag == "Wall")) //right side ray
        {
            float posX = transform.position.x;
            float posY = transform.position.y;
            float posZ = transform.position.z;

            transform.position = new Vector3(Mathf.Lerp(posX, posX - collisionOffset, Time.time), posY, posZ);

            rayL.origin = transform.position;
            rayR.origin = transform.position;
            rayB.origin = transform.position;
            rayF.origin = transform.position;
            //Debug.Log("Wall on Right");
        }
        else if ((Physics.Raycast(rayB, out hit, rayLength)) && (hit.collider.gameObject.tag == "Wall")) //back side ray
        {
            float posX = transform.position.x;
            float posY = transform.position.y;
            float posZ = transform.position.z;

            transform.position = new Vector3(posX, posY, Mathf.Lerp(posZ, posZ + collisionOffset, Time.time));

            rayL.origin = transform.position;
            rayR.origin = transform.position;
            rayB.origin = transform.position;
            rayF.origin = transform.position;
            //Debug.Log("Wall on Back");
        }
        else if ((Physics.Raycast(rayF, out hit, rayLength)) && (hit.collider.gameObject.tag == "Wall")) //front side ray
        {
            float posX = transform.position.x;
            float posY = transform.position.y;
            float posZ = transform.position.z;

            transform.position = new Vector3(posX, posY, Mathf.Lerp(posZ, posZ - collisionOffset, Time.time));

            rayL.origin = transform.position;
            rayR.origin = transform.position;
            rayB.origin = transform.position;
            rayF.origin = transform.position;
            //Debug.Log("Wall on Front");
        }
        else if ((Physics.Raycast(rayR, out hit, rayLength)) && (Physics.Raycast(rayB, out hit, rayLength)) && (hit.collider.gameObject.tag == "Wall")) //right side ray and back side
        {
            float posX = transform.position.x;
            float posY = transform.position.y;
            float posZ = transform.position.z;

            transform.position = new Vector3(Mathf.Lerp(posX, posX - collisionOffset, Time.time), posY, Mathf.Lerp(posZ, posZ + collisionOffset, Time.time));

            rayL.origin = transform.position;
            rayR.origin = transform.position;
            rayB.origin = transform.position;
            rayF.origin = transform.position;
            //Debug.Log("Wall on Right");
        }
        else if ((Physics.Raycast(rayR, out hit, rayLength)) && (Physics.Raycast(rayF, out hit, rayLength)) && (hit.collider.gameObject.tag == "Wall")) //right side ray and front side
        {
            float posX = transform.position.x;
            float posY = transform.position.y;
            float posZ = transform.position.z;

            transform.position = new Vector3(Mathf.Lerp(posX, posX - collisionOffset, Time.time), posY, Mathf.Lerp(posZ, posZ - collisionOffset, Time.time));

            rayL.origin = transform.position;
            rayR.origin = transform.position;
            rayB.origin = transform.position;
            rayF.origin = transform.position;
            //Debug.Log("Wall on Right");
        }
        else if ((Physics.Raycast(rayL, out hit, rayLength)) && (Physics.Raycast(rayB, out hit, rayLength)) && (hit.collider.gameObject.tag == "Wall")) //left side ray and back side
        {
            float posX = transform.position.x;
            float posY = transform.position.y;
            float posZ = transform.position.z;

            transform.position = new Vector3(Mathf.Lerp(posX, posX + collisionOffset, Time.time), posY, Mathf.Lerp(posZ, posZ + collisionOffset, Time.time));

            rayL.origin = transform.position;
            rayR.origin = transform.position;
            rayB.origin = transform.position;
            rayF.origin = transform.position;
            //Debug.Log("Wall on Right");
        }
        else if ((Physics.Raycast(rayL, out hit, rayLength)) && (Physics.Raycast(rayF, out hit, rayLength)) && (hit.collider.gameObject.tag == "Wall")) //left side ray and front side
        {
            float posX = transform.position.x;
            float posY = transform.position.y;
            float posZ = transform.position.z;

            transform.position = new Vector3(Mathf.Lerp(posX, posX + collisionOffset, Time.time), posY, Mathf.Lerp(posZ, posZ - collisionOffset, Time.time));

            rayL.origin = transform.position;
            rayR.origin = transform.position;
            rayB.origin = transform.position;
            rayF.origin = transform.position;
            //Debug.Log("Wall on Right");
        }
    }
    #endregion

    #region Getters and Setters
    public bool CanMove
    {
        get { return canMove; }
        set { canMove = value; }
    }

    public float RotSpeed
    {
        get { return rotSpeed; }
        set { rotSpeed = value; }
    }

    public float RayLength
    {
        get { return rayLength; }
        set { rayLength = value; }
    }

    public float CollisionOffset
    {
        get { return collisionOffset; }
        set { collisionOffset = value; }
    }

    public float OffsetX
    {
        get { return offsetX; }
        set { offsetX = value; }
    }

    public float OffsetY
    {
        get { return offsetY; }
        set { offsetY = value; }
    }

    public float OffsetZ
    {
        get { return offsetZ; }
        set { offsetZ = value; }
    }
    #endregion
}
