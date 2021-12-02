using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dump : MonoBehaviour
{
    public bool isDumped = false;
    private void OnTriggerEnter(Collider other)
    {
        isDumped = true;
    }
}
