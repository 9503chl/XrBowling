using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerInput : MonoBehaviour
{
    [SerializeField] GameObject UI;
    [SerializeField] Image field;
    [SerializeField] Camera mainCamera;

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
        InputColor = new Color(0, 0, 0, alpha1);
        if (power > 0)
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
        if (isNext)
        {
            field.transform.position = mainCamera.transform.position + new Vector3(0, -0.6f, 0.5f);
            field.transform.rotation = mainCamera.transform.rotation;
            field.color = InputColor;
            alpha1 += Time.deltaTime * 0.3f; //알파값 시간에 따라 증가
        }
        if (alpha1 >=1.0f) SceneManager.LoadScene("TitleScene");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ball")
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
            power = collision.transform.rotation.z - 180;
        }
        if(collision.transform.name == "Shoes")
        {
            UI.SetActive(false);
            isNext = true;
        }
    }
}