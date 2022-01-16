using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerInput : MonoBehaviour
{
    [SerializeField] GameObject UI;
    [SerializeField] GameObject sphere;
    [SerializeField] Camera mainCamera;
    [SerializeField] Material mat;
    [SerializeField] GameObject Hands;

    float alpha1 = 0;
    bool isNext = false;
    Color InputColor = new Color(0, 0, 0, 0);
    public bool isLeft = false;
    public bool isRight = false;
    public bool isNormal = false;
    public bool isMove = false;
    public float power = 0;

    private void FixedUpdate()
    {
        power = gameObject.transform.rotation.z;
        InputColor = new Color(0, 0, 0, alpha1);
        if (power > 0.15)
        {
            isRight = false;
            isLeft = true;
            isNormal = false;
        }
        else if (power < -0.15)
        {
            isRight = true;
            isLeft = false;
            isNormal = false;
        }
        else
        {
            isRight = false;
            isLeft = false;
            isNormal = true;
        }
        if (isNext)
        {
            sphere.transform.position = mainCamera.transform.position + new Vector3(0, -0.4f, 0);
            mat.color = InputColor;
            alpha1 += Time.deltaTime * 0.3f; //���İ� �ð��� ���� ����
        }
        if (alpha1 >=1.0f) SceneManager.LoadScene("TitleScene");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ball")
        {
            Hands.transform.rotation = Quaternion.Euler(180, 0, 0); //�յ�����
            power = collision.transform.rotation.z - 180;
        }
        if(collision.transform.name == "Shoes")
        {
            UI.SetActive(false);
            isNext = true;
        }
    }
    private void OnCollisionExit(Collision collision) //���󺹱�
    {
        if(collision.transform.tag == "Ball") Hands.transform.rotation = Quaternion.Euler(180, 0, 0);
    }
}