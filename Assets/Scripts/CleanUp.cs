using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{
    public Transform Target1;
    public Transform Target2;
    public Transform Target3;
    public Transform Target4;

    bool sequence1 = false;
    bool sequence2 = false;
    bool sequence3 = false;
    
    void Update()
    {
        //if (GameObject.Find("BreakWall").GetComponent<DesPin>().isFirst)
        {
            Debug.Log(sequence1);
            Invoke("FirstM", 0.5f);
            if(sequence1) SecondM();
            if (sequence2) ThirdM();
            if (sequence3) FourthM();
        }
    }
    void FirstM()
    {
        transform.Translate(Vector3.down * Time.deltaTime);
        if (gameObject.transform.position.y <= Target1.position.y)
        {
            sequence1 = true;
            return;
        }
    }
    void SecondM()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
        if (gameObject.transform.position.z <= Target2.position.z) 
        {
            sequence2 = true;
            return;
        }
    }
    void ThirdM()
    {
        transform.Translate(Vector3.up * Time.deltaTime);
        if (gameObject.transform.position.y <= Target3.position.y && sequence2)
        {
            sequence3 = true;
            return;
        }
    }
    void FourthM()
    {
        transform.Translate(Vector3.back * Time.deltaTime);
        GameObject.Find("BreakWall").GetComponent<DesPin>().isFirst = false;
        sequence1 = false; sequence2 = false; sequence3 = false;
    }
}
