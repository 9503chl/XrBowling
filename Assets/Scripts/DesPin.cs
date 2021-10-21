using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesPin : MonoBehaviour
{
    bool isCollide = false;
    float timer1 = 0.0f;
    void Update()
    {
        if (isCollide && gameObject.transform.rotation.x != 0) timer1 += Time.deltaTime;
        if (timer1 >= 2.5f) Destroy(gameObject);
    }
    void OnCollisionEnter(Collision other)
    {
        isCollide = true;       
    }
}
