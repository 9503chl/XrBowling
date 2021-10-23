using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesPin : MonoBehaviour
{
    public bool isFirst = false;
    void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        isFirst = true;
    }
}
