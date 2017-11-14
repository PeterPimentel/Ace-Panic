using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallThorn : MonoBehaviour {

    public float speed;
    public float waitTime;
    public Transform A;
    public Transform B;
    private Vector3 destiny;
    private bool activate;

	// Use this for initialization
	void Start () {
        destiny = A.position;
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = Vector3.MoveTowards(transform.position, destiny, speed * Time.deltaTime);

        if (transform.position == destiny && !activate)
        {
            StartCoroutine("MoveThorn");
        }
	}

    //Ver explicação no código da plataforma
    IEnumerator MoveThorn()
    {
        activate = true;

        yield return new WaitForSeconds(waitTime);

        if (transform.position == A.position)
        {
            destiny = B.position;
        }
        else if (transform.position == B.position)
        {
            destiny = A.position;
        }
        activate = false;
    }
}
