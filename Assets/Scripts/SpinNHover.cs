using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpinNHover : MonoBehaviour
{
    Vector3 prePos;
    Vector3 MovePos;
    bool isdown = false;
    bool isdown1 = false;
    public bool isMove = false;
    int speed = 3;
    int Angle = 0;
    void Start()
    {
        prePos = transform.position;
        MovePos = transform.position - new Vector3(0, 0.5f, 0);
    }

    void FixedUpdate()
    {
        if (Angle >= 360) Angle = 0;
        Angle += 5;
        gameObject.transform.rotation = Quaternion.Euler(0, Angle, 0);
        if (gameObject.name == "Shoes")
        {
            if (!isdown)
            {
                if (Vector3.Distance(transform.position, MovePos) <= 0.1f) isdown = true;
                transform.position = Vector3.Lerp(transform.position, MovePos, speed * Time.deltaTime);

            }
            else
            {
                if (Vector3.Distance(transform.position, prePos) <= 0.1f) isdown = false;
                transform.position = Vector3.Lerp(transform.position, prePos, speed * Time.deltaTime);
            }
        }
        if (!isMove) {
            if (gameObject.name == "BowlingBall")
            {
                if (!isdown1)
                {
                    if (Vector3.Distance(transform.position, MovePos) <= 0.1f) isdown1 = true;
                    transform.position = Vector3.Lerp(transform.position, MovePos, speed * Time.deltaTime);

                }
                else
                {
                    if (Vector3.Distance(transform.position, prePos) <= 0.1f) isdown1 = false;
                    transform.position = Vector3.Lerp(transform.position, prePos, speed * Time.deltaTime);
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
       if(collision.transform.name == "RightHand Controller" && gameObject.tag == "Ball")
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        } 
    }
}
