using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] audioList;
    [SerializeField]
    private AudioSource SFXSource;
    [SerializeField]
    private AudioClip[] audioARList;
    [SerializeField]
    private AudioSource SFXARSource;
    [SerializeField]
    public static AudioManager Instance;

    public void Awake()
    {
        Instance = this;
    }

    public static void PlaySound(int sound)
    {
        Instance.SFXSource.PlayOneShot(Instance.audioList[sound]);
    }
    public static void PlayARSound(int sound)
    {
        Instance.SFXARSource.PlayOneShot(Instance.audioARList[sound]);
    }
}
