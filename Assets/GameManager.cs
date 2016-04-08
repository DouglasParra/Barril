using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject loseModal;
	public GameObject victoryModal;
	public GameObject pauseModal;
	public GameObject pauseButton;
	public GameObject clockPanel;

	public Text victoryClockText;
	public ClockTime clockTime;

	void Awake () {
		startAll ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void loseGame () {
		stopAll ();
		showLoseModal ();
	}

	public void victoryGame () {
		stopAll ();
		showVictoryModal ();
		showClockTime ();
		hidePauseButton ();
		saveTime ();
		verifyTutorialDone ();
	}

	void showClockTime () {
		victoryClockText.text = clockTime.timestring;
		clockPanel.SetActive (false);
	}

	void showVictoryModal () {
		if (victoryModal) {
			victoryModal.SetActive (true);
		}
	}

	public void goToStageSelectScene () {
		SceneManager.LoadScene ("StageSelect");
	}

	public void goToNextScene () {
		try {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
		}
		catch (System.Exception e) {
			goToStageSelectScene ();
		}
	}

	public void restart () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	void saveTime () {
		Debug.Log ("Venci - " + clockTime.timestring + " -- " + clockTime.timer);
	}

	void showLoseModal () {
		if (loseModal) {
			loseModal.SetActive (true);
		}
	}

	public void pauseGame () {
		stopAll ();
		hidePauseButton ();
		showPauseModal ();
	}

	void hidePauseButton () {
		pauseButton.SetActive (false);
	}

	void showPauseButton () {
		pauseButton.SetActive (true);
	}
		
	public void unpauseGame () {
		startAll ();
		hidePauseModal ();
		showPauseButton ();
	}

	void showPauseModal () {
		pauseModal.SetActive (true);
	}

	void hidePauseModal () {
		pauseModal.SetActive (false);
	}
		
	void stopAll () {
		Time.timeScale = 0;
	}

	void startAll () {
		Time.timeScale = 1;
	}

	void verifyTutorialDone () {
		if (PlayerPrefs.HasKey ("tutorialDone") == false) {
			PlayerPrefs.SetInt ("tutorialDone", 1);
		}
	}
}
