using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetMove : MonoBehaviour
{
    public Transform Target4;
    public Transform Target5;
    public Transform spawnTr;
    public GameObject Pin;
    GameObject pinClone;

    bool Once = true;
    public bool isMagnetMove = false, Twice = false;

    public int count = 0;
    void Update()
    {
        if (GameObject.Find("BreakWall").GetComponent<DesPin>().isFirst && count < 2) //첫번째
        {
            if (Once) 
            {
                Invoke("FirstM", 0.9f);
            }
            if (Vector3.Distance(gameObject.transform.position, Target4.transform.position) <= 0.1f)
            {
                Invoke("SecondM", 1.0f); Once = false; Twice = true;
            }
            if (Vector3.Distance(gameObject.transform.position, Target5.transform.position) <= 0.1f && Twice)
            {
                isMagnetMove = true;
                Once = true; Twice = false;
                GameObject.Find("BreakWall").GetComponent<DesPin>().isFirst = false;
            }      
        }

        if (GameObject.Find("CoverWall").GetComponent<CleanUp>().isDone && count < 2) //두번째
        {
            if (Once)
            {
                Invoke("FirstM", 0.9f);
            }
            if (Vector3.Distance(gameObject.transform.position, Target4.transform.position) <= 0.1f)
            {
                Invoke("SecondM", 1.0f); Once = false; Twice = true;
            }
            if (Vector3.Distance(gameObject.transform.position, Target5.transform.position) <= 0.1f && Twice)
            {
                Once = true; Twice = false;
                GameObject.Find("CoverWall").GetComponent<CleanUp>().isDone = false;
            }
        }
        if(count == 3)
        {
            Destroy(GameObject.FindWithTag("Pin")); //이전거 삭제
            count++;
            GameObject.Find("CoverWall").GetComponent<CleanUp>().isDone = true;
        }
        if(count == 4) //핀 다지워지고
        {
            if (GameObject.FindWithTag("Pin") == null) //못 찾으면
            {
                Instantiate(Pin, spawnTr.position, spawnTr.rotation); //스폰이 안됨
                pinClone = GameObject.FindWithTag("Pin"); 
            }
            if (Once)
            {
                Invoke("FirstM", 0.5f);
                for (int i = 0; i < 10; i++)
                {
                    pinClone.transform.GetChild(i).transform.localEulerAngles = new Vector3(270, 0, 0);
                }
            }
            if (Vector3.Distance(gameObject.transform.position, Target4.transform.position) <= 0.1f)
            {
                Invoke("SecondM", 1.0f); Once = false; Twice = true;
                for (int i = 0; i < 10; i++)
                {
                    pinClone.transform.GetChild(i).transform.localEulerAngles = new Vector3(270, 0, 0);
                }
            }

            if (Vector3.Distance(gameObject.transform.position, Target5.transform.position) <= 0.1f && Twice)
            {
                Once = true; Twice = false;
                count = 0;
                GameObject.Find("BreakWall").GetComponent<DesPin>().isFirst = false;
                GameObject.Find("CoverWall").GetComponent<CleanUp>().isDone = false;
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
