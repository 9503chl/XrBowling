using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DesPin : MonoBehaviour
{
    public bool isFirst = false;
    public bool isCollide = false;
    public bool isStart = false;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            isFirst = true;
            Invoke("isCollideM", 1.2f);
            Invoke("tCountUp", 2.0f); //세는 시간을 주자
            Invoke("isMoveOff", 1.5f);
            GameObject.Find("Magnet").GetComponent<MagnetMove>().count++;
            Destroy(other.gameObject, 0.2f);
            GameObject.Find("hall").GetComponent<Dump>().dumpCount = 0;
            GameObject.Find("hall2").GetComponent<Dump>().dumpCount = 0;
            GameObject.Find("View Camera").SetActive(false);
            GameObject.Find("ScoreTotal").GetComponent<SpriteRenderer>().DOColor(Color.white, 0.5f);
        }
        else Destroy(other.gameObject);
    }
    void tCountUp()
    {
        isStart = true;
        GameObject.Find("Score").GetComponent<Score>().tCount++;
    }
    void isCollideM()
    {
        isCollide = true;
    }
    void isMoveOff()
    {
        GameObject.Find("RightHand Controller").GetComponent<PlayerInput>().isMove = false;
    }
}
