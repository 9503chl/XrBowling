using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreText : MonoBehaviour
{
    Text uiText;
   
    void Start()
    {
        uiText = GetComponent<Text>();
    }
    void Update()
    {
        if (GameObject.Find("Score").GetComponent<Score>().turnEnd) //턴종료후 실행이 안된다.
        {
            if (gameObject.name == "ScoreBoard")
            {
                string str = null;
                for(int i =0; i<10; i++)
                {
                    str.Insert(i, GameObject.Find("Score").GetComponent<Score>().PointNow[i,0].ToString());
                }
                uiText.text = string.Format(str);
                GameObject.Find("Score").GetComponent<Score>().turnEnd = false;
            }
            else if (gameObject.name == "ScoreBoard1")
            {
                string str = null;
                for (int i = 0; i < 10; i++)
                {
                    str.Insert(i, GameObject.Find("Score").GetComponent<Score>().PointNow[i, 1].ToString());
                }
                uiText.text = string.Format(str);
                GameObject.Find("Score").GetComponent<Score>().turnEnd = false;
            }
            else if (gameObject.name == "ScoreBoard2")
            {
                string str = null;
                for (int i = 0; i < 10; i++)
                {
                    str.Insert(i, GameObject.Find("Score").GetComponent<Score>().PointNow[i, 2].ToString());
                }
                uiText.text = string.Format(str);
                GameObject.Find("Score").GetComponent<Score>().turnEnd = false;
            }
        }
    }
}
