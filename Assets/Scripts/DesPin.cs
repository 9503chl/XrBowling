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
            isFirst = true; isCollide = true; isStart = true;
            GameObject.Find("Magnet").GetComponent<MagnetMove>().count++;
            Destroy(other.gameObject, 0.5f);
            GameObject.Find("Score").GetComponent<Score>().tCount++;
        }
        else Destroy(other.gameObject);
    }
}
