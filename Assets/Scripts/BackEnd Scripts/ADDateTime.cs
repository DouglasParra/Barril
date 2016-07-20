using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class ADDateTime : MonoBehaviour {

    public Button adButton;

	// Use this for initialization
	void Start () {
        DateTime time1 = DateTime.Parse(PlayerPrefs.GetString("ADDateTime"));

        // Passou mais de um dia?
        if ((DateTime.Now - time1).TotalDays >= 1)
        {
            // Pode dar mais 5 vidas por AD
            PlayerPrefs.SetInt("ADLifes", 5);

            // Salva o horário
            PlayerPrefs.SetString("ADDateTime", DateTime.Now.ToString());
        }
        else if (PlayerPrefs.GetInt("ADLifes") <= 1)
        {
            adButton.interactable = false;
        }
	}

    public void VerificarAdButton()
    {
        if (PlayerPrefs.GetInt("ADLifes") <= 1)
        {
            adButton.interactable = false;
        }
    }
}
