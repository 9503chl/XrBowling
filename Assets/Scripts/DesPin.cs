using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesPin : MonoBehaviour
{
    public bool isFirst = false;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            isFirst = true;
            Destroy(other.gameObject,0.5f);
        }
        else Destroy(other.gameObject);
    }
}
