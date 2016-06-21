using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoostsScript : MonoBehaviour {

    public Toggle laser;
    public Toggle minimapa;

    public Toggle skin1;
    public Toggle skin2;
    public Toggle skin3;
    public Toggle skin4;
    public Toggle skin5;
    public Toggle skin6;

	// Use this for initialization
	void Start () {

        //Debug.Log("Laser :" + PlayerPrefs.GetInt("Laser"));
        //Debug.Log("MiniMapa :" + PlayerPrefs.GetInt("MiniMapa"));

        Debug.Log("Skin1 :" + PlayerPrefs.GetInt("Skin1"));
        Debug.Log("Skin2 :" + PlayerPrefs.GetInt("Skin2"));
        Debug.Log("Skin3 :" + PlayerPrefs.GetInt("Skin3"));
        Debug.Log("Skin4 :" + PlayerPrefs.GetInt("Skin4"));
        Debug.Log("Skin5 :" + PlayerPrefs.GetInt("Skin5"));
        Debug.Log("Skin6 :" + PlayerPrefs.GetInt("Skin6"));

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

        if (PlayerPrefs.GetInt("Skin1") == 0)
        {
            skin1.isOn = false;
        }
        else
        {
            skin1.isOn = true;
        }

        if (PlayerPrefs.GetInt("Skin2") == 0)
        {
            skin2.isOn = false;
        }
        else
        {
            skin2.isOn = true;
        }

        if (PlayerPrefs.GetInt("Skin3") == 0)
        {
            skin3.isOn = false;
        }
        else
        {
            skin3.isOn = true;
        }

        if (PlayerPrefs.GetInt("Skin4") == 0)
        {
            skin4.isOn = false;
        }
        else
        {
            skin4.isOn = true;
        }

        if (PlayerPrefs.GetInt("Skin5") == 0)
        {
            skin5.isOn = false;
        }
        else
        {
            skin5.isOn = true;
        }

        if (PlayerPrefs.GetInt("Skin6") == 0)
        {
            skin6.isOn = false;
        }
        else
        {
            skin6.isOn = true;
        }
	}

    public void LaserOnOff() {

        if (laser.interactable)
        {
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
    }

    public void MiniMapaOnOff()
    {
        if (minimapa.interactable)
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

    public void Skin1OnOff()
    {
        if (skin1.interactable)
        {
            if (PlayerPrefs.GetInt("Skin1") == 0)
            {
                ZerarSkins();
                PlayerPrefs.SetInt("Skin1", 1);
                skin1.isOn = true;
            }
            else
            {
                ZerarSkins();
                skin1.isOn = false;
            }
        }
    }

    public void Skin2OnOff()
    {
        if (skin2.interactable)
        {
            if (PlayerPrefs.GetInt("Skin2") == 0)
            {
                ZerarSkins();
                PlayerPrefs.SetInt("Skin2", 1);
                skin2.isOn = true;
            }
            else
            {
                ZerarSkins();
                skin2.isOn = false;
            }
        }
    }

    public void Skin3OnOff()
    {
        if (skin3.interactable)
        {
            if (PlayerPrefs.GetInt("Skin3") == 0)
            {
                ZerarSkins();
                PlayerPrefs.SetInt("Skin3", 1);
                skin3.isOn = true;
            }
            else
            {
                ZerarSkins();
                skin3.isOn = false;
            }
        }
    }

    public void Skin4OnOff()
    {
        if (skin4.interactable)
        {
            if (PlayerPrefs.GetInt("Skin4") == 0)
            {
                ZerarSkins();
                PlayerPrefs.SetInt("Skin4", 1);
                skin4.isOn = true;
            }
            else
            {
                ZerarSkins();
                skin4.isOn = false;
            }
        }
    }

    public void Skin5OnOff()
    {
        if (skin5.interactable)
        {
            if (PlayerPrefs.GetInt("Skin5") == 0)
            {
                ZerarSkins();
                PlayerPrefs.SetInt("Skin5", 1);
                skin5.isOn = true;
            }
            else
            {
                ZerarSkins();
                skin5.isOn = false;
            }
        }
    }

    public void Skin6OnOff()
    {
        if (skin6.interactable)
        {
            if (PlayerPrefs.GetInt("Skin6") == 0)
            {
                ZerarSkins();
                PlayerPrefs.SetInt("Skin6", 1);
                skin6.isOn = true;
            }
            else
            {
                ZerarSkins();
                skin6.isOn = false;
            }
        }
    }

    public void ZerarSkins() {
        PlayerPrefs.SetInt("Skin1", 0);
        PlayerPrefs.SetInt("Skin2", 0);
        PlayerPrefs.SetInt("Skin3", 0);
        PlayerPrefs.SetInt("Skin4", 0);
        PlayerPrefs.SetInt("Skin5", 0);
        PlayerPrefs.SetInt("Skin6", 0);
    }
}
