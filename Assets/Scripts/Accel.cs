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
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        speed = Mathf.Clamp(speed,0, 0.12f);
        speed += Time.deltaTime;
        if (isMove)
        {
            if (isLeft)
            {
                tr.transform.Translate(new Vector3(-speed, 0, 1) * Time.deltaTime * 5.0f, Space.World); 
                tr.transform.Rotate(10, -10f, 10);
            }
            else if (isRight)
            {
                tr.transform.Translate(new Vector3(speed,0,1) * Time.deltaTime * 5.0f, Space.World);
                tr.transform.Rotate(10, 10f, 10);
            }
            else
            {
                tr.transform.Translate(Vector3.forward * Time.deltaTime * 5.0f, Space.World);
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
