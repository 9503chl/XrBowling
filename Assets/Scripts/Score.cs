using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int [,] PointNow = new int[10,3];
    float TotalPoint = 0f;
    public int round = 0; //10����
    public int tCount = 0; //1,2��
    public int sCount = 0; //������
    int beforeScore = 0;
    void Update()
    {
        if (tCount == 2) //2�� �پ�
        {
            round++; tCount = 0;
        }
        if (sCount == 10) // ��Ʈ����ũ
        {
            round++; tCount = 0;
        }
        else if(beforeScore + sCount == 10) // �����
        {

        }
    }
}
