using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AIBehaviour : MonoBehaviour {

    public GameObject[] waypoints;
    public float speed;
    public Transform target;

    public Transform currentWaypoint;
    public Transform nextWaypoint;

    public int w;
    public int r;

    private float waitTime = 0.1f;
    private float timer = 0.0f;

    private float unseenWaitTimer = 3.0f;
    public float unseentimer = 0.0f;

    private float damping = 6.0f;

    private float rayLength = 5.0f;
    Ray ray;
    Ray ray2;

    private Vector3 rayDirection;

    public Quaternion rotation;

    public enum AISTATE { Wander,Detected,Stun }
    public AISTATE aiState = AISTATE.Wander;

    private bool seen;

    public GameObject player;

    private int posTracker = 0;
    private int negTracker = 0;
    private bool tracker = false;


    // Use this for initialization
    void Start () {

        seen = false;

        speed = 3;

        w = 0;

        for(int i=0; i<waypoints.Length; i++)
        {
            waypoints[i] = GameObject.Find("waypoint" + i);
        }

        player = GameObject.Find("Player");

        transform.position = new Vector3(waypoints[0].transform.position.x, waypoints[0].transform.position.y, waypoints[0].transform.position.z);

    }
	
	// Update is called once per frame
	void LateUpdate() {

        switch(aiState)
        {
            case AISTATE.Wander:
                MoveToWaypoint();
                Movement();
                break;
            case AISTATE.Detected:
                if(!seen)
                {
                    UnseenTimer();
                }
                if (seen)
                {
                    Detected();
                }
                Movement();
                break;
            case AISTATE.Stun:
                break;
        }

        //RayCaster();
        //Debug.DrawRay(ray.origin, rayDirection, Color.blue);
        //Debug.DrawRay(ray2.origin, rayDirection, Color.blue);
        
        if (w<0)
        {
            w = 0;
        }
    }


    //gets the current waypoint
    public Transform CurrentWaypoint(Transform point)
    {
        currentWaypoint = point;
        //waypoints[0] = currentWaypoint;
        return currentWaypoint;
    }

    //tells the AI which point to move to next
    void MoveToWaypoint()
    {
        if(currentWaypoint == waypoints[0].transform)
        {
            nextWaypoint = waypoints[1].transform;
        }

        if (nextWaypoint != currentWaypoint)
        {
            target = nextWaypoint;
        }

        if (currentWaypoint == waypoints[w].transform)
        {
            if(this.transform.position == waypoints[w].transform.position)
            {
                timer += Time.deltaTime;
                if (timer >= waitTime)
                {
                    r = Random.Range(0, 10);

                    SelectWaypoint();
                    
                    timer = 0;
                }
            }
            
        }
    }

    //basic movement between waypoints
    void Movement()
    {
        //rotate the object to look at next target
        if (nextWaypoint != currentWaypoint)
        {
            //transform.LookAt(nextWaypoint, Vector3.up);
            rotation = Quaternion.LookRotation(nextWaypoint.position - transform.position,Vector3.up);
            if ((rotation.x != 0) || (rotation.y != 0) || (rotation.z != 0))
            {
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, Time.deltaTime * damping);
            }
            else
            {
                rotation = Quaternion.LookRotation(nextWaypoint.position);
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, Time.deltaTime * damping);
                SelectWaypoint();
            }
        }
        else
        {
            //transform.rotation = Quaternion.Euler(Vector3.zero);
        }

        //if (nextWaypoint == currentWaypoint)
        //{
        //    rotation = Quaternion.LookRotation(nextWaypoint.position);
        //}
        //else
        //{
        //    transform.rotation = Quaternion.Euler(Vector3.zero);
        //}

        //floating effect
        //if(tracker)
        //{
        //    posTracker++;
        //    this.transform.position = new Vector3(transform.position.x, transform.position.y + posTracker, transform.position.z);
        //    if(posTracker >= 5)
        //    {
        //        tracker = false;
        //    }
        //}
        //else
        //{
        //    negTracker--;
        //    this.transform.position = new Vector3(transform.position.x, transform.position.y - negTracker, transform.position.z);
        //    if (negTracker >= -5)
        //    {
        //        tracker = true;
        //    }
        //}

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    public int WaypointNumber(int number)
    {
        //if (w != number)
        {
            w = number;
        }
        return w;
    }

    void SelectWaypoint()
    {
        int temp;
        if (r <= 4)
        {
            temp = w - 1;
        }
        else
        {
            temp = w + 1;
        }

        if(temp > waypoints.Length)
        {
            temp = w - 1;
        }

        nextWaypoint = waypoints[temp].transform;
    }

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            //Debug.Log("Player seen");
            seen = true;
            unseentimer = 0;
            aiState = AISTATE.Detected;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            seen = false;
        }
    }

    void Detected()
    {
        nextWaypoint = player.transform;
        target = nextWaypoint;
    }

    void UnseenTimer()
    {
        unseentimer += Time.deltaTime;
        if(unseentimer >= unseenWaitTimer)
        {
            aiState = AISTATE.Wander;
            nextWaypoint = currentWaypoint;
            target = nextWaypoint;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("LoseScene");
        }
    }


    //raycast not used anymore
    void RayCaster()
    {
        rayDirection = transform.TransformDirection(Vector3.forward * rayLength);
        //ray origin spot and direction
        ray.origin = transform.position;
        ray2.origin = new Vector3(transform.position.x*1,transform.position.y,transform.position.z);
        ray.direction = rayDirection;
        ray2.direction = rayDirection;
        RaycastHit hit;
        //if ((Physics.Raycast(ray, out hit, rayLength)) && (hit.collider.gameObject.tag == "Player")) 
        //{
        //    Debug.Log("player seen");
        //}
        //if ((Physics.Raycast(ray2, out hit, rayLength)) && (hit.collider.gameObject.tag == "Player")) 
        //{
        //    Debug.Log("player seen");
        //}
    }
}
