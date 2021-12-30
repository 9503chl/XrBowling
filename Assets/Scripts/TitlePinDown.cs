using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePinDown : MonoBehaviour
{
    Vector3 pos1;
    bool isdone = false;
#if UNITY_EDITOR
    int speed = 60;
#else 
    int speed = 6;
#endif
    void Start()
    {
        pos1 = transform.position - new Vector3(0, 3.25f, 0);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameObject.Find("Magnet").GetComponent<MagnetMove>().count == 4)
        {
            Invoke("SecondM", 0.5f);
        }
    }
    void SecondM()
    {
        transform.position = Vector3.Lerp(transform.position, pos1, speed * Time.deltaTime);
    }
}
