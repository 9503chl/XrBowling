using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Text))]
public class UIText : MonoBehaviour
{
    Text uiText1;
    Text uiText2;
    Text uiText3;
    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("XR Rig").GetComponent<PlayerInput>().isLeft){
            uiText1.GetComponent<Text>();
            uiText1.text = string.Format("왼쪽 회전 적용");
            uiText1.DOFade(0, 2);
            uiText2.DOFade(1, 0.1f);
            uiText3.DOFade(1, 0.1f);
        }
        else if(GameObject.Find("XR Rig").GetComponent<PlayerInput>().isRight)
        {
            uiText2.GetComponent<Text>();
            uiText2.text = string.Format("오른쪽 회전 적용");
            uiText1.DOFade(1, 0.1f);
            uiText2.DOFade(0, 2);
            uiText3.DOFade(1, 0.1f);
        }
        else
        {
            uiText3.GetComponent<Text>();
            uiText3.text = string.Format("무회전");
            uiText1.DOFade(1, 0.1f);
            uiText2.DOFade(1, 0.1f);
            uiText3.DOFade(0, 2);
        }
    }
}
