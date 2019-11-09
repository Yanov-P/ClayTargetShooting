using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterUI : MonoBehaviour
{
    
    void Start()
    {
        
    }

    public void DisplayScore(int score)
    {
        int temp = score;
        for (int i = 0; i < 4; i++)
        {
            transform.GetChild(i).GetComponent<Text>().text = (temp % 10).ToString();
            temp /= 10;
        }
    }
}
