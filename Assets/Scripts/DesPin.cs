using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesPin : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag != "Floor") Destroy(gameObject, 2.0f);        
    }
}
