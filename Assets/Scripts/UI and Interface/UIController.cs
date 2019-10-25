using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainPanel;
    [SerializeField]
    private GameObject _planeSearchPanel;
    [SerializeField]
    private GameObject _testPanel;
    [SerializeField]
    private Text _brokenText;
    [SerializeField]
    private Text _byPlayerText;
    [SerializeField]
    private Text _currentAmmo;
    [SerializeField]
    private Text _maxAmmo;
    [SerializeField]
    private Text _maxAmmoForGame;
    [SerializeField]
    private Text _finishScore;
    [SerializeField]
    private Text _timer;
    [SerializeField]
    private GamemodeSwitcher _gamemodeSwitcher;
    [SerializeField]
    private Text[] _recordsText;
    [SerializeField]
    private Text _comboText;
    [SerializeField]
    private GameObject _slowmoButton;

    void Start()
    {
        _mainPanel.SetActive(false);
        _planeSearchPanel.SetActive(true);
        if (Application.platform == RuntimePlatform.WindowsEditor) _testPanel.SetActive(true);
        else _testPanel.SetActive(false);
        UpdateRecords();
    }

    public void PlaneFound() {
        _mainPanel.SetActive(true);
        _planeSearchPanel.SetActive(false);
    }

    public void UpdateScore(int broken, int byPlayer) {
        _brokenText.text = broken.ToString();
        _byPlayerText.text = byPlayer.ToString();
    }

    internal void FinishGame(int currentScore, int bestScore) {
        _finishScore.text = "Current score: " + currentScore.ToString() + "\nBestScore: " + bestScore.ToString();
        UpdateRecords();
    }

    internal void HandlePlayerAmmo(int ammo, int maxAmmoInMagazine, int maxAmmo)
    {
        _currentAmmo.text = ammo.ToString();
        _maxAmmo.text = maxAmmoInMagazine.ToString();
        _maxAmmoForGame.text = maxAmmo.ToString();
    }

    public void ShowTimer(int time) {
        _timer.text = time.ToString();
    }

    public void UpdateRecords() {
        foreach(var t in _recordsText)
        t.text = _gamemodeSwitcher.GetRecords();
    }

    public void UpdateCombo(int combo)
    {
        _comboText.text = combo.ToString();
    }

    public void EnableSlowMoButton(bool enabled)
    {
        _slowmoButton.SetActive(enabled);
    }

}
