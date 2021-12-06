using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerInput : MonoBehaviour
{
    public XRController controller = null;
    public bool isLeft = false;
    public bool isRight = false;
    public bool isMove = false;
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (!isMove)
            {
                isLeft = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!isMove)
            {
                isRight = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            if (!isMove)
            {
                isRight = false;
                isLeft = false;
            }
        }
#endif
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondry))//B
        {
            if (!isMove)
            {
                isLeft = true;
            }
        }
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary)) //A
        {
            if (!isMove)
                {
                isRight = true;
            }
        }
        if(controller.inputDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool grip))
        {
            if (!isMove)
            {
                isLeft = false;
                isRight = false;
            }
        }
    }
}