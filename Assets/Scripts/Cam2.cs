using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam2 : MonoBehaviour {
    public GameObject player;
    public Camera Cam;
    public static bool gameover = false;
    GUIStyle gs;

    void Start()
    {
        gs = new GUIStyle
        {
            fontSize = 200
        };
        gs.normal.textColor = new Color(1, 1, 0);
        gs.fontStyle = FontStyle.Bold;
    }

    private void OnGUI()
    {
        if(gameover)
        {
            GUI.Label(new Rect(100, 200, 1000, 800), "Gameover" , gs);
        }
    }

    void Update () {
        if(!gameover)
        {
            transform.LookAt(player.transform);
        }
        else
        {
            //Zoom in/out
            if (Cam.fieldOfView > 10 && Input.GetAxis("Mouse ScrollWheel") > 0)
                Cam.fieldOfView -= 10;
            if (Cam.fieldOfView < 100 && Input.GetAxis("Mouse ScrollWheel") < 0)
                Cam.fieldOfView += 10;

            //Rotate Screen
            if (Input.GetMouseButton(1))
            {
                float h = 3f * Input.GetAxis("Mouse X");
                float v = -3f * Input.GetAxis("Mouse Y");
                transform.Rotate(v, h, 0);
            }

        }
    }
}
