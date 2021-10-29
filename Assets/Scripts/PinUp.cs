using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinUp : MonoBehaviour
{
    Vector3 pos;
    void Start()
    {
        pos = transform.position + new Vector3(0, 0.65f, 0);
    }
    void Update()
    {
        if (GameObject.Find("Magnet").GetComponent<MagnetMove>().Twice) //¾÷
        {
            Invoke("SecondM", 1.0f);
        }
        if (GameObject.Find("CoverWall").GetComponent<CleanUp>().isDone) // ´Ù¿î
        {
            Invoke("FirstM", 0.5f);
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
