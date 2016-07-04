using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConfigScript : MonoBehaviour {

    public Slider bgmSlider;
    public Slider sfxSlider;
    public Toggle soundOnOff;

    private Camera camera;

	// Use this for initialization
	void Start () {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        bgmSlider.value = PlayerPrefs.GetFloat("musicVol");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVol");
        soundOnOff.isOn = PlayerPrefs.GetInt("soundOnOff") == 1 ? true : false;

        if (PlayerPrefs.GetInt("soundOnOff") == 1)
        {
            camera.GetComponent<AudioListener>().enabled = true;
        }
        else
        {
            camera.GetComponent<AudioListener>().enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetSound()
    {
        if (soundOnOff.isOn)
        {
            //Debug.Log("Ligado");
            PlayerPrefs.SetInt("soundOnOff", 1);
            camera.GetComponent<AudioListener>().enabled = true;
        }
        else 
        {
            //Debug.Log("Desligado");
            PlayerPrefs.SetInt("soundOnOff", 0);
            camera.GetComponent<AudioListener>().enabled = false;
        }
    }
}
