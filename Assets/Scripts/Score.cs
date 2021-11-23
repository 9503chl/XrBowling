using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Score : MonoBehaviour
{
    Text uiText;
    public int [,] PointNow = new int[10,3];
    int TotalPoint = 0;// 최종점수
    public int round = 0; //10라운드
    public int tCount = 0; //1,2턴
    public int sCount = 0; //핀점수
    int beforeScore = 0;
    bool isSpare = false;
    public bool turnEnd = false;
    void Start()
    {
        uiText = GetComponent<Text>();
    }
    void Update()
    {
        if (tCount == 2) //2턴 다씀
        {
            PointNow[round, 1] = sCount;
            if (round == 0) PointNow[round, 2] += beforeScore + sCount;
            else PointNow[round, 2] += PointNow[round, 2] + beforeScore + sCount;
            round++; tCount = 0; turnEnd = true;
            beforeScore = 0;
        }
        else if (tCount == 1 && sCount == 10) // 스트라이크
        {
            if (isSpare)
            {
                PointNow[round - 1, 2] += 10;
                isSpare = false;
            }
            PointNow[round, 0] = 'X';
            if (round == 0) PointNow[round, 2] += 30;
            else PointNow[round, 2] += PointNow[round, 2] + 30;
            round++; tCount = 0; turnEnd = true;
        }
        else if (beforeScore + sCount == 10) // 스페어
        {
            PointNow[round, 1] = '/';
            PointNow[round, 2] += 10;
            isSpare = true;
            round++; tCount = 0; turnEnd = true;
        }
        else if (GameObject.Find("BreakWall").GetComponent<DesPin>().isFirst && sCount == 0) //0개 맞춤
        {
            PointNow[round, 0] = '-';
        }
        else if (tCount == 2 && GameObject.Find("BreakWall").GetComponent<DesPin>().isFirst && sCount == 0) //2턴 다쓰고 0개맞춤
        {
            PointNow[round, 1] = '-';
            if (PointNow[round, 0] == '-') PointNow[round, 2] = 0;
            else PointNow[round, 2] += PointNow[round, 0];
            round++; tCount = 0;
            beforeScore = 0; turnEnd = true;
        }
        else //1턴만씀
        {
            if (isSpare)
            {
                PointNow[round - 1, 2] += sCount;
                isSpare = false;
            }
            PointNow[round, 0] = sCount;
            beforeScore = sCount;
        }
    }
}
