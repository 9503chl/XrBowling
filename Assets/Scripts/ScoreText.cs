using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScoreText : MonoBehaviour
{
    int count = 0;
    void FixedUpdate()
    {
        if(count == 3)
        {
            GameObject.Find("Score").GetComponent<Score>().turnEnd = false;
            count = 0;
        }
        if (GameObject.Find("Score").GetComponent<Score>().turnEnd) 
        {
            if (gameObject.name == "ScoreBoard")
            {
                string str = "|";
                for(int i =0; i<10; i++)
                {
                    str += GameObject.Find("Score").GetComponent<Score>().PointNow[i,0];
                    str += "|";
                }
                gameObject.GetComponent<TextMesh>().text = str;
                count++;
            }
            else if (gameObject.name == "ScoreBoard1")
            {
                string str = "|";
                for (int i = 0; i < 10; i++)
                {
                    str += GameObject.Find("Score").GetComponent<Score>().PointNow[i, 1];
                    str += "|";
                }
                gameObject.GetComponent<TextMesh>().text = str;
                count++;
            }
            else if (gameObject.name == "ScoreBoard2") 
            {
                string str = "|";
                for (int i = 0; i < 10; i++)
                {
                    str += GameObject.Find("Score").GetComponent<Score>().PointNow[i, 2];
                    str += "|";
                }
                gameObject.GetComponent<TextMesh>().text = str;
                count++;
            }
        }
    }
}