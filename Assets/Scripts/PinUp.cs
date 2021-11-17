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
    void FixedUpdate() 
    {
        if (GameObject.Find("BreakWall").GetComponent<DesPin>().isCollide) //��ġ ����
        {
            pos1 = transform.position;
            pos2 = transform.position;
            GameObject.Find("BreakWall").GetComponent<DesPin>().isCollide = false;
        }
        if (gameObject.transform.rotation.eulerAngles.x > 330 || gameObject.transform.rotation.eulerAngles.x < 7.5)
        {
            rg.useGravity = true;
            gameObject.GetComponent<PinUp>().enabled = false;
        }
        if (!GameObject.Find("CoverWall").GetComponent<CleanUp>().isDone && GameObject.Find("Magnet").GetComponent<MagnetMove>().Twice) //��
        {
            rg.useGravity = false; Invoke("SecondM", 0.5f);
        }
        if(Vector3.Distance(gameObject.transform.position, pos1) <= 0.1f) //���� ����
        {
            gameObject.transform.localEulerAngles = new Vector3(270, 0, 0);
            gameObject.GetComponent<MeshCollider>().isTrigger = true;
        }
        if (GameObject.Find("CoverWall").GetComponent<CleanUp>().isDone && GameObject.Find("Magnet").GetComponent<MagnetMove>().count !=4) //�ٿ�
        {
            rg.useGravity = false; gameObject.transform.localEulerAngles = new Vector3(270, 0, 0); //���� ����
            gameObject.GetComponent<MeshCollider>().isTrigger = false;
            Invoke("FirstM", 0.5f);
            Invoke("GravityOn", 1.2f);
        }
    }
    void FirstM()
    {
        transform.position = Vector3.Lerp(transform.position, pos2, 50f * Time.deltaTime);
    }
    void SecondM()
    {
        transform.position = Vector3.Lerp(transform.position, pos1, 50f * Time.deltaTime);
    }
    void GravityOn()
    {
        rg.useGravity = true;
    }
}
