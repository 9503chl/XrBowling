using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
 
    void FixedUpdate()
    {
        if (GameObject.Find("Score").GetComponent<Score>().turnEnd) //1,2���� �ֵ��� ������ �ȵȴ�.
        {
            if (gameObject.name == "ScoreBoard")
            {
                string str = "";
                for(int i =0; i<10; i++)
                {
                    str += GameObject.Find("Score").GetComponent<Score>().PointNow[i,0].ToString();
                }
                gameObject.GetComponent<TextMesh>().text = str;
                GameObject.Find("Score").GetComponent<Score>().turnEnd = false;
            }
            else if (gameObject.name == "ScoreBoard1")
            {
                string str = "";
                for (int i = 0; i < 10; i++)
                {
                    str += GameObject.Find("Score").GetComponent<Score>().PointNow[i, 1].ToString();
                }
                gameObject.GetComponent<TextMesh>().text = str;
                GameObject.Find("Score").GetComponent<Score>().turnEnd = false;
            }
            else if (gameObject.name == "ScoreBoard2") //�길��
            {
                string str = "";
                for (int i = 0; i < 10; i++)
                {
                    str += GameObject.Find("Score").GetComponent<Score>().PointNow[i, 2].ToString();
                }
                gameObject.GetComponent<TextMesh>().text = str;
                GameObject.Find("Score").GetComponent<Score>().turnEnd = false;
            }
        }
    }
}
