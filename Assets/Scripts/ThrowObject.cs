using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    Transform tr;
    float timer1;
    int angle = 0;
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        angle += 20;
        tr.transform.Translate(0, 0, 10,Space.World);
        tr.transform.rotation = Quaternion.Euler(angle, 0, 0);
        timer1 += Time.deltaTime;
        if (angle >= 360) angle = 0;
        if(timer1 >= 3.0f) Destroy(gameObject);
    }
}
