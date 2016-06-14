using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoostsScript : MonoBehaviour {

    public Toggle laser;
    public Toggle minimapa;

	// Use this for initialization
	void Start () {

        Debug.Log("Laser :" + PlayerPrefs.GetInt("Laser"));
        Debug.Log("MiniMapa :" + PlayerPrefs.GetInt("MiniMapa"));

        if (PlayerPrefs.GetInt("Laser") == 0)
        {
            laser.isOn = false;
        }
        else 
        {
            laser.isOn = true;
        }

        if (PlayerPrefs.GetInt("MiniMapa") == 0)
        {
            minimapa.isOn = false;
        }
        else
        {
            minimapa.isOn = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LaserOnOff() {

        Debug.Log("Laser era " + PlayerPrefs.GetInt("Laser"));

        if (PlayerPrefs.GetInt("Laser") == 0)
        {
            PlayerPrefs.SetInt("Laser", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Laser", 0);
        }

        Debug.Log("Agora é " + PlayerPrefs.GetInt("Laser"));
    }

    public void MiniMapaOnOff()
    {

        Debug.Log("Minimapa era " + PlayerPrefs.GetInt("MiniMapa"));

        if (PlayerPrefs.GetInt("MiniMapa") == 0)
        {
            PlayerPrefs.SetInt("MiniMapa", 1);
        }
        else
        {
            PlayerPrefs.SetInt("MiniMapa", 0);
        }

        Debug.Log("Agora é " + PlayerPrefs.GetInt("MiniMapa"));
    }
}
