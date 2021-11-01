using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetMove : MonoBehaviour
{
    public Transform Target4;
    public Transform Target5;
    bool Once = true; 
    public bool isMagnetMove = false, Twice = false;
    
    void Update()
    {
        if (GameObject.Find("BreakWall").GetComponent<DesPin>().isFirst)

        {
            if (GameObject.Find("CoverWall").GetComponent<CleanUp>().isDone) //두번째
            {
                Once = true; Twice = false;
                GameObject.Find("CoverWall").GetComponent<CleanUp>().isDone = false;
            }
            if (Once) //첫번째
            {
                Invoke("FirstM", 0.5f);
            }
            if (Vector3.Distance(gameObject.transform.position, Target4.transform.position) <= 0.1f)
            {
                Invoke("SecondM", 1.0f); Once = false; Twice = true;
            }
            if (Vector3.Distance(gameObject.transform.position, Target5.transform.position) <= 0.1f && Twice)
            {
                if (!GameObject.Find("CoverWall").GetComponent<CleanUp>().isDone)
                {
                    isMagnetMove = true;
                    GameObject.Find("BreakWall").GetComponent<DesPin>().isFirst = false;
                }
                else 
                {
                    GameObject.Find("BreakWall").GetComponent<DesPin>().isFirst = false;
                    isMagnetMove = false;
                    GameObject.Find("CoverWall").GetComponent<CleanUp>().isDone = true;
                }
                Once = true; Twice = false;
            }
        }
    }
    void FirstM()
    {
        transform.position = Vector3.Lerp(transform.position, Target4.position, 6.0f * Time.deltaTime);
    }
    void SecondM()
    {
        transform.position = Vector3.Lerp(transform.position, Target5.position, 6.0f * Time.deltaTime);
        
    }
}
