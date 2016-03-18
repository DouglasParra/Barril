using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LogoScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeScene() {
		SceneManager.LoadScene ("TitleScene");
	}
}
