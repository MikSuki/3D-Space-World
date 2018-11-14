using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour {
    public GameObject cam1, cam2 ;
    public GameObject Player;
	
	void Update () {
        if (Player.transform.position.y > 100f) 
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            Player.GetComponent<SimpleMouseLook>().enabled = true;
            GetComponent<CameraChange>().enabled = false;
            //cam3.SetActive(true);
            //cam2.transform.parent = null;
        }
	}
}
