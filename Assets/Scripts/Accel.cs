using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accel : MonoBehaviour
{
    private Transform tr;
    public bool isMove = false;
    
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        if (isMove)
        {
            tr.transform.Translate(Vector3.forward * Time.deltaTime * 5.0f, Space.World);
            tr.transform.Rotate(10, 0, 0);
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
