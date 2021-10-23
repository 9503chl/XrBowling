using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{
    public Transform Target1;
    public Transform Target2;
    public Transform Target3;
    public Transform Target4;
    void FixedUpdate()
    {
        //if (GameObject.Find("BreakWall").GetComponent<DesPin>().isFirst)
        {
            Invoke("FirstM", 0.5f);
            if (gameObject.transform.position.y - Target1.position.y == 0) SecondM();
            if (gameObject.transform.position.z - Target2.position.z == 0) ThirdM();
            if (gameObject.transform.position.y - Target3.position.y == 0) FourthM();
        }
    }
    void FirstM()
    {
        transform.position = Vector3.Slerp(transform.position, Target1.position, 10.0f *Time.deltaTime);
        
    }
    void SecondM()
    {
        transform.position = Vector3.Slerp(transform.position, Target2.position, 10.0f * Time.deltaTime);
        
    }
    void ThirdM()
    {
        transform.position = Vector3.Slerp(transform.position, Target3.position, 10.0f *Time.deltaTime);
        
    }
    void FourthM()
    {
        transform.position = Vector3.Slerp(transform.position, Target4.position, 10.0f* Time.deltaTime);
        GameObject.Find("BreakWall").GetComponent<DesPin>().isFirst = false;
    }
}
