using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerInput : MonoBehaviour
{
    public bool isLeft = false;
    public bool isRight = false;
    public bool isNormal = false;
    public bool isMove = false;
    public float power = 0;

    private void Update()
    {
        if(power > 0)
        {
            isRight = true;
            isLeft = false;
            isNormal = false;
        }
        else if (power < 0)
        {
            isRight = false;
            isLeft = true;
            isNormal = false;
        }
        else if (power == 0)
        {
            isRight = false;
            isLeft = false;
            isNormal = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ball")
        {
            power = collision.transform.rotation.z - 180;
        }
    }
}