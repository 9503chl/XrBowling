using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float ShakeAmount = 3f;
    float ShakeTime = 1f;
    Vector3 Position1;
    public Canvas canvas;

    private void Start()
    {
        Position1 = new Vector3(0, 0, -5);
    }
    private void Update()
    {
        if (ShakeTime > 0)
        {
            transform.position = Random.insideUnitSphere * ShakeAmount + Position1;
            ShakeTime -= Time.deltaTime;
        }
        else
        {
            ShakeTime = 0.0f;
            transform.position = Position1;
        }

    }
    public void VibrateForTime(float time)
    {
        ShakeTime = time;
        canvas.renderMode = RenderMode.WorldSpace;
    }
}
