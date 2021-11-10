using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Pin;
    void Update()
    {
        if(GameObject.Find("Magnet").GetComponent<MagnetMove>().count == 3)
        {
            Invoke("SpawnPin", 0.7f);
        }
    }
    void SpawnPin()
    {
        Instantiate(Pin, gameObject.transform.position, gameObject.transform.rotation);
    }
}
