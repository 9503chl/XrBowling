using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accel : MonoBehaviour
{
    private Transform tr;
    public bool isMove = false;
    public bool isLeft = false;
    public bool isRight = false;
    public bool isbuttonDown = false;
    float speed = 0.0f;
    public float time = 0.0f;
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        if (isMove)
        {
            speed = Mathf.Clamp(speed, 0, 0.15f);
            speed += Time.deltaTime;
            time += Time.deltaTime; //움직인 시간
            if (isLeft && !GameObject.FindWithTag("Dump").GetComponent<Dump>().isDumped) //도착까지 2.5초
            {
                if(time <= 1.24f)
                {
                    tr.transform.Translate(new Vector3(speed * 0.9f , 0, 0.8f) * Time.deltaTime * 5.0f, Space.World); //속도조정 필요
                    tr.transform.Rotate(10, 10f, 10);
                }
                
                else if(time <= 1.26f)
                {
                    tr.transform.Translate(Vector3.forward * 0.8f * Time.deltaTime * 5.0f, Space.World);
                    tr.transform.Rotate(10, 0, 0);
                }
                else if (time <= 2.5f)
                {
                    tr.transform.Translate(new Vector3(-speed*0.7f, 0, 0.8f) * Time.deltaTime * 5.0f, Space.World);
                    tr.transform.Rotate(10, -10f, 10);
                }
            }
            else if (isRight && !GameObject.FindWithTag("Dump").GetComponent<Dump>().isDumped)
            {
                if (time <= 1.24f)
                {
                    tr.transform.Translate(new Vector3(-speed * 0.9f, 0, 0.8f) * Time.deltaTime * 5.0f, Space.World);
                    tr.transform.Rotate(10, -10f, 10);
                }

                else if (time <= 1.26f)
                {
                    tr.transform.Translate(Vector3.forward * 0.8f * Time.deltaTime * 5.0f, Space.World);
                    tr.transform.Rotate(10, 0, 0);
                }
                else if (time <= 2.5f)
                {
                    tr.transform.Translate(new Vector3(speed * 0.7f, 0, 0.8f) * Time.deltaTime * 5.0f, Space.World);
                    tr.transform.Rotate(10, 10f, 10);
                }
            }
            else
            {
                tr.transform.Translate(Vector3.forward *0.8f * Time.deltaTime * 5.0f, Space.World);
                tr.transform.Rotate(10, 0, 0);
            }
        }
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            if (!isbuttonDown)
            {
                isLeft = true;
                isbuttonDown = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            if (!isbuttonDown)
            {
                isRight = true;
                isbuttonDown = true;
            }
        }
#endif
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            if (!isbuttonDown)
            {
                isLeft = true;
                isbuttonDown = true;
            }
        }
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            if (!isbuttonDown)
            {
                isRight = true;
                isbuttonDown = true;
            }
        }
 }
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Floor")
        {
            isMove = true;
        }
    }
}
