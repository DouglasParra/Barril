using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LogoScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        GameObject g = GameObject.Find("GameSparks Manager");
        if (g != null)
        {
            Destroy(g);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeScene() {
		SceneManager.LoadScene ("TitleScene");
	}
}
