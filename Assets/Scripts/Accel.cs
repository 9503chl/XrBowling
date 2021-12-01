using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accel : MonoBehaviour
{
    private Transform tr;
    public bool isMove = false;
    public bool isLeft = false;
    public bool isRight = false;
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        if (isMove)
        {
            if (isLeft)
            {
                tr.transform.Translate(new Vector3(0, -0.1f, 1) * Time.deltaTime * 5.0f, Space.World);
                tr.transform.Rotate(10, -10f, 0);
            }
            else if (isRight)
            {
                tr.transform.Translate(new Vector3(0,0.1f,1) * Time.deltaTime * 5.0f, Space.World);
                tr.transform.Rotate(10, 10f, 0);
            }
            else
            {
                tr.transform.Translate(Vector3.forward * Time.deltaTime * 5.0f, Space.World);
                tr.transform.Rotate(10, 0, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.A)) //¾È ¸ÔÈù´Ù
        {
            isLeft = true;
        }
        if (Input.GetKeyDown(KeyCode.D)) // ¾È¸ÔÈù´Ù.
        {
            isRight = true;
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
