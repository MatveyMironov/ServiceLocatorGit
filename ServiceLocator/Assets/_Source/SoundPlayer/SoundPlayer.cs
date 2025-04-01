using System;
using UnityEngine;

public class SoundPlayer : ISoundPlayer
{
    private readonly AudioSource _audioSource;

    private readonly AudioClip _openSound;
    private readonly AudioClip _closeSound;

    public SoundPlayer(AudioSource audioSource, AudioClip openSound, AudioClip closeSound)
    {
        _audioSource = audioSource != null ? audioSource : throw new ArgumentNullException(nameof(audioSource));

        _openSound = openSound ?? throw new ArgumentNullException(nameof(openSound));
        _closeSound = closeSound ?? throw new ArgumentNullException(nameof(closeSound));
    }

    public void PlayOpenSound()
    {
        _audioSource.PlayOneShot(_openSound);
    }

    public void PlayCloseSound()
    {
        _audioSource.PlayOneShot(_closeSound);
    }
}
