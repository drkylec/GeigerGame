using UnityEngine;
using System.Collections;

public class AITitleMenu : MonoBehaviour {

    public Transform t1;
    public Transform t2;

    private bool move;

    public float speed = 1.0f;

    // Use this for initialization
    void Start () {
        move = true;
        this.transform.position = t1.position;
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;

        if(move)
        {
            transform.position = Vector3.MoveTowards(transform.position, t2.position, step);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, t1.position, step);
        }

        if (this.transform.position == t1.position)
        {
            move = true;
        }
        if(this.transform.position == t2.position)
        {
            move = false;
        }
    }
}
