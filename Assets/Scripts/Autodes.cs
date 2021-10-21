using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodes : MonoBehaviour
{
    float timer1 = 0.0f;
    void Update()
    {
        timer1 += Time.deltaTime;
        if (timer1 >= 5.0f)
        {
            Destroy(gameObject);
            timer1 = 0.0f;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag != "Ball" && other.transform.tag != "Spawner") timer1 = -2.0f;
        if (other.transform.tag == "BreakWall") Destroy(gameObject);
    }
}