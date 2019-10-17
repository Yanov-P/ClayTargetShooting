using ClayTargetShooting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameType _gameType;
    private int _brokenTargetsCount = 0;
    private int _brokenTargetsByPlayerCount = 0;
    public void TargetBrokenHandler(bool byPlayer) {
        _brokenTargetsCount++;
        if (byPlayer) _brokenTargetsByPlayerCount++;
    }
}
