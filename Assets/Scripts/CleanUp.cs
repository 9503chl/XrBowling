using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{
    public Transform Target1;
    public Transform Target2;
    public Transform Target3;
    bool Once1 = true, Once2 = false, Once3 = false;
    public bool isDone = false;

    void FixedUpdate()
    { 
        if (GameObject.Find("Magnet").GetComponent<MagnetMove>().isMagnetMove) //ù��° ������ ���峲
        {
            if (Once1) Invoke("FirstM", 0.5f);
            if (Vector3.Distance(gameObject.transform.position, Target1.transform.position) <= 0.05f)
            {
                Once1 = false; Once2 = true;
                Invoke("SecondM", 1.0f);
            }
            if (Vector3.Distance(gameObject.transform.position, Target2.transform.position) <= 0.05f && Once2)
            {
                Once3 = true;
                Invoke("ThirdM", 1.2f);
            }
            if (Vector3.Distance(gameObject.transform.position, Target3.transform.position) <= 0.05f && Once3)
            {
                GameObject.Find("Magnet").GetComponent<MagnetMove>().isMagnetMove = false;
                Once1 = true; Once2 = false; Once3 = false; isDone = true;
            }
        }
        if (GameObject.Find("Magnet").GetComponent<MagnetMove>().count == 2) //�ι�° ������
        {
            if (Once1) Invoke("FirstM", 0.5f);
            if (Vector3.Distance(gameObject.transform.position, Target1.transform.position) <= 0.05f)
            {
                Once1 = false; Once2 = true;
                Invoke("SecondM", 1.0f);
            }
            if (Vector3.Distance(gameObject.transform.position, Target2.transform.position) <= 0.05 && Once2)
            {
                Once3 = true;
                Invoke("ThirdM", 1.2f);
            }
            if (Vector3.Distance(gameObject.transform.position, Target3.transform.position) <= 0.05f && Once3)
            {
                Once1 = true; Once2 = false; Once3 = false;
                GameObject.Find("Magnet").GetComponent<MagnetMove>().count++;
            }
        }
    }
    void FirstM()
    {
        transform.position = Vector3.Lerp(transform.position, Target1.position, 10f * Time.deltaTime);
    }
    void SecondM()
    {
        transform.position = Vector3.Lerp(transform.position, Target2.position, 8f * Time.deltaTime);
    }
    void ThirdM()
    {
        transform.position = Vector3.Lerp(transform.position, Target3.position, 10f * Time.deltaTime);
    }
}