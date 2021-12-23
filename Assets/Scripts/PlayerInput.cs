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
    public bool isNormal = false;
    public bool isMove = false;
    private GameObject _camera;

    private void Update()
    {
        CommonInput();
    }
    private void CommonInput()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (!isMove)
            {
                isLeft = true;
                isRight = false;
                isNormal = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!isMove)
            {
                isLeft = false;
                isRight = true;
                isNormal = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (!isMove)
            {
                isLeft = false;
                isRight = false;
                isNormal = true;
            }
        }
#endif
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
        {
            if (!isMove)
            {
                if (position.x < 0)
                {
                    isLeft = true;
                    isRight = false;
                    isNormal = false;
                    position.x = 0;
                }
                else if (position.x > 0)
                {
                    isRight = true;
                    isLeft = false;
                    isNormal = false;
                    position.x = 0;
                }
            }
        }
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool press)) //B
        {
            if (!isMove)
            {
                if (press)
                {
                    position.x = 0;
                    isRight = false;
                    isLeft = false;
                    isNormal = true;
                    press = false;
                }
            }
        }
    }
}