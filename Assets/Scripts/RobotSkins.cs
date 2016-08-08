using UnityEngine;
using System.Collections;

public class RobotSkins : MonoBehaviour {

    public int skinNo;
    public Sprite[] skins;

	// Use this for initialization
	void Start () {

        //Debug.Log("Skin1 :" + PlayerPrefs.GetInt("Skin1"));
        //Debug.Log("Skin2 :" + PlayerPrefs.GetInt("Skin2"));
        //Debug.Log("Skin3 :" + PlayerPrefs.GetInt("Skin3"));
        //Debug.Log("Skin4 :" + PlayerPrefs.GetInt("Skin4"));
        //Debug.Log("Skin5 :" + PlayerPrefs.GetInt("Skin5"));
        //Debug.Log("Skin6 :" + PlayerPrefs.GetInt("Skin6"));

        //ZerarSkins();
        //PlayerPrefs.SetInt("Skin10", 1);

        if (PlayerPrefs.GetInt("Skin1") == 1)
        {
            GetComponent<SpriteRenderer>().sprite = skins[1];
            skinNo = 1;
        }
        else if (PlayerPrefs.GetInt("Skin2") == 1)
        {
            GetComponent<SpriteRenderer>().sprite = skins[2];
            skinNo = 2;
        }
        else if (PlayerPrefs.GetInt("Skin3") == 1)
        {
            GetComponent<SpriteRenderer>().sprite = skins[3];
            skinNo = 3;
        }
        else if (PlayerPrefs.GetInt("Skin4") == 1)
        {
            GetComponent<SpriteRenderer>().sprite = skins[4];
            skinNo = 4;
        }
        else if (PlayerPrefs.GetInt("Skin5") == 1)
        {
            GetComponent<SpriteRenderer>().sprite = skins[5];
            skinNo = 5;
        }
        else if (PlayerPrefs.GetInt("Skin6") == 1)
        {
            GetComponent<SpriteRenderer>().sprite = skins[6];
            skinNo = 6;
        }
        else if (PlayerPrefs.GetInt("Skin7") == 1)
        {
            GetComponent<SpriteRenderer>().sprite = skins[7];
            skinNo = 7;
        }
        else if (PlayerPrefs.GetInt("Skin8") == 1)
        {
            GetComponent<SpriteRenderer>().sprite = skins[8];
            skinNo = 8;
        }
        else if (PlayerPrefs.GetInt("Skin9") == 1)
        {
            GetComponent<SpriteRenderer>().sprite = skins[9];
            skinNo = 9;
        }
        else if (PlayerPrefs.GetInt("Skin10") == 1)
        {
            GetComponent<SpriteRenderer>().sprite = skins[10];
            skinNo = 10;
        }
        else if (PlayerPrefs.GetInt("Skin11") == 1)
        {
            GetComponent<SpriteRenderer>().sprite = skins[11];
            skinNo = 11;
        }
        else if (PlayerPrefs.GetInt("Skin12") == 1)
        {
            GetComponent<SpriteRenderer>().sprite = skins[12];
            skinNo = 12;
        }
        else if (PlayerPrefs.GetInt("Skin13") == 1)
        {
            GetComponent<SpriteRenderer>().sprite = skins[13];
            skinNo = 13;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = skins[0];
            skinNo = 0;
        }

        //GetComponent<SpriteRenderer>().sprite = skins[skinNo];
	}

    /*public void ZerarSkins()
    {
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
    }*/
}
