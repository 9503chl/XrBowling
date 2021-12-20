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
    private GameObject _camera;

    private void Awake()
    {
        _camera = GetComponent<XRRig>().cameraGameObject;
    }
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
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!isMove)
            {
                isRight = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (!isMove)
            {
                isRight = false;
                isLeft = false;
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
                    position.x = 0;
                }
                else if (position.x > 0) { 
                    isRight = true;
                    isLeft = false;
                    position.x = 0;
                }
            }
        }
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool press)) //B
        {
            if (press)
            {
                position.x = 0;
                isRight = false;
                isLeft = false;
                press = false;
            }
        }
    }
}