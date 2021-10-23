using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{
    public Transform Target1;
    public Transform Target2;
    public Transform Target3;
    public Transform Target4;

    void Update()
    {
        if (GameObject.Find("BreakWall").GetComponent<DesPin>().isFirst)
        {
            Invoke("FirstM", 0.5f);
            Invoke("SecondM", 1.5f);
            Invoke("ThirdM", 2.5f);
            Invoke("FourthM", 3.5f);
        }
    }
    void FirstM()
    {
        transform.position = Vector3.Lerp(transform.position, Target1.position, 10.0f * Time.deltaTime);
        
    }
    void SecondM()
    {
        transform.position = Vector3.Lerp(transform.position, Target2.position, 10.0f * Time.deltaTime);
        
    }
    void ThirdM()
    {
        transform.position = Vector3.Lerp(transform.position, Target3.position, 10.0f *  Time.deltaTime);
        
    }
    void FourthM()
    {
        transform.position = Vector3.Lerp(transform.position, Target4.position, 10.0f * Time.deltaTime);
        GameObject.Find("BreakWall").GetComponent<DesPin>().isFirst = false;
    }
}
