using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Accel : MonoBehaviour
{
    float power;
    private Transform tr;
    public bool isMove = false;
    public float speed = 0.0f;
    float spin = 0;
    int Angle = 0;
    public float time = 0.0f;
    void Awake()
    {
        tr = GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        if (isMove)
        {
            time += Time.deltaTime; //움직인 시간
            Angle += 30;
            speed = power;
            if (Angle >= 360) Angle = 0;
            if (GameObject.Find("hall").GetComponent<Dump>().dumpCount == 0 && GameObject.Find("hall2").GetComponent<Dump>().dumpCount == 0) //도착까지 2.5초
            {
                if (speed < -0.15f) //오
                {
                    tr.transform.rotation = Quaternion.Euler(Angle, 0, -Angle);
                }
                else if (speed > 0.15f) //왼
                {
                    tr.transform.rotation = Quaternion.Euler(Angle, 0, Angle);
                }
                if (time <= 1.2f)
                {
                    tr.transform.Translate(new Vector3(speed * 0.4f, 0, 0.6f) * Time.deltaTime * 5.0f, Space.World);
                }
                else if (time <= 3.5f)
                {
                    spin += Time.deltaTime * 1.1f;
                    tr.transform.Translate(new Vector3(-speed * spin * 0.5f, 0, 0.6f) * Time.deltaTime * 5.0f, Space.World);
                }
            }
            else
            {
                tr.transform.Translate(Vector3.forward * 0.6f * Time.deltaTime * 5.0f, Space.World);
                tr.transform.rotation = Quaternion.Euler(Angle, 0, 0);
            }
        }
        else power = GameObject.Find("RightHand Controller").GetComponent<PlayerInput>().power;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Floor")
        {
            isMove = true;
            GameObject.Find("RightHand Controller").GetComponent<PlayerInput>().isMove = true;
        }
    }
}