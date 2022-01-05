using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Accel : MonoBehaviour
{
    private Transform tr;
    public bool isMove = false;
    float speed = 0.0f;
    int Angle = 0;
    public float time = 0.0f;
    bool isLeft = false;
    bool isRight = false;
    bool isNormal = false;
    void Start()
    {
        tr = GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        Debug.Log("isleft = " + isLeft);
        Debug.Log("isRight = " +isRight);
        Debug.Log("isNormal = " +isNormal);
        if (isMove)
        {
           speed = Mathf.Clamp(speed, 0, 0.15f);
           speed += Time.deltaTime;
           time += Time.deltaTime; //움직인 시간
           Angle += 20;
           if (Angle >= 360) Angle = 0;
           if (GameObject.Find("XR Rig").GetComponent<PlayerInput>().isRight)
            {
                isRight = true;
                isLeft = false;
                isNormal = false;
            }
           if (GameObject.Find("XR Rig").GetComponent<PlayerInput>().isLeft)
            {
                isRight = false;
                isLeft = true;
                isNormal = false;
            }
           if (GameObject.Find("XR Rig").GetComponent<PlayerInput>().isNormal)
            {
                isRight = false;
                isLeft = false;
                isNormal = true;
            }
           if (isLeft &&GameObject.Find("hall").GetComponent<Dump>().dumpCount == 0 && GameObject.Find("hall2").GetComponent<Dump>().dumpCount == 0) //도착까지 2.5초
            {
                if (time <= 1.25f)
                {
                    tr.transform.Translate(new Vector3(speed * 0.7f, 0, 0.8f) * Time.deltaTime * 5.0f, Space.World);
                    tr.transform.rotation = Quaternion.Euler(Angle, 0, Angle);
                }
                else if (time <= 1.35f)
                {
                    tr.transform.Translate(new Vector3(-speed * 0.7f, 0, 0.8f) * Time.deltaTime * 5.0f, Space.World);
                    tr.transform.rotation = Quaternion.Euler(Angle, 0, Angle);
                }
                else if (time <= 2.5f)
                {
                    tr.transform.Translate(new Vector3(-speed * 1.35f, 0, 0.8f) * Time.deltaTime * 5.0f, Space.World);
                    tr.transform.rotation = Quaternion.Euler(Angle, 0, Angle);
                }
            }
            else if (isRight && GameObject.Find("hall").GetComponent<Dump>().dumpCount == 0 && GameObject.Find("hall2").GetComponent<Dump>().dumpCount == 0)
            {
                if (time <= 1.25f)
                {
                    tr.transform.Translate(new Vector3(-speed * 0.7f, 0, 0.8f) * Time.deltaTime * 5.0f, Space.World);
                    tr.transform.rotation = Quaternion.Euler(Angle, -Angle, Angle);
                }
                else if (time <= 1.35f)
                {
                    tr.transform.Translate(new Vector3(-speed * 0.7f, 0, 0.8f) * Time.deltaTime * 5.0f, Space.World);
                    tr.transform.rotation = Quaternion.Euler(Angle, -Angle, Angle);
                }
                else if (time <= 2.5f)
                {
                    tr.transform.Translate(new Vector3(speed * 1.35f, 0, 0.8f) * Time.deltaTime * 5.0f, Space.World);
                    tr.transform.rotation = Quaternion.Euler(Angle, -Angle, Angle);
                }
            }
            else
            {
                tr.transform.Translate(Vector3.forward * 0.8f * Time.deltaTime * 5.0f, Space.World);
                tr.transform.rotation = Quaternion.Euler(Angle, 0, 0);
            }
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Floor")
        {
            isMove = true;
            GameObject.Find("XR Rig").GetComponent<PlayerInput>().isMove = true;
        }
    }
}