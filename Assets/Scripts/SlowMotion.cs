using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    [SerializeField]
    private float _slowMotionValue = 0.5f;
    public bool _activated = false;
    public void SlowMotionStart()
    {
        _activated = true;
        Time.timeScale = _slowMotionValue;
        GetComponent<GameManager>().ResetCombo();
        Invoke("SlowMotionEnd", 3);
    }

    private void SlowMotionEnd() {
        _activated = false;
        Time.timeScale = 1;
        GetComponent<GameManager>().ResetCombo();
    }

    public void ForceSlowMotionEnd()
    {
        _activated = false;
        Time.timeScale = 1;
        GetComponent<GameManager>().ResetCombo();
    }

}
