using UnityEngine;
using System.Collections;

public class RobotSkins : MonoBehaviour {

    public int skinNo;
    public Sprite[] skins;

	// Use this for initialization
	void Start () {

        Debug.Log("Skin1 :" + PlayerPrefs.GetInt("Skin1"));
        Debug.Log("Skin2 :" + PlayerPrefs.GetInt("Skin2"));
        Debug.Log("Skin3 :" + PlayerPrefs.GetInt("Skin3"));
        Debug.Log("Skin4 :" + PlayerPrefs.GetInt("Skin4"));
        Debug.Log("Skin5 :" + PlayerPrefs.GetInt("Skin5"));
        Debug.Log("Skin6 :" + PlayerPrefs.GetInt("Skin6"));

        if (PlayerPrefs.GetInt("Skin1") == 1)
        {
            GetComponent<SpriteRenderer>().sprite = skins[1];
        }
        else if (PlayerPrefs.GetInt("Skin2") == 1)
        {
            GetComponent<SpriteRenderer>().sprite = skins[2];
        }
        else if (PlayerPrefs.GetInt("Skin3") == 1)
        {
            GetComponent<SpriteRenderer>().sprite = skins[3];
        }
        else if (PlayerPrefs.GetInt("Skin4") == 1)
        {
            GetComponent<SpriteRenderer>().sprite = skins[4];
        }
        else if (PlayerPrefs.GetInt("Skin5") == 1)
        {
            GetComponent<SpriteRenderer>().sprite = skins[5];
        }
        else if (PlayerPrefs.GetInt("Skin6") == 1)
        {
            GetComponent<SpriteRenderer>().sprite = skins[6];
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = skins[0];
        }

        //GetComponent<SpriteRenderer>().sprite = skins[skinNo];
	}
	
}
