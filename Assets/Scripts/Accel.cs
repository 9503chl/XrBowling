using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accel : MonoBehaviour
{
    private Rigidbody rg;
    public bool isMove = false;
    
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isMove) rg.velocity = Vector3.forward * 5.0f;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Floor")
        {
            isMove = true;
        }
    }
}
