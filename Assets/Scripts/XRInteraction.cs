using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class XRInteraction : MonoBehaviour
{
    [SerializeField] GameObject Panel1;
    [SerializeField] GameObject UI;
    [SerializeField] Image field1;
    [SerializeField] Image field2;
    [SerializeField] Image field3;
    [SerializeField] Image field4;
    [SerializeField] Image field5;
    [SerializeField] Image field6;

    bool Active1 = false;
    bool isNext = false;
    bool isblack = false;
    Color InputColor = new Color(0, 0, 0, 0);
    float alpha1 = 0;
    int count = 0;
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Ball")// 공 그랩시
        {
            Destroy(other.gameObject);
            UI.SetActive(false); //켜져있으면 끄기
            isNext = true;
            if (Active1 == true) Panel1.SetActive(false);
        }
        if (other.transform.name == "Shoes")// 신발그랩시
        {
            Destroy(other.gameObject);
            UI.SetActive(false);
            isNext = true;
            if (Active1 == true) Panel1.SetActive(false);
            if (!isblack) isblack = true;
        }
        if (other.transform.name == "Pinp") //핀 그랩시
        {
            Destroy(other.gameObject);
            count++;
            if (!Active1) //토글
            {
                Panel1.SetActive(true);
                Active1 = true;
            }
            else
            {
                Panel1.SetActive(false);
                Active1 = false;
            }
        }
    }
    private void FixedUpdate()
    {
        if(isblack) InputColor = new Color(0, 0, 0, alpha1); //검정색으로 변환
        else InputColor = new Color(255, 255, 255, alpha1);
        if (isNext) //위치 고정
        {
            field1.transform.position = gameObject.transform.position + new Vector3(0, -0.6f, 2f);
            field2.transform.position = gameObject.transform.position + new Vector3(0, -0.6f, -2f);
            field3.transform.position = gameObject.transform.position + new Vector3(0, 1.4f, 0);
            field4.transform.position = gameObject.transform.position + new Vector3(0, -0.6f, 0);
            field5.transform.position = gameObject.transform.position + new Vector3(2f, -0.6f, 0);
            field6.transform.position = gameObject.transform.position + new Vector3(-2f, -0.6f, 0);
            field1.color = InputColor; field2.color = InputColor; field3.color = InputColor;
            field4.color = InputColor; field5.color = InputColor; field6.color = InputColor;
            alpha1 += Time.deltaTime * 0.3f; //알파값 시간에 따라 증가
        }
        if (count == 10) //핀다쓸시 다시 생성
        {
            GameObject.Find("Magnet").GetComponent<MagnetMove>().count = 3;
            count = 0;
        }
        if (isblack && alpha1 >= 1.0f) Application.Quit();
        else if (alpha1 >= 1.0f) SceneManager.LoadScene("SampleScene");
    }
}
