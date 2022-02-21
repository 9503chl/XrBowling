using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class DoFade1 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Score").GetComponent<ScoreText>().count == 4)
        {
            if(gameObject.tag == "Score")
            {
                gameObject.GetComponent<Text>().DOFade(0, 7.5f);
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().DOFade(0, 7.5f);
            }
        }
    }
}
