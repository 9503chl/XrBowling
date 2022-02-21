using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


[RequireComponent(typeof(Text))]

public class ScoreText : MonoBehaviour
{
    [SerializeField] AudioSource textSound;
    Text uiText;
    public int count = 0;
    void Start()
    {
        uiText = GetComponent<Text>();
    }
    void FixedUpdate()
    {
        if(count == 4)
        {
            GameObject.Find("Score").GetComponent<Score>().turnEnd = false;
            count = 0;
        }
        if (GameObject.Find("Score").GetComponent<Score>().turnEnd) 
        {
            textSound.Play();
            if (gameObject.name == "ScoreBoard1")
            {
                string str = "";
                for(int i =0; i<10; i++)
                {
                    str += GameObject.Find("Score").GetComponent<Score>().PointNow[i,0];
                    //str += " ";
                }
                uiText.DOText(str, 1.5f);
                count++;
            }
            else if (gameObject.name == "ScoreBoard2")
            {
                string str = "";
                for (int i = 0; i < 10; i++)
                {
                    str += GameObject.Find("Score").GetComponent<Score>().PointNow[i, 1];
                    //str += "";
                }
                uiText.DOText(str, 1.5f);
                count++;
            }
            else if (gameObject.name == "ScoreBoard3") 
            {
                string str = "";
                for (int i = 0; i < 10; i++)
                {
                    str += GameObject.Find("Score").GetComponent<Score>().PointNow[i, 2];
                    //str += "";
                }
                uiText.DOText(str, 1.5f);
                count++;
            }
            else if (gameObject.name == "ScoreBoard4")
            {
                string str = "";
                str += GameObject.Find("Score").GetComponent<Score>().totalScore;
                uiText.DOText(str, 1.5f);
                count++;
            }
        }
    }
}