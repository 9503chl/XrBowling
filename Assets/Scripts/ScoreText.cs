using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Text))]
public class ScoreText : MonoBehaviour
{
    Text uiText;
    int count = 0;
    void Start()
    {
        uiText = GetComponent<Text>();
    }
    void FixedUpdate()
    {
        if(count == 3)
        {
            GameObject.Find("Score").GetComponent<Score>().turnEnd = false;
            count = 0;
        }
        if (GameObject.Find("Score").GetComponent<Score>().turnEnd) 
        {
            if (gameObject.name == "ScoreBoard1")
            {
                string str = "|";
                for(int i =0; i<10; i++)
                {
                    str += GameObject.Find("Score").GetComponent<Score>().PointNow[i,0];
                    str += "|";
                }
                uiText.DOText(str, 1.5f);
                count++;
            }
            else if (gameObject.name == "ScoreBoard2")
            {
                string str = "|";
                for (int i = 0; i < 10; i++)
                {
                    str += GameObject.Find("Score").GetComponent<Score>().PointNow[i, 1];
                    str += "|";
                }
                uiText.DOText(str, 1.5f);
                count++;
            }
            else if (gameObject.name == "ScoreBoard3") 
            {
                string str = "|";
                for (int i = 0; i < 10; i++)
                {
                    str += GameObject.Find("Score").GetComponent<Score>().PointNow[i, 2];
                    str += "|";
                }
                uiText.DOText(str, 1.5f);
                count++;
            }
        }
    }
}