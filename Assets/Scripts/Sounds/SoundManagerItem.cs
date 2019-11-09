using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerItem : MonoBehaviour
{
    private void Awake()
    {
        SoundManager sm = (SoundManager)FindObjectOfType(typeof(SoundManager));
        sm._soundEvent.AddListener(HandleSoundChange);
    }

    void HandleSoundChange(bool active) {
        var sources = GetComponents<AudioSource>();
        foreach (var s in sources)
        {
            s.mute = !active;
        }
    }
}
