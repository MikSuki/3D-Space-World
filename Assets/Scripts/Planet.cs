using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Planet : MonoBehaviour
{
    public GameObject Sun, Moon , Mercury, Venus, Earth, Mars, Jupiter, Saturn, Uranus, Neptune;
    public GameObject planet , Player;
    public float speed;
    public static bool stop = false;

    void Update()
    {
        Rotate();
    }

    public void Rotate()
    {
        if (!stop)
            transform.RotateAround(Vector3.zero, Vector3.up, speed * Time.deltaTime);
    }

    public static void Play()
    {
        stop = true;
    }

    public static void StartControl()
    {
        stop = false;
    }

}
