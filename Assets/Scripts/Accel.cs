using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Accel : MonoBehaviour
{
    private Transform tr;
    public bool isMove = false;
    float speed = 0.0f;
    public float time = 0.0f;
    void Start()
    {
        tr = GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        if (isMove)
        {
            speed = Mathf.Clamp(speed, 0, 0.15f);
            speed += Time.deltaTime;
            time += Time.deltaTime; //움직인 시간
            if (GameObject.Find("Text").GetComponent<PlayerInput>().isLeft &&GameObject.Find("hall").GetComponent<Dump>().dumpCount == 0 && GameObject.Find("hall2").GetComponent<Dump>().dumpCount == 0) //도착까지 2.5초
            {
                if (time <= 1.25f)
                {
                    tr.transform.Translate(new Vector3(speed * 0.7f, 0, 0.8f) * Time.deltaTime * 5.0f, Space.World);
                    tr.transform.Rotate(20f, 20f, 20);
                }
                else if (time <= 1.35f)
                {
                    tr.transform.Translate(new Vector3(-speed * 0.7f, 0, 0.8f) * Time.deltaTime * 5.0f, Space.World);
                    tr.transform.Rotate(20f, 20f, 20);
                }
                else if (time <= 2.5f)
                {
                    tr.transform.Translate(new Vector3(-speed * 1.35f, 0, 0.8f) * Time.deltaTime * 5.0f, Space.World);
                    tr.transform.Rotate(20f, 20f, 20);
                }
            }
            else if (GameObject.Find("Text").GetComponent<PlayerInput>().isRight && GameObject.Find("hall").GetComponent<Dump>().dumpCount == 0 && GameObject.Find("hall2").GetComponent<Dump>().dumpCount == 0)
            {
                if (time <= 1.25f)
                {
                    tr.transform.Translate(new Vector3(-speed * 0.7f, 0, 0.8f) * Time.deltaTime * 5.0f, Space.World);
                    tr.transform.Rotate(20f, -20f, 20);
                }
                else if (time <= 1.35f)
                {
                    tr.transform.Translate(new Vector3(-speed * 0.7f, 0, 0.8f) * Time.deltaTime * 5.0f, Space.World);
                    tr.transform.Rotate(20f, -20f, 20);
                }
                else if (time <= 2.5f)
                {
                    tr.transform.Translate(new Vector3(speed * 1.35f, 0, 0.8f) * Time.deltaTime * 5.0f, Space.World);
                    tr.transform.Rotate(20f, -20f, 20);
                }
            }
            else
            {
                tr.transform.Translate(Vector3.forward * 0.8f * Time.deltaTime * 5.0f, Space.World);
                tr.transform.Rotate(20, 0, 0);
            }
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Floor")
        {
            isMove = true;
            GameObject.Find("Text").GetComponent<PlayerInput>().isMove = true;
        }
    }
}