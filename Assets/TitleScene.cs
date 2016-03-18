using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeScene() {
		if (PlayerPrefs.GetInt ("tutorialDone") == 1) {
			SceneManager.LoadScene ("StageSelect");
		} else {
			SceneManager.LoadScene ("Scene1");
		}
	}
}
