using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodes : MonoBehaviour
{
    public float time = 5.0f;
    public bool isCollide = false;
    void Update()
    {
        if(isCollide) {
            Destroy(gameObject, time * 2);
            GameObject.Find("BowlingBall").GetComponent<Ball>().count--;      
        } else { 
        Destroy(gameObject, time);
        GameObject.Find("BowlingBall").GetComponent<Ball>().count--;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "BreakWall") Destroy(gameObject);
    }
}