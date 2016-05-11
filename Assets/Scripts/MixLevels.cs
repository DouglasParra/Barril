using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MixLevels : MonoBehaviour
{
    public AudioMixer masterMixer;

    public void SetSfxLvl(float sfxLvl)
    {
        masterMixer.SetFloat("sfxVol", sfxLvl);
        PlayerPrefs.SetFloat("sfxVol", sfxLvl);
    }

    public void SetMusicLvl(float musicLvl)
    {
        masterMixer.SetFloat("musicVol", musicLvl);
        PlayerPrefs.SetFloat("musicVol", musicLvl);
    }
}
