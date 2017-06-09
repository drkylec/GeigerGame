using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {

    public Light light;
    private float timer;
    private float timerMax;

    // Use this for initialization
    void Start () {
        timer = 0;
        light.enabled = true;
        RandomTime();
    }
	
	// Update is called once per frame
	void Update () {
        //StartCoroutine(Flicker());
        //light.enabled = true;

        if(timer < timerMax)
        {
            light.enabled = true;
        }

        if(timer >= timerMax)
        {
            light.enabled = false;
            if(timer >= timerMax + 0.5f)
            {
                timer = 0;
                RandomTime();
            }
        }
        timer += Time.deltaTime;
    }

    void RandomTime()
    {
        timerMax = Random.Range(0.1f, 3.0f);
    }

    //oboslete code
    //IEnumerator Flicker()
    //{
    //    light.enabled = true;
    //    yield return new WaitForSeconds(Random.Range(1.0f,2.0f));
    //    light.enabled = false;
    //    yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
    //}
}
