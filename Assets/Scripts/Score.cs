using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int [,] PointNow = new int[10,2];
    float TotalPoint = 0f;
    public int round = 0; //10����
    public int tCount = 0; //1,2��
    void Update()
    {
        if (tCount == 2) tCount = 0;
    }
}
