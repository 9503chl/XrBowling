using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float spawnTime = 5.0f;
    [SerializeField] GameObject sBall;
    
    void Update()
    {
        if (spawnTime <= 0.0f)
        {
            Instantiate(sBall,transform.position ,transform.rotation);
            spawnTime = 5.0f;
        }
        spawnTime -= Time.deltaTime;
    }
}
