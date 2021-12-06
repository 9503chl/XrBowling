using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Accel : MonoBehaviour
{
    private Transform tr;
    public XRController controller = null;
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

    void FixedUpdate()
    {
        if (isMove)
        {
            speed = Mathf.Clamp(speed, 0, 0.15f);
            speed += Time.deltaTime;
            time += Time.deltaTime; //움직인 시간
            if (isLeft && !GameObject.FindWithTag("Dump").GetComponent<Dump>().isDumped) //도착까지 2.5초
            {
                if(time <= 1.25f)
                {
                    tr.transform.Translate(new Vector3(speed * 0.7f , 0, 0.8f) * Time.deltaTime * 5.0f, Space.World); 
                    tr.transform.Rotate(20f, 20f, 20);
                }
                
                else if(time <= 1.35f)
                {
                    tr.transform.Translate(new Vector3(-speed * 0.7f, 0, 0.8f) * Time.deltaTime * 5.0f, Space.World);
                    tr.transform.Rotate(20f, 20f, 20);
                }
                else if (time <= 2.5f)
                {
                    tr.transform.Translate(new Vector3(-speed*1.35f, 0, 0.8f) * Time.deltaTime * 5.0f, Space.World);
                    tr.transform.Rotate(20f, 20f, 20);
                }
            }
            else if (isRight && !GameObject.FindWithTag("Dump").GetComponent<Dump>().isDumped)
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
                tr.transform.Translate(Vector3.forward *0.8f * Time.deltaTime * 5.0f, Space.World);
                tr.transform.Rotate(20, 0, 0);
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
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondry))//B
        {
            if (!isbuttonDown)
            {
                isLeft = true;
                isbuttonDown = true;
            }
        }
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary)) //A
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
