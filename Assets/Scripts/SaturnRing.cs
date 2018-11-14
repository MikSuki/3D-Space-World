using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaturnRing : MonoBehaviour
{
    public GameObject Saturn, cube;
    public int changeAngle = 10;
    private int count;
    private float angle = 0;
    public float r = 5;
    void Start()
    {
        count = (int)360 / changeAngle;
        for (int i = 0; i < count; i++)
        {
            Vector3 center = Saturn.transform.position;
            GameObject clone = Instantiate(cube);
            float hudu = (angle / 180) * Mathf.PI;
            float xx = center.x + 50f * r * Mathf.Cos(hudu);
            float zz = center.z + 50f * r * Mathf.Sin(hudu);
            clone.transform.position = new Vector3(xx, 0, zz);
            clone.transform.LookAt(center);
            clone.transform.SetParent(Saturn.transform);
            angle += changeAngle;
        }
        Destroy(cube);
        Saturn.transform.Rotate(45f,0,0);
    }
}
