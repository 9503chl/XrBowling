using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{
    public Transform Target1;
    public Transform Target2;
    public Transform Target3;
    bool Once1 = true, Once2 = false, Once3 = false;
    void Update()
    {
        if (GameObject.Find("Magnet").GetComponent<MagnetMove>().isMagnetMove)
        {
            if (Once1) Invoke("FirstM", 0.5f);
            if (Vector3.Distance(gameObject.transform.position, Target1.transform.position) <= 0.1f)
            {
                Once1 = false; Once2 = true;
                Invoke("SecondM", 0.5f);
            }
            if (Vector3.Distance(gameObject.transform.position, Target2.transform.position) <= 0.1f && Once2)
            {
                Once3 = true;
                Invoke("ThirdM", 0.5f);
            }
            if (Vector3.Distance(gameObject.transform.position, Target3.transform.position) <= 0.1f && Once3)
            {
                GameObject.Find("Magnet").GetComponent<MagnetMove>().isMagnetMove = false;
                Once2 = false; Once3 = false;
            }
        }
    }
    void FirstM()
    {
        transform.position = Vector3.Lerp(transform.position, Target1.position, 10.0f * Time.deltaTime);

    }
    void SecondM()
    {
        transform.position = Vector3.Lerp(transform.position, Target2.position, 3.0f * Time.deltaTime);

    }
    void ThirdM()
    {
        transform.position = Vector3.Lerp(transform.position, Target3.position, 8.0f * Time.deltaTime);
        
    }
}