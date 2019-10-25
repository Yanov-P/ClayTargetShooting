using ClayTargetShooting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamemodeSwitcher : MonoBehaviour
{
    [SerializeField]
    private GameType[] _gameTypes;
    [SerializeField]
    private GameManager _gameManager;
    [SerializeField]
    private GameObject _text;
    private int num = 1;

    void Start() {
        _gameManager.SetGameType(_gameTypes[num]);
        _text.GetComponent<TextMesh>().text = _gameTypes[num].name;
    }
    public void Switch() {
        if (!_gameManager._isPlaying)
        {
            num++;
            if (num == _gameTypes.Length) num = 0;
            _gameManager.SetGameType(_gameTypes[num]);
            _text.GetComponent<TextMesh>().text = _gameTypes[num].name;
        }
    }

    public string GetRecords() {
        string s = "";
        foreach (var gt in _gameTypes) {
            s += "\nGameType:\n" + gt.name;
            s += "\nLastTry: ";
            if (gt._lastTry == -1) {
                s += "No try's";
            }
            else {
                s+= gt._lastTry;
            }
            s += "\nRecord: ";
            if (gt._record == -1)
            {
                s += "No records";
            }
            else
            {
                s += gt._record;
            }
            s += "\n";
        }
        return s;
    }
}
