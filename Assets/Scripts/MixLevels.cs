using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MixLevels : MonoBehaviour
{
    public AudioMixer masterMixer;

    public void SetSfxLvl(float sfxLvl)
    {
        Debug.Log(sfxLvl);
        masterMixer.SetFloat("sfxVol", sfxLvl);
    }

    public void SetMusicLvl(float musicLvl)
    {
        Debug.Log(musicLvl);
        masterMixer.SetFloat("musicVol", musicLvl);
    }
}
