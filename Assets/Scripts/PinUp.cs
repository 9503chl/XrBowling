using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinUp : MonoBehaviour
{
    Vector3 pos1;
    Vector3 pos2;
    Vector3 pos3;
    Rigidbody rg;
    void Start()
    {
        pos1 = transform.position + new Vector3(0, 0.65f, 0);
        pos2 = transform.position;
        pos3 = transform.position - new Vector3(0, 1.058f, 0);
        rg = GetComponent<Rigidbody>();
    }
    void Update() 
    {
        if (gameObject.transform.rotation.eulerAngles.x > 315 || gameObject.transform.rotation.eulerAngles.x < 7.5) gameObject.GetComponent<PinUp>().enabled = false;
        if (!GameObject.Find("CoverWall").GetComponent<CleanUp>().isDone && GameObject.Find("Magnet").GetComponent<MagnetMove>().Twice) //¾÷
        {
            rg.useGravity = false;
            Invoke("SecondM", 1.0f);
        }
        if (GameObject.Find("CoverWall").GetComponent<CleanUp>().isDone) // ´Ù¿î
        {
            Invoke("FirstM", 0.9f);
            Invoke("GravityOn", 1.2f);
        } 
        if(GameObject.Find("Magnet").GetComponent<MagnetMove>().count == 3)
        {
            Invoke("ThirdM", 0.9f);
            Invoke("GravityOn", 1.2f);
        }
    }
    void FirstM()
    {
        transform.position = Vector3.Lerp(transform.position, pos2, 6.0f * Time.deltaTime);
    }
    void SecondM()
    {
        transform.position = Vector3.Lerp(transform.position, pos1, 6.0f * Time.deltaTime);
    }
    void ThirdM()
    {
        transform.position = Vector3.Lerp(transform.position, pos3 , 6.0f * Time.deltaTime);
    }
    void GravityOn()
    {
        rg.useGravity = true;
    }
}
