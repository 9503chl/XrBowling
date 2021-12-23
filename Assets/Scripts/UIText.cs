using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Text))]
public class UIText : MonoBehaviour
{
    Text uiText;
    private void Start()
    {
        uiText = GetComponent<Text>();
    }
    void Update()
    {
        if(GameObject.Find("XR Rig").GetComponent<PlayerInput>().isLeft)
        {
            uiText.DOFade(100, 0.1f);
            uiText.text = string.Format("���� ȸ�� ����");
            uiText.DOFade(0, 2);
            GameObject.Find("XR Rig").GetComponent<PlayerInput>().isLeft = false;
        }
        if(GameObject.Find("XR Rig").GetComponent<PlayerInput>().isRight)
        {
            uiText.DOFade(100, 0.1f);
            uiText.text = string.Format("������ ȸ�� ����");
            uiText.DOFade(0, 2f);
            GameObject.Find("XR Rig").GetComponent<PlayerInput>().isRight = false;
        }
        if(GameObject.Find("XR Rig").GetComponent<PlayerInput>().isNormal)
        {
            uiText.DOFade(100, 0.1f);
            uiText.text = string.Format("��ȸ��");
            uiText.DOFade(0, 2f);
            GameObject.Find("XR Rig").GetComponent<PlayerInput>().isNormal = false;
        }
    }
}
