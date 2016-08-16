using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoostsScript : MonoBehaviour {

    public Toggle laser;
    public Toggle minimapa;
    public Toggle mark;

    public Toggle skin1;
    public Toggle skin2;
    public Toggle skin3;
    public Toggle skin4;
    public Toggle skin5;
    public Toggle skin6;
    public Toggle skin7;
    public Toggle skin8;
    public Toggle skin9;
    public Toggle skin10;
    public Toggle skin11;
    public Toggle skin12;
    public Toggle skin13;

	// Use this for initialization
	void Start () {

        ////Debug.Log("Laser :" + PlayerPrefs.GetInt("Laser"));
        ////Debug.Log("MiniMapa :" + PlayerPrefs.GetInt("MiniMapa"));

        //Debug.Log("Skin1 :" + PlayerPrefs.GetInt("Skin1"));
        //Debug.Log("Skin2 :" + PlayerPrefs.GetInt("Skin2"));
        //Debug.Log("Skin3 :" + PlayerPrefs.GetInt("Skin3"));
        //Debug.Log("Skin4 :" + PlayerPrefs.GetInt("Skin4"));
        //Debug.Log("Skin5 :" + PlayerPrefs.GetInt("Skin5"));
        //Debug.Log("Skin6 :" + PlayerPrefs.GetInt("Skin6"));

        if (PlayerPrefs.GetInt("Laser") == 0)
        {
            laser.isOn = false;
            laser.transform.GetChild(1).GetComponent<Text>().text = "     Laser desligado";
        }
        else 
        {
            laser.isOn = true;
            laser.transform.GetChild(1).GetComponent<Text>().text = "     Laser ligado";
        }

        if (PlayerPrefs.GetInt("MiniMapa") == 0)
        {
            minimapa.isOn = false;
            minimapa.transform.GetChild(1).GetComponent<Text>().text = "     Radar desligado";
        }
        else
        {
            minimapa.isOn = true;
            minimapa.transform.GetChild(1).GetComponent<Text>().text = "     Radar ligado";
        }

        if (PlayerPrefs.GetInt("Mark") == 0)
        {
            mark.isOn = false;
            mark.transform.GetChild(1).GetComponent<Text>().text = "     Marca desligada";
        }
        else
        {
            mark.isOn = true;
            mark.transform.GetChild(1).GetComponent<Text>().text = "     Marca ligada";
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

        if (PlayerPrefs.GetInt("Skin7") == 0)
        {
            skin7.isOn = false;
        }
        else
        {
            skin7.isOn = true;
        }

        if (PlayerPrefs.GetInt("Skin8") == 0)
        {
            skin8.isOn = false;
        }
        else
        {
            skin8.isOn = true;
        }

        if (PlayerPrefs.GetInt("Skin9") == 0)
        {
            skin9.isOn = false;
        }
        else
        {
            skin9.isOn = true;
        }

        if (PlayerPrefs.GetInt("Skin10") == 0)
        {
            skin10.isOn = false;
        }
        else
        {
            skin10.isOn = true;
        }

        if (PlayerPrefs.GetInt("Skin11") == 0)
        {
            skin11.isOn = false;
        }
        else
        {
            skin11.isOn = true;
        }

        if (PlayerPrefs.GetInt("Skin12") == 0)
        {
            skin12.isOn = false;
        }
        else
        {
            skin12.isOn = true;
        }

        if (PlayerPrefs.GetInt("Skin13") == 0)
        {
            skin13.isOn = false;
        }
        else
        {
            skin13.isOn = true;
        }
	}

    public void LaserOnOff() {

        if (laser.interactable)
        {
            //Debug.Log("Laser era " + PlayerPrefs.GetInt("Laser"));

            if (PlayerPrefs.GetInt("Laser") == 0)
            {
                PlayerPrefs.SetInt("Laser", 1);
                laser.transform.GetChild(1).GetComponent<Text>().text = "     Laser ligado";
            }
            else
            {
                PlayerPrefs.SetInt("Laser", 0);
                laser.transform.GetChild(1).GetComponent<Text>().text = "     Laser desligado";
            }

            //Debug.Log("Agora é " + PlayerPrefs.GetInt("Laser"));
        }
    }

    public void MiniMapaOnOff()
    {
        if (minimapa.interactable)
        {
            //Debug.Log("Minimapa era " + PlayerPrefs.GetInt("MiniMapa"));

            if (PlayerPrefs.GetInt("MiniMapa") == 0)
            {
                PlayerPrefs.SetInt("MiniMapa", 1);
                minimapa.transform.GetChild(1).GetComponent<Text>().text = "     Radar ligado";
            }
            else
            {
                PlayerPrefs.SetInt("MiniMapa", 0);
                minimapa.transform.GetChild(1).GetComponent<Text>().text = "     Radar desligado";
            }

            //Debug.Log("Agora é " + PlayerPrefs.GetInt("MiniMapa"));
        }
    }

    public void MarkOnOff()
    {
        if (mark.interactable)
        {
            //Debug.Log("Minimapa era " + PlayerPrefs.GetInt("MiniMapa"));

            if (PlayerPrefs.GetInt("Mark") == 0)
            {
                PlayerPrefs.SetInt("Mark", 1);
                mark.transform.GetChild(1).GetComponent<Text>().text = "     Marca ligada";
            }
            else
            {
                PlayerPrefs.SetInt("Mark", 0);
                mark.transform.GetChild(1).GetComponent<Text>().text = "     Marca desligada";
            }

            //Debug.Log("Agora é " + PlayerPrefs.GetInt("MiniMapa"));
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

    public void Skin7OnOff()
    {
        if (skin7.interactable)
        {
            if (PlayerPrefs.GetInt("Skin7") == 0)
            {
                ZerarSkins();
                PlayerPrefs.SetInt("Skin7", 1);
                skin7.isOn = true;
            }
            else
            {
                ZerarSkins();
                skin7.isOn = false;
            }
        }
    }

    public void Skin8OnOff()
    {
        if (skin8.interactable)
        {
            if (PlayerPrefs.GetInt("Skin8") == 0)
            {
                ZerarSkins();
                PlayerPrefs.SetInt("Skin8", 1);
                skin8.isOn = true;
            }
            else
            {
                ZerarSkins();
                skin8.isOn = false;
            }
        }
    }

    public void Skin9OnOff()
    {
        if (skin9.interactable)
        {
            if (PlayerPrefs.GetInt("Skin9") == 0)
            {
                ZerarSkins();
                PlayerPrefs.SetInt("Skin9", 1);
                skin9.isOn = true;
            }
            else
            {
                ZerarSkins();
                skin9.isOn = false;
            }
        }
    }

    public void Skin10OnOff()
    {
        if (skin10.interactable)
        {
            if (PlayerPrefs.GetInt("Skin10") == 0)
            {
                ZerarSkins();
                PlayerPrefs.SetInt("Skin10", 1);
                skin10.isOn = true;
            }
            else
            {
                ZerarSkins();
                skin10.isOn = false;
            }
        }
    }

    public void Skin11OnOff()
    {
        if (skin11.interactable)
        {
            if (PlayerPrefs.GetInt("Skin11") == 0)
            {
                ZerarSkins();
                PlayerPrefs.SetInt("Skin11", 1);
                skin11.isOn = true;
            }
            else
            {
                ZerarSkins();
                skin11.isOn = false;
            }
        }
    }

    public void Skin12OnOff()
    {
        if (skin12.interactable)
        {
            if (PlayerPrefs.GetInt("Skin12") == 0)
            {
                ZerarSkins();
                PlayerPrefs.SetInt("Skin12", 1);
                skin12.isOn = true;
            }
            else
            {
                ZerarSkins();
                skin12.isOn = false;
            }
        }
    }

    public void Skin13OnOff()
    {
        if (skin13.interactable)
        {
            if (PlayerPrefs.GetInt("Skin13") == 0)
            {
                ZerarSkins();
                PlayerPrefs.SetInt("Skin13", 1);
                skin13.isOn = true;
            }
            else
            {
                ZerarSkins();
                skin13.isOn = false;
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
        PlayerPrefs.SetInt("Skin7", 0);
        PlayerPrefs.SetInt("Skin8", 0);
        PlayerPrefs.SetInt("Skin9", 0);
        PlayerPrefs.SetInt("Skin10", 0);
        PlayerPrefs.SetInt("Skin11", 0);
        PlayerPrefs.SetInt("Skin12", 0);
        PlayerPrefs.SetInt("Skin13", 0);
    }
}
