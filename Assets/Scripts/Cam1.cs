using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cam1 : MonoBehaviour
{
    public GameObject Sun , Moon , Mercury , Venus, Earth , Mars , Jupiter , Saturn , Uranus , Neptune ;
    public GameObject Player;
    GameObject followPlanet;
    Vector3 offset;
    float speed;
    bool followPlanetOrNot = false;
    bool followRocketOrNot = false;
    bool GameStart = false;
    GUIStyle gs;

    void Start()
    {
        Mercury.AddComponent<Planet>().speed = 47.89f;
        Venus.AddComponent<Planet>().speed = 35.03f;
        Earth.AddComponent<Planet>().speed = 30f;
        Mars.AddComponent<Planet>().speed = 24.13f;
        Jupiter.AddComponent<Planet>().speed = 13.06f;
        Saturn.AddComponent<Planet>().speed = 9.64f;
        Uranus.AddComponent<Planet>().speed = 6.81f;
        Neptune.AddComponent<Planet>().speed = 5.43f;
        Moon.AddComponent<Moon>().speed = 300f;

        gs = new GUIStyle
        {
            fontSize = 35
        };
        gs.normal.textColor = new Color(1,0,0);
        gs.fontStyle = FontStyle.Italic;
    }

    void OnGUI()
    {
        if (!GameStart)
        {
            if (GUI.Button(new Rect(20, 10, 120, 40), "Overlooking"))
            {
                OverLooking();
            }
            if (GUI.Button(new Rect(20, 60, 120, 40), "Mercury"))
            {
                ChangePlanet(Mercury , 47.89f);
            }
            if (GUI.Button(new Rect(20, 110, 120, 40), "Venus"))
            {
                ChangePlanet(Venus , 35.03f);
            }
            if (GUI.Button(new Rect(20, 160, 120, 40), "Earth"))
            {
                ChangePlanet(Earth , 30f);
            }
            if (GUI.Button(new Rect(20, 210, 120, 40), "Mars"))
            {
                ChangePlanet(Mars , 24.13f);
            }
            if (GUI.Button(new Rect(20, 260, 120, 40), "Jupiter"))
            {
                ChangePlanet(Jupiter , 13.06f);
            }
            if (GUI.Button(new Rect(20, 310, 120, 40), "Saturn"))
            {
                ChangePlanet(Saturn , 9.64f);
            }
            if (GUI.Button(new Rect(20, 360, 120, 40), "Uranus"))
            {
                ChangePlanet(Uranus , 6.81f);
            }
            if (GUI.Button(new Rect(20, 410, 120, 40), "Neptune"))
            {
                ChangePlanet(Neptune , 5.43f);
            }
            if (GUI.Button(new Rect(20, 460, 120, 40), "Moon"))
            {
                ChangePlanet(Moon , 30f);
            }
            if (GUI.Button(new Rect(20, 510, 120, 40), "Exit"))
            {
                Exit();
            }
            if (GUI.Button(new Rect(540, 200, 160, 50), "Play"))
            {
                Play();
                Planet.Play();
                Player.GetComponent<Player>().Play();
            }
            if (GUI.Button(new Rect(1100, 30, 120, 40), ">> 0.1"))
            {
                Time.timeScale = 0.1f;
            }
            if (GUI.Button(new Rect(1100, 150, 120, 40), ">> 0"))
            {
                Time.timeScale = 0f;
            }
            if (GUI.Button(new Rect(1100, 270, 120, 40), ">> 1"))
            {
                Time.timeScale = 1f;
            }
            if (GUI.Button(new Rect(1100, 390, 120, 40), ">> 10"))
            {
                Time.timeScale = 10f;
            }
            if (GUI.Button(new Rect(1100, 510, 120, 40), ">> 100"))
            {
                Time.timeScale = 100f;
            }
        }
        else if (Time.time %2 < 1 && !Player.GetComponent<Player>().startFly)
        {
            GUI.Label(new Rect(420, 500, 500, 200), "Press    space    to    start", gs);
        }
    }

    void Update()
    {
        //Zoom in/out
        if (Camera.main.fieldOfView > 10 && Input.GetAxis("Mouse ScrollWheel") > 0)
            Camera.main.fieldOfView -= 10;
        if (Camera.main.fieldOfView < 100 && Input.GetAxis("Mouse ScrollWheel") < 0)
            Camera.main.fieldOfView += 10;

        //Rotate Screen
        if (Input.GetMouseButton(1))
        {
            float h = 3f * Input.GetAxis("Mouse X");
            float v = -3f * Input.GetAxis("Mouse Y");
            transform.Rotate(v, h, 0);
        }

        //Move Screen
        if (!followPlanetOrNot && !followRocketOrNot)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += 10f * transform.forward;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= 10f * transform.forward;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += 10f * transform.right;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= 10f * transform.right;
            }
        }
    }

    void LateUpdate()
    {
        //Camera Follow
        if (followPlanetOrNot && !followRocketOrNot)
        {
            transform.RotateAround(Sun.transform.position, Vector3.up, speed * Time.deltaTime);

            if (!Input.GetMouseButton(1))
            {
                transform.LookAt(followPlanet.transform.position);
            }
        }
        if(followRocketOrNot)
        {
            if (!Input.GetMouseButton(1))
            {
                transform.LookAt(Player.transform);
            }
        }
    }

    //Change Perspective
    void ChangePlanet(GameObject planet , float speed)
    {
        followPlanet = planet;
        transform.position = offset + planet.transform.position;

        float x = planet.transform.position.x - Sun.transform.position.x;
        float y = planet.transform.position.y - Sun.transform.position.y;
        float z = planet.transform.position.z - Sun.transform.position.z;

        Vector3 scale = planet.transform.localScale;
        this.speed = speed;

        //decide offset
        if (scale.x < 0.5)
            offset = new Vector3(0.0005f * x, 0.0005f * y, 0.0005f * z);
        else if (scale.x < 10)
            offset = new Vector3(0.005f * x, 0.005f * y, 0.005f * z);
        else if (scale.x < 100)
            offset = new Vector3(0.1f * x, 0.1f * y, 0.1f * z);
        else if (scale.x < 300)
            offset = new Vector3(0.5f * x, 0.5f * y, 0.5f * z);
        else if (scale.x > 500)
            offset = new Vector3(3f * x, 3f * y, 3f * z);

        transform.position = offset + planet.transform.position;
        Camera.main.fieldOfView = 30;
        followPlanetOrNot = true;
    }

    //Overlooking
    void OverLooking()
    {
        followPlanetOrNot = false;
        Vector3 pos = Sun.transform.position;
        pos.y = 10000;
        transform.position= pos;
        transform.LookAt(Sun.transform);
    }

    //Freedom perspective
    void Exit()
    {
        followPlanetOrNot = false ;
    }

    public void Play()
    {
        float x = Earth.transform.position.x - Sun.transform.position.x;
        float y = Earth.transform.position.y - Sun.transform.position.y;
        float z = Earth.transform.position.z - Sun.transform.position.z;
        offset = new Vector3(0.002f * x,0.002f * y + 3f,0.002f * z);
        transform.position = offset + Earth.transform.position;

        Camera.main.farClipPlane = 120;
        Camera.main.fieldOfView = 3;
        followPlanetOrNot = false;
        followRocketOrNot = true;
        GameStart = true;
    }
}
