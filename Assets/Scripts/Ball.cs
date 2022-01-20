using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] GameObject sBall;
    [SerializeField] AudioSource ballSound;
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "BreakWall")
        {
            Destroy(gameObject);
            ballSound.Stop();
            Invoke("Spawner", 3.0f);
        }
        if (other.transform.tag == "Floor") Invoke("SoundPlay", 0.05f);
    }
    private void Update()
    {
        if (GameObject.FindWithTag("Ball").GetComponent<Accel>().isMove)
            GameObject.FindWithTag("Ball").GetComponent<SpinNHover>().isMove = true;
        else GameObject.FindWithTag("Ball").GetComponent<SpinNHover>().isMove = false;
    }
    void SoundPlay()
    {
        ballSound.Play();
    }
    void Spawner()
    {
        Instantiate(sBall, transform.position, transform.rotation);
    }
}
