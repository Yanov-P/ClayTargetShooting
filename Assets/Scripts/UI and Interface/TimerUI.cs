using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    [SerializeField]
    private Text number1;
    [SerializeField]
    private Text number2;

    public void DisplayTime(int time)
    {
        number1.text = (time / 10).ToString();
        number2.text = (time % 10).ToString();
    }
}
