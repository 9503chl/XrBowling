using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class TitleInput : MonoBehaviour
{
    public XRController controller = null;
    [SerializeField] GameObject FireObject;
    [SerializeField] Transform firePos;
    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(FireObject, firePos.position, firePos.rotation);
        }
#endif
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool grip))
        {
            Instantiate(FireObject, firePos.position, firePos.rotation);
            grip = false;
        }

    }
}
