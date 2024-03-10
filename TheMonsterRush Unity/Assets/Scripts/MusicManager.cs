using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public enum SoundFXCat { MenuMusic, GameMusic }
    public GameObject musicObject;
    public AudioClip[] menuMusic;
    public AudioClip[] gameMusic;


    public void AudioTrigger(SoundFXCat AudioType, Vector3 audioPosition, float volume)
    {
        GameObject newAudio = GameObject.Instantiate(musicObject, audioPosition, Quaternion.identity);
        ControlAudio ca = newAudio.GetComponent<ControlAudio>();
        switch (AudioType)
        {
            case (SoundFXCat.GameMusic):
                ca.myClip = gameMusic[Random.Range(0, gameMusic.Length)];
                break;
            case (SoundFXCat.MenuMusic):
                ca.myClip = menuMusic[Random.Range(0, menuMusic.Length)];
                break;
        }

        ca.volume = volume;
        ca.StartAudio();
    }

}

