using UnityEngine;
using System.Collections;

public class WaypointScript : MonoBehaviour {

    public AIBehaviour ai;
    public int waypointNumber;

	// Use this for initialization
	void Start () {
        ai = GameObject.FindObjectOfType(typeof(AIBehaviour)) as AIBehaviour;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    { 
        ai.CurrentWaypoint(this.transform);
        ai.WaypointNumber(this.waypointNumber);
    }
}
