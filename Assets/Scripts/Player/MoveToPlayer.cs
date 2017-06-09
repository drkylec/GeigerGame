using UnityEngine;
using System.Collections;

public class MoveToPlayer : MonoBehaviour {

    public GameObject playerPos;

	// Use this for initialization
	void Start () {
        playerPos = GameObject.Find("Player");
        this.transform.position = new Vector3(playerPos.transform.position.x,playerPos.transform.position.y,playerPos.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(playerPos.transform.position.x, playerPos.transform.position.y, playerPos.transform.position.z);
    }
}
