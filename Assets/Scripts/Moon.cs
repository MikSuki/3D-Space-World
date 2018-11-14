using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : Planet {
    void Update()
    {
        MoonRotate();
    }
    public void MoonRotate()
    {
        if (!stop)
            transform.RotateAround(transform.parent.transform.position, new Vector3(0, -1, 1), speed * Time.deltaTime);
    }
}
