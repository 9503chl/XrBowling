using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class PlayerInput : MonoBehaviour
{
    Text uiText;
    public XRController controller = null;
    public bool isLeft = false;
    public bool isRight = false;
    public bool isMove = false;

    private void Start()
    {
        uiText = GetComponent<Text>();
    }
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (!isMove)
            {
                isLeft = true;
                uiText.text = string.Format("���� ȸ�� ����");
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!isMove)
            {
                isRight = true;
                uiText.text = string.Format("������ ȸ�� ����");
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            if (!isMove)
            {
                isRight = false;
                isLeft = false;
                uiText.text = string.Format("��ȸ��");
            }
        }
#endif
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondry))//B
        {
            if (!isMove)
            {
                isLeft = true;
                uiText.text = string.Format("���� ȸ�� ����");
            }
        }
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary)) //A
        {
            if (!isMove)
                {
                isRight = true;
                uiText.text = string.Format("������ ȸ�� ����");
            }
        }
        if(controller.inputDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool grip))
        {
            if (!isMove)
            {
                isLeft = false;
                isRight = false;
                uiText.text = string.Format("��ȸ��");
            }
        }
    }
}