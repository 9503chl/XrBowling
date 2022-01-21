using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] GameObject sBall;
    [SerializeField] AudioSource ballSound;
    public bool isGone = false;
    public bool isRoll = false;
    private void Update()
    {
        if (isGone) //공이랑 breakwall이 충돌시
        {
            ballSound.Stop();
            Spawner1();
            isGone = false; isRoll = false;
        }
        if (isRoll) Invoke("SoundPlay", 0.05f);
    }
    void SoundPlay()
    {
        ballSound.Play();
    }
    void Spawner1()
    {
        Instantiate(sBall, gameObject.transform.position, gameObject.transform.rotation);
    }
}
