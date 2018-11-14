using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour {
    public GameObject meteorite;
    Vector3 move; 
	// Use this for initialization
	void Start () {
        move = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
    }
	
	// Update is called once per frame
	void Update () {
        meteorite.transform.position += move;

    }
}
