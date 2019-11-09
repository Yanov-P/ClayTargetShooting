using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class SoundChangedEvent : UnityEvent<bool> { }
public class SoundManager : MonoBehaviour
{
    private bool _soundEnabled = true;
    public SoundChangedEvent _soundEvent;
    private bool _musicEnabled = true;
    [SerializeField]
    private AudioSource _musicSource;
    void Start()
    {
        
        int sound = PlayerPrefs.GetInt("Sound", 1);
        if (sound == 0)
        {
            _soundEnabled = false;
            _soundEvent.Invoke(_soundEnabled);
        }
        else if (sound == 1)
        {
            _soundEnabled = true;
            _soundEvent.Invoke(_soundEnabled);
        }

        int music = PlayerPrefs.GetInt("Music", 1);
        if (music == 0)
        {
            _musicEnabled = false;
            _musicSource.mute = true;
        }
        else if (music == 1)
        {
            _musicEnabled = true;
            _musicSource.mute = false;
        }
    }

    public void SoundChanged()
    {
        _soundEnabled = !_soundEnabled;
        _soundEvent.Invoke(_soundEnabled);
        if (_soundEnabled)
        {
            PlayerPrefs.SetInt("Sound", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 0);
        }
    }

    public void MusicChanged()
    {
        _musicEnabled = !_musicEnabled;
        _musicSource.mute = !_musicEnabled;
        if (_musicEnabled)
        {
            PlayerPrefs.SetInt("Music", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Music", 0);
        }
    }




}
