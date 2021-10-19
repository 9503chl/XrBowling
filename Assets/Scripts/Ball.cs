using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float spawnTime = 5.0f;
    [SerializeField] GameObject sBall;
    public int count = 0;
    
    void Update()
    {
        if (spawnTime <= 0.0f && count < 3)
        {
            Instantiate(sBall,transform.position ,transform.rotation);
            spawnTime = 5.0f;
            count++;
        }
        spawnTime -= Time.deltaTime;
    }
}
