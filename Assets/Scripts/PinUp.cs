using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinUp : MonoBehaviour
{
    Vector3 pos1;
    Vector3 pos2;
    Rigidbody rg;
    void Start()
    {
        pos1 = transform.position + new Vector3(0, 0.65f, 0);
        pos2 = transform.position;
        rg = GetComponent<Rigidbody>();
    }
    void Update() 
    {
        if (gameObject.transform.rotation.eulerAngles.x > 330 || gameObject.transform.rotation.eulerAngles.x < 7.5)
        {
            rg.useGravity = true;
            gameObject.GetComponent<PinUp>().enabled = false;
        }
        if (!GameObject.Find("CoverWall").GetComponent<CleanUp>().isDone && GameObject.Find("Magnet").GetComponent<MagnetMove>().Twice) //업
        {
            rg.useGravity = false; Invoke("SecondM", 1.0f);
        }
        if(Vector3.Distance(gameObject.transform.position, pos1) <= 0.1f) //각도 고정
        {
            gameObject.transform.localEulerAngles = new Vector3(270, 0, 0);
        }
        if (GameObject.Find("CoverWall").GetComponent<CleanUp>().isDone && GameObject.Find("Magnet").GetComponent<MagnetMove>().count !=4) 
        {
            rg.useGravity = false; gameObject.transform.localEulerAngles = new Vector3(270, 0, 0); //각도 설정
            Invoke("FirstM", 0.9f);
            Invoke("GravityOn", 1.2f);
        }
        if (Vector3.Distance(gameObject.transform.position, pos2) <= 0.1f) //각도 고정
        {
            gameObject.transform.localEulerAngles = new Vector3(270, 0, 0);
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
    void GravityOn()
    {
        rg.useGravity = true;
    }
    void OnCollisionEnter(Collision other)//충돌하면 위치 재설정
    {
        if (other.gameObject.tag == "Ball" || other.gameObject.tag == "Pin")
        {
            pos1 = transform.position + new Vector3(0, 0.65f, 0);
            pos2 = transform.position;
        }
    }
}
