using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Accel : MonoBehaviour
{
    GameObject maincam;
    [SerializeField]GameObject viewcam;
    float power;
    private Transform tr;
    public bool isMove = false;
    public float speed = 0.0f;
    float spin = 0;
    public int Angle = 0;
    public float time = 0.0f;
    void Awake()
    {
        tr = GetComponent<Transform>();
        maincam = GameObject.Find("Main Camera");
    }
    void FixedUpdate()
    {
        if (isMove)
        {
            maincam.SetActive(false);
            viewcam.SetActive(true);
            viewcam.transform.position = gameObject.transform.position + new Vector3(0, 0.15f, 0);
            time += Time.deltaTime; //������ �ð�
            Angle += 30;
            speed = power;
            if (Angle >= 360) Angle = 0;
            if (GameObject.Find("hall").GetComponent<Dump>().dumpCount == 0 && GameObject.Find("hall2").GetComponent<Dump>().dumpCount == 0) //�������� 2.5��
            {
                if (speed <= -0.15f) //�� ȸ��
                    tr.transform.rotation = Quaternion.Euler(Angle, 0, -Angle);
                else if (speed >= 0.15f) //�� ȸ��
                    tr.transform.rotation = Quaternion.Euler(Angle, 0, Angle);
                else // ��ȸ��
                    tr.transform.rotation = Quaternion.Euler(Angle, 0, 0);
                if (time <= 1.2f) //�밢�� �̵�
                {
                    tr.transform.Translate(new Vector3(speed * 0.3f, 0, 0.6f) * Time.deltaTime * 5.0f, Space.World);
                }
                else if (time <= 3.5f) //ȸ���� õõ�� �ɸ�
                {
                    spin += Time.deltaTime ;
                    tr.transform.Translate(new Vector3(-speed * spin * 0.5f, 0, 0.6f) * Time.deltaTime * 5.0f, Space.World);
                }
            }
            else //���� �������� �����
            {
                tr.transform.Translate(Vector3.forward * 0.6f * Time.deltaTime * 5.0f, Space.World);
                tr.transform.rotation = Quaternion.Euler(Angle, 0, 0);
                maincam.SetActive(true);
                viewcam.SetActive(false);
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