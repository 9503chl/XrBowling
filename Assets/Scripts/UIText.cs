using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UIText : MonoBehaviour
{
    Text uiText;
    void Start()
    {
        uiText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("XR Rig").GetComponent<PlayerInput>().isLeft){
            uiText.text = string.Format("���� ȸ�� ����");
        }
        else if(GameObject.Find("XR Rig").GetComponent<PlayerInput>().isRight)
        {
            uiText.text = string.Format("������ ȸ�� ����");
        }
        else
        {
            uiText.text = string.Format("��ȸ��");
        }
    }
}
