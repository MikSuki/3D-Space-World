using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObject : MonoBehaviour {
    public GameObject ufo, meteorite;
    public Transform father;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 1000; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-10000f,10000f), Random.Range(-10000f, 10000f), Random.Range(-10000f, 10000f));
            Instantiate(meteorite , pos , Random.rotation , father);
        }
        for (int i = 0; i < 50; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-10000f, 10000f), Random.Range(-10000f, 10000f), Random.Range(-10000f, 10000f));
            Instantiate(ufo, pos, Random.rotation, father);
        }
    }
}

