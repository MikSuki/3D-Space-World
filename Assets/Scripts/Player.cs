using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour {
    public Rigidbody r;
    public GameObject Shot , Target , Cam , GameControl;
    public Transform ShotPoint , nowP , originP;
    public bool start = false;
    public bool startFly = false;
    bool startControll = false;

    //float speedLevel = 0f;
    float speedLevel = 100f;

    float nowSpeed;
    float addSpeed = 2f;
    float subSpeed = 2.5f;
    int life = 3;
    Vector3 dir;
    public ParticleSystem PS;

    void Start()
    {
        dir = new Vector3(nowP.transform.position.x - transform.position.x, nowP.transform.position.y - transform.position.y, nowP.transform.position.z - transform.position.z);
    }
    void Update () {
        if (start && Input.GetKey(KeyCode.Space))
        {
            startFly = true;
            GameControl.GetComponent<CameraChange>().enabled = true;
        }

        if (startFly)
        {
            transform.parent = null;
            transform.position = nowP.transform.position;
            nowP.transform.position += speedLevel * dir;
            speedLevel = GetSpeed(speedLevel);

            if (transform.position.y > 100f)
            {
                start = false;
                startFly = false;
                startControll = true;
                Target.GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<BoxCollider>().enabled = true;
                GetComponent<CapsuleCollider>().enabled = true;
                Planet.StartControl();
            }
        }

        if(startControll)
        {
            if (Input.GetKey(KeyCode.W) && nowSpeed < 500f)
            {
                nowSpeed += addSpeed;
            }
            if (!Input.GetKey(KeyCode.W) && nowSpeed > 0)
            {
                nowSpeed -= subSpeed;
                if (nowSpeed < 0)
                    nowSpeed = 0;
            }
            if(Input.GetKey(KeyCode.W))
            {
                transform.position = nowP.transform.position;
            }
        }

        if (startControll && Input.GetMouseButtonDown(0))
            PS.Play();
        if (startControll && Input.GetMouseButtonUp(0))
            PS.Stop();

        if (startControll && Input.GetMouseButtonDown(1))
        {
            Quaternion rot = transform.rotation;
            GameObject clone = Instantiate(Shot, ShotPoint.position , rot);
            clone.GetComponent<Shot>().enabled = true;
            clone.GetComponent<BoxCollider>().enabled = true;
        }  
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpaceObject"))
        {
            Destroy(other.gameObject);
            life--;
            Debug.Log(life);
        }
        else if(other.CompareTag("Planet"))
        {
            life -= 3;
        }

        if(life <= 3)
        {
            Cam.transform.parent = null;
            GetComponent<SimpleMouseLook>().lockCursor = true;
            Cam2.gameover = true;
            Destroy(gameObject);
        }
    }

    public void Play()
    {
        start = true;
    }

    public float GetSpeed(float a)
    {
        float b;
        if (a < 0.2)
        {
            b = a + 0.001f;
        }
        else if(a < 2)
        {
            b = a + 0.01f;
        }
        else if (a < 5)
        {
            b = a + 2f;
        }
        else
        {
            b = a;
        }
        return b;
    }
}
