using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TitleGrab : MonoBehaviour
{
    Light light1;
    void Start()
    {
        light1 = GameObject.Find("Directional Light").GetComponent<Light>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "BowlingBall")
        {
            light1.DOIntensity(1000, 0.5f);
        }
        if (other.name == "Pinp")
        {
            light1.DOIntensity(1000, 0.5f);
        }
        if (other.name == "Shoes")
        {
            light1.DOIntensity(1000, 0.5f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Pinp")
        {
            
        }
    }
}
