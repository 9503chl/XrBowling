using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class DoFade1 : MonoBehaviour
{
    // Update is called once per frame
    Color color1 = new Color(0,0,0,0); //∞À¡§
    bool isOn = false;
    float a = 0;
    void Update()
    {
        Debug.Log(a);
        a = Mathf.Clamp(a,0,1);
        if (gameObject.tag == "Score")
        {
            gameObject.GetComponent<TextMesh>().color = color1;
            color1 = new Color(0, 0, 0, a);
        }
        if (isOn)
        {
            if (a >= 1) isOn = false;
            a += Time.deltaTime;
        }
        else a -= Time.deltaTime * 0.6f;
        if (GameObject.FindWithTag("Score").GetComponent<ScoreText>().count == 4)
        {
            if(gameObject.tag == "Score") isOn = true;
            else gameObject.GetComponent<SpriteRenderer>().DOFade(0, 4.5f);
        }
    }
}
