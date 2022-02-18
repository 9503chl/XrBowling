using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            GameObject.Find("Spawner").GetComponent<Ball>().viewCamera.SetActive(false);
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
