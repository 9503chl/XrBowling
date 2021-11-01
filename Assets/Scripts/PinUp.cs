using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinUp : MonoBehaviour
{
    Vector3 pos;
    Rigidbody rg;
    void Start()
    {
        pos = transform.position + new Vector3(0, 0.65f, 0);
        rg = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (GameObject.Find("Magnet").GetComponent<MagnetMove>().Twice) //¾÷
        {
            rg.useGravity = false;
            Invoke("SecondM", 1.0f);
        }
        if (GameObject.Find("CoverWall").GetComponent<CleanUp>().isDone) // ´Ù¿î
        {
            rg.useGravity = true;
            Invoke("FirstM", 1.0f);
        }
    }
    void FirstM()
    {
        transform.position = Vector3.Lerp(transform.position, pos, 6.0f * Time.deltaTime);
    }
    void SecondM()
    {
        transform.position = Vector3.Lerp(transform.position, pos, 6.0f * Time.deltaTime);

    }
}
