using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int [,] PointNow = new int[10,3];
    float TotalPoint = 0f;
    public int round = 0; //10라운드
    public int tCount = 0; //1,2턴
    public int sCount = 0; //핀점수
    int beforeScore = 0;
    void Update()
    {
        if (tCount == 2) //2턴 다씀
        {
            round++; tCount = 0;
        }
        if (sCount == 10) // 스트라이크
        {
            round++; tCount = 0;
        }
        else if(beforeScore + sCount == 10) // 스페어
        {

        }
    }
}
