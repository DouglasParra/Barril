using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DisplayExitCanvas : MonoBehaviour {

    public GameObject exitGameCanvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            exitGameCanvas.SetActive(true);
        }
	}

    public void ExitGame() {
        //SceneManager.LoadScene(0);
        Application.Quit();
    }
}
