using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ExitGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Menu)){
            // Home / Menu button pressed
            PlayerPrefs.SetInt("MainMenuOff", 0);
            SceneManager.LoadScene(0);
            //Application.Quit();
        }

	}
}
