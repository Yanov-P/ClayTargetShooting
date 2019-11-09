using ClayTargetShooting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameType _gameType;
    [SerializeField]
    private Machine _machine;
    private int _brokenTargetsCount = 0;
    private int _brokenTargetsByPlayerCount = 0;
    private int _currentAmmoShot;
    private int _passedSeconds = 0;
    public bool _isPlaying = false;
    private int _combo = 0;
    [SerializeField]
    private int _comboToSlowMo;

    public void TargetBrokenHandler() {
        GetComponent<AudioSource>().Play();
        //Debug.Log("TargetBrokenHandler");
        _combo = 0;
        GetComponent<UIController>().EnableSlowMoButton(false);
        GetComponent<UIController>().UpdateCombo(_combo);
        _brokenTargetsCount++;
        GetComponent<UIController>().UpdateScore(_brokenTargetsCount, _brokenTargetsByPlayerCount);
    }

    public void TargetBrokenByPlayer()
    {
        GetComponent<AudioSource>().Play();
        //Debug.Log("TargetBrokenByPlayer");
        _brokenTargetsByPlayerCount++;
        if (!GetComponent<SlowMotion>()._activated)
        {
            _combo++;
            if (_combo >= _comboToSlowMo)
            {
                GetComponent<UIController>().EnableSlowMoButton(true);
            }
            GetComponent<UIController>().UpdateCombo(_combo);
            _brokenTargetsByPlayerCount += _combo;
        }
        
        GetComponent<UIController>().UpdateScore(_brokenTargetsCount, _brokenTargetsByPlayerCount);
    }

    public void ResetCombo() {
        _combo = -1;
        GetComponent<UIController>().EnableSlowMoButton(false);
    }

    public void PlayerAmmoHandler(int ammo, int maxAmmoInMagazine)
    {
        _currentAmmoShot++;
        if (_gameType._maxAmmo != -1 && _currentAmmoShot >= _gameType._maxAmmo) {
            if (_brokenTargetsByPlayerCount > _gameType._record) {
                _gameType._record = _brokenTargetsByPlayerCount;
            }
            FinishGame(_brokenTargetsByPlayerCount, _gameType._record);
        }
        
        GetComponent<UIController>().HandlePlayerAmmo(ammo, maxAmmoInMagazine, _gameType._maxAmmo - _currentAmmoShot);
    }

    public void PlayerReloadHandler(int ammo, int maxAmmoInMagazine)
    {
        
        GetComponent<UIController>().HandlePlayerAmmo(ammo, maxAmmoInMagazine, _gameType._maxAmmo - _currentAmmoShot);
    }

    public void SetGameType(GameType gt) {
        
        _gameType = gt;
        Debug.Log("gamemode set to " + gt.name);
    }

    public void StartGame() {
        _brokenTargetsByPlayerCount = 0;
        _brokenTargetsCount = 0;
        _currentAmmoShot = 0;
        if (_gameType._maxTime != -1) {
            _passedSeconds = 0;
            InvokeRepeating("Timer", 1, 1);
        }
        _machine.StartLaunch(1.5f);
        _isPlaying = true;
    }

    private void Timer() {
        _passedSeconds++;
        GetComponent<UIController>().ShowTimer(_gameType._maxTime - _passedSeconds);
        Debug.Log("broken targets " + _brokenTargetsByPlayerCount + " _gameType._record " + _gameType._record);
        if (_passedSeconds >= _gameType._maxTime) {
            if (_brokenTargetsByPlayerCount > _gameType._record) _gameType._record = _brokenTargetsByPlayerCount;
            FinishGame(_brokenTargetsByPlayerCount, _gameType._record);
        }
    }

    private void FinishGame(int count,int record) {
        GetComponent<SlowMotion>().ForceSlowMotionEnd();
        ResetCombo();
        _gameType._lastTry = count;
        CancelInvoke();
        _machine.StopLaunch();
        GetComponent<UIController>().FinishGame(count, record);
        _isPlaying = false;
    }

    public void FinishGame()
    {
        GetComponent<SlowMotion>().ForceSlowMotionEnd();
        ResetCombo();
        CancelInvoke();
        _machine.StopLaunch();
        _isPlaying = false;
    }
}
