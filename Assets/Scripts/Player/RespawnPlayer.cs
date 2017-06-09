using UnityEngine;
using System.Collections;

public class RespawnPlayer : MonoBehaviour {

    public Transform playerSpawn;
    public Transform player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider col)
    {
        player.position = playerSpawn.position;
        //Debug.Log("hit");
    }
}
