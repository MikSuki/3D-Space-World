using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour {
    public GameObject ufo;
    Vector3 move;
	// Use this for initialization
	void Start () {
        move = new Vector3(Random.Range(-1,1), Random.Range(-1, 1), Random.Range(-1, 1));
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.time / 10 == 0)
            move = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
        ufo.transform.position += move;

    }
}
