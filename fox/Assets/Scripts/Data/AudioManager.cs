using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager
{
    private static AudioManager instance =new AudioManager();
    public static AudioManager Instance => instance;
    private AudioData audioData = new AudioData();
    private AudioManager()
    {
    }
    public float GetBgVolume()
    {
        
        return audioData.bg;
    }
    public float SaveBgVolume(float value)
    {
        audioData.bg = value;
        return audioData.bg;
    }
    public float GetBkVolume()
    {
        return audioData.bk;
    }
    public float SaveBkVolume(float value)
    {
        audioData.bk = value;
        return audioData.bk;
    }
}
