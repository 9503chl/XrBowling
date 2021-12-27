using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TitleDoTween : MonoBehaviour
{
    [SerializeField]AudioSource shotGunSound;
    void Start()
    {
        if (gameObject.name == "X")
        {
            Invoke("doTween", 0.5f);
        }
        if (gameObject.name == "R")
        {
            Invoke("doTween", 1.0f);
        }
        if (gameObject.name == "B")
        {
            Invoke("doTween", 1.1f);
        }
        if (gameObject.name == "O") 
        {
            Invoke("doTween", 1.2f);
        }
        if (gameObject.name == "W")
        {
            Invoke("doTween", 1.3f);
        }
        if (gameObject.name == "L")
        {
            Invoke("doTween", 1.6f);
        }
        if (gameObject.name == "I")
        {
            Invoke("doTween", 1.65f);
        }
        if (gameObject.name == "N")
        {
            Invoke("doTween", 1.7f);
        }
        if (gameObject.name == "G")
        {
            Invoke("doTween", 1.75f);
        }
    }
    void doTween()
    {
        transform.DOMoveZ(200f, 0.2f);
        shotGunSound.Play();
    }
}
