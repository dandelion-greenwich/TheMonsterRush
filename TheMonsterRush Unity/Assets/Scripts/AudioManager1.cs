using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager1 : MonoBehaviour
{
    public enum SoundFXCat { FootStep, Drinking, Dispenser, EndingNoMonster, AngryAh }
    public GameObject audioObject;
    public AudioClip[] footSteps;
    public AudioClip[] drinking;
    public AudioClip[] dispenser;
    public AudioClip[] endingNoMonster;
    public AudioClip[] angryAh;


    public void AudioTrigger(SoundFXCat AudioType, Vector3 audioPosition, float volume)
    {
        GameObject newAudio = GameObject.Instantiate(audioObject, audioPosition, Quaternion.identity);
        ControlAudio ca = newAudio.GetComponent<ControlAudio>();
        switch (AudioType)
        {
            case (SoundFXCat.FootStep):
                ca.myClip = footSteps[Random.Range(0, footSteps.Length)];
                break;
            case (SoundFXCat.Drinking):
                ca.myClip = drinking[Random.Range(0, drinking.Length)];
                break;
            case (SoundFXCat.Dispenser):
                ca.myClip = dispenser[Random.Range(0, dispenser.Length)];
                break;
            case (SoundFXCat.EndingNoMonster):
                ca.myClip = endingNoMonster[Random.Range(0, endingNoMonster.Length)];
                break;
            case (SoundFXCat.AngryAh):
                ca.myClip = angryAh[Random.Range(0, angryAh.Length)];
                break;
        }

        ca.volume = volume;
        ca.StartAudio();
    }

}
