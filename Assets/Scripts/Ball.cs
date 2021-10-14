using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    void Start()
    {
        var velo = speed * transform.forward;
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(speed * transform.forward, ForceMode.VelocityChange);
    }
}
