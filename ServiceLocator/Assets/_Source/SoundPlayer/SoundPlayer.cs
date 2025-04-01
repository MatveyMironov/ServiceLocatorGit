using System;
using UnityEngine;

public class SoundPlayer : ISoundPlayer
{
    private readonly AudioSource _audioSource;

    public SoundPlayer(AudioSource audioSource)
    {
        _audioSource = audioSource != null ? audioSource : throw new ArgumentNullException(nameof(audioSource));
    }

    public void PlayCloseSound(AudioClip closeSound)
    {
        
    }

    public void PlayOpenSound(AudioClip openSound)
    {
        
    }
}
