using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ConfigScript : MonoBehaviour {

    public Slider bgmSlider;
    public Slider sfxSlider;
    public Toggle soundOnOff;

    private Camera camera;
    private Camera miniMapCamera;

	// Use this for initialization
	void Start () {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        bgmSlider.value = PlayerPrefs.GetFloat("musicVol");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVol");
        soundOnOff.isOn = PlayerPrefs.GetInt("soundOnOff") == 1 ? true : false;

        if (PlayerPrefs.GetInt("soundOnOff") == 1)
        {
            camera.GetComponent<AudioListener>().enabled = true;
            AudioListener.volume = 1;
        }
        else
        {
            camera.GetComponent<AudioListener>().enabled = false;
            AudioListener.volume = 0;
        }

        if (SceneManager.GetActiveScene().name.Contains("-"))
        {
            miniMapCamera = GameObject.Find("MiniMapCamera").GetComponent<Camera>();
            if (PlayerPrefs.GetInt("soundOnOff") == 0)
            {
                miniMapCamera.GetComponent<AudioListener>().enabled = false;
                AudioListener.volume = 0;
            }
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
            AudioListener.volume = 1;
        }
        else 
        {
            //Debug.Log("Desligado");
            PlayerPrefs.SetInt("soundOnOff", 0);
            camera.GetComponent<AudioListener>().enabled = false;
            AudioListener.volume = 0;
        }

        if (SceneManager.GetActiveScene().name.Contains("-"))
        {
            if (PlayerPrefs.GetInt("soundOnOff") == 0)
            {
                miniMapCamera.GetComponent<AudioListener>().enabled = false;
                AudioListener.volume = 0;
            }
        }
    }
}
