using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource SoundAudioSource;

    public void PlaySound(string soundName)
    {
        SoundAudioSource.PlayOneShot(GameManager.Instance.Cache.GetSound(soundName));
    }
}