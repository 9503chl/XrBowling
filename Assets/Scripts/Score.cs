using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int[,] PointNow = new int[10, 3];
    public int round = 0; //10라운드
    public int tCount = 0; //1,2턴
    public int sCount = 0; //핀점수
    int beforeScore = 0;
    bool isSpare = false;
    public bool turnEnd = false;
    void FixedUpdate()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Debug.Log(i + "항" + j + "항 =" + PointNow[i, j]);
            }
        }
        if(GameObject.Find("BreakWall").GetComponent<DesPin>().isStart) 
        {
            if (tCount == 1 && sCount == 10) // 스트라이크
            {
                if (isSpare)
                {
                    PointNow[round - 1, 2] += 10;
                    isSpare = false;
                }
                PointNow[round, 0] = 'X';
                if (round == 0) PointNow[round, 2] += 30;
                else PointNow[round, 2] += PointNow[round - 1, 2] + 30;
                round++; tCount = 0; turnEnd = true; sCount = 0;
                GameObject.Find("Magnet").GetComponent<MagnetMove>().count = 3; //바로 초기화
                GameObject.Find("BreakWall").GetComponent<DesPin>().isStart = false;
            }

            if (beforeScore + sCount == 10) // 스페어
            {
                if (round == 0) PointNow[round, 2] += beforeScore + sCount;
                else PointNow[round, 2] += PointNow[round - 1, 2] + beforeScore + sCount;
                PointNow[round, 1] = '/';
                isSpare = true;
                round++; tCount = 0; turnEnd = true; sCount = 0;
                GameObject.Find("BreakWall").GetComponent<DesPin>().isStart = false;
            }

            if (GameObject.Find("BreakWall").GetComponent<DesPin>().isFirst && sCount == 0) //0개 맞춤
            {
                PointNow[round, tCount-1] = '-';
                GameObject.Find("BreakWall").GetComponent<DesPin>().isStart = false;
            }
            if (tCount == 2) //2턴 다씀
            {
                if(round == 0) PointNow[round, 2] += beforeScore + sCount;
                else  PointNow[round, 2] += PointNow[round-1, 2] + beforeScore + sCount;
                PointNow[round, 1] = sCount;
                round++; tCount = 0; turnEnd = true;
                beforeScore = 0; sCount = 0;
                GameObject.Find("BreakWall").GetComponent<DesPin>().isStart = false;
            }
            if (tCount == 1)  // 첫번째 계산이 안된다.
            {
                if (isSpare)
                {
                    PointNow[round - 1, 2] += sCount;
                    isSpare = false;
                }
                PointNow[round, 0] = sCount;
                beforeScore = sCount;
                sCount = 0; turnEnd = true;
                GameObject.Find("BreakWall").GetComponent<DesPin>().isStart = false;
            }
        }
    }
}
