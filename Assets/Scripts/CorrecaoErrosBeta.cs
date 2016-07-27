using UnityEngine;
using System.Collections;

public class CorrecaoErrosBeta : MonoBehaviour {

	// Use this for initialization
    // Deletar o script ao término da beta
	void Start () {
        if (PlayerPrefs.GetInt("Fases") > 80)
        {
            PlayerPrefs.SetInt("Fases", 21);
        }
	}
	
}
