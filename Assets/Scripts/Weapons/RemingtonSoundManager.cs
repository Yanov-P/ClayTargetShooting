using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemingtonSoundManager : MonoBehaviour
{
    
    [SerializeField]
    private AudioSource _pumpBackSource;
    [SerializeField]
    private AudioSource _pumpForwardSource;
    [SerializeField]
    private AudioSource _shellInSource;
    [SerializeField]
    private AudioSource _shootSource;
    
    public void PlayPumpBack()
    {
        _pumpBackSource.Play();
    }

    public void PlayPumpForward()
    {
        _pumpForwardSource.Play();
    }

    public void PlayShoot()
    {
        _shootSource.Play();
    }

    public void PlayShellIn()
    {
        _shellInSource.Play();
    }
}
