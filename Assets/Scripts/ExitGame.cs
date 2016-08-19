using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ExitGame : MonoBehaviour {

    public GameObject gameManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        // Home / Menu button pressed
        if(Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Menu)){

            // It's in a stage scene
            if (SceneManager.GetActiveScene().name.Contains("-"))
            {
                OnApplicationFocus(false);
            }
            else
            {
                PlayerPrefs.SetInt("MainMenuOff", 0);
                SceneManager.LoadScene(0);
                //Application.Quit();
            }
        }
	}

    void OnApplicationFocus(bool focusStatus)
    {
        //Debug.Log("AppFocus - " + focusStatus);
        if (!focusStatus && SceneManager.GetActiveScene().name.Contains("-") && !gameManager.GetComponent<GameManager>().victoryModal.activeInHierarchy && !gameManager.GetComponent<GameManager>().loseModal.activeInHierarchy)
        {
            gameManager.GetComponent<GameManager>().pauseGame();
        }
    }
}
