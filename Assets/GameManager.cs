using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


using GameSparks.Core;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public GameObject loseModal;
	public GameObject victoryModal;
	public GameObject pauseModal;
	public GameObject pauseButton;
	public GameObject clockPanel;

	public Text victoryClockText;
	public ClockTime clockTime;

    private string loadedID = "";
    private string loadedTime = "";

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

        if (SceneManager.GetActiveScene().name.Equals("1-1")) 
        {
            SalvarTempoGameSparks_1_1();
        }
        else if (SceneManager.GetActiveScene().name.Equals("1-2"))
        {
            SalvarTempoGameSparks_1_2();
        }
        else if (SceneManager.GetActiveScene().name.Equals("1-3"))
        {
            SalvarTempoGameSparks_1_3();
        }
        else if (SceneManager.GetActiveScene().name.Equals("1-4"))
        {
            SalvarTempoGameSparks_1_4();
        }
        else if (SceneManager.GetActiveScene().name.Equals("1-5"))
        {
            SalvarTempoGameSparks_1_5();
        }
        else if (SceneManager.GetActiveScene().name.Equals("1-6"))
        {
            SalvarTempoGameSparks_1_6();
        }
        else if (SceneManager.GetActiveScene().name.Equals("1-7"))
        {
            SalvarTempoGameSparks_1_7();
        }
        else if (SceneManager.GetActiveScene().name.Equals("1-8"))
        {
            SalvarTempoGameSparks_1_8();
        }
        else if (SceneManager.GetActiveScene().name.Equals("1-9"))
        {
            SalvarTempoGameSparks_1_9();
        }
        else if (SceneManager.GetActiveScene().name.Equals("1-10"))
        {
            SalvarTempoGameSparks_1_10();
        }

        // Debug.Log(loadedID + " - " + loadedTime);
        // Debug.Log(string.Compare(loadedTime, clockTime.timestring));
	}

    void SalvarTempoGameSparks_1_1() {

        // Se arg1 > arg2, compare==1
        // Debug.Log("Tempo salvo no GS: " + loadedTime + " - Tempo desse jogo: " + clockTime.timestring);

        // switch para, dado o nome da fase, pegar o índice dela em records[]
        if (string.Compare(clockTime.timestring, GameSparksManager.records[0])==-1) 
        {
            GameSparksManager.records[0] = clockTime.timestring;

            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("SAVE_STAGE_1_1")
                .SetEventAttribute("TIME_1_1", clockTime.timestring)
                .Send((response) =>
                {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Player Saved To GameSparks...");
                    }
                    else
                    {
                        Debug.Log("Error Saving Player Data...");
                    }
                });
        }
    }

    void SalvarTempoGameSparks_1_2()
    {

        // Se arg1 > arg2, compare==1
        // Debug.Log("Tempo salvo no GS: " + loadedTime + " - Tempo desse jogo: " + clockTime.timestring);
        if (string.Compare(clockTime.timestring, GameSparksManager.records[1]) == -1)
        {
            GameSparksManager.records[1] = clockTime.timestring;

            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("SAVE_STAGE_1_2")
                .SetEventAttribute("TIME_1_2", clockTime.timestring)
                .Send((response) =>
                {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Player Saved To GameSparks...");
                    }
                    else
                    {
                        Debug.Log("Error Saving Player Data...");
                    }
                });
        }
    }

    void SalvarTempoGameSparks_1_3()
    {

        // Se arg1 > arg2, compare==1
        // Debug.Log("Tempo salvo no GS: " + loadedTime + " - Tempo desse jogo: " + clockTime.timestring);
        if (string.Compare(clockTime.timestring, GameSparksManager.records[2]) == -1)
        {
            GameSparksManager.records[2] = clockTime.timestring;

            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("SAVE_STAGE_1_3")
                .SetEventAttribute("TIME_1_3", clockTime.timestring)
                .Send((response) =>
                {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Player Saved To GameSparks...");
                    }
                    else
                    {
                        Debug.Log("Error Saving Player Data...");
                    }
                });
        }
    }

    void SalvarTempoGameSparks_1_4()
    {

        // Se arg1 > arg2, compare==1
        // Debug.Log("Tempo salvo no GS: " + loadedTime + " - Tempo desse jogo: " + clockTime.timestring);
        if (string.Compare(clockTime.timestring, GameSparksManager.records[3]) == -1)
        {
            GameSparksManager.records[3] = clockTime.timestring;

            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("SAVE_STAGE_1_4")
                .SetEventAttribute("TIME_1_4", clockTime.timestring)
                .Send((response) =>
                {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Player Saved To GameSparks...");
                    }
                    else
                    {
                        Debug.Log("Error Saving Player Data...");
                    }
                });
        }
    }

    void SalvarTempoGameSparks_1_5()
    {

        // Se arg1 > arg2, compare==1
        // Debug.Log("Tempo salvo no GS: " + loadedTime + " - Tempo desse jogo: " + clockTime.timestring);
        if (string.Compare(clockTime.timestring, GameSparksManager.records[4]) == -1)
        {
            GameSparksManager.records[4] = clockTime.timestring;

            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("SAVE_STAGE_1_5")
                .SetEventAttribute("TIME_1_5", clockTime.timestring)
                .Send((response) =>
                {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Player Saved To GameSparks...");
                    }
                    else
                    {
                        Debug.Log("Error Saving Player Data...");
                    }
                });
        }
    }

    void SalvarTempoGameSparks_1_6()
    {

        // Se arg1 > arg2, compare==1
        // Debug.Log("Tempo salvo no GS: " + loadedTime + " - Tempo desse jogo: " + clockTime.timestring);
        if (string.Compare(clockTime.timestring, GameSparksManager.records[5]) == -1)
        {
            GameSparksManager.records[5] = clockTime.timestring;

            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("SAVE_STAGE_1_6")
                .SetEventAttribute("TIME_1_6", clockTime.timestring)
                .Send((response) =>
                {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Player Saved To GameSparks...");
                    }
                    else
                    {
                        Debug.Log("Error Saving Player Data...");
                    }
                });
        }
    }

    void SalvarTempoGameSparks_1_7()
    {

        // Se arg1 > arg2, compare==1
        // Debug.Log("Tempo salvo no GS: " + loadedTime + " - Tempo desse jogo: " + clockTime.timestring);
        if (string.Compare(clockTime.timestring, GameSparksManager.records[6]) == -1)
        {
            GameSparksManager.records[6] = clockTime.timestring;

            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("SAVE_STAGE_1_7")
                .SetEventAttribute("TIME_1_7", clockTime.timestring)
                .Send((response) =>
                {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Player Saved To GameSparks...");
                    }
                    else
                    {
                        Debug.Log("Error Saving Player Data...");
                    }
                });
        }
    }

    void SalvarTempoGameSparks_1_8()
    {

        // Se arg1 > arg2, compare==1
        // Debug.Log("Tempo salvo no GS: " + loadedTime + " - Tempo desse jogo: " + clockTime.timestring);
        if (string.Compare(clockTime.timestring, GameSparksManager.records[7]) == -1)
        {
            GameSparksManager.records[7] = clockTime.timestring;

            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("SAVE_STAGE_1_8")
                .SetEventAttribute("TIME_1_8", clockTime.timestring)
                .Send((response) =>
                {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Player Saved To GameSparks...");
                    }
                    else
                    {
                        Debug.Log("Error Saving Player Data...");
                    }
                });
        }
    }

    void SalvarTempoGameSparks_1_9()
    {

        // Se arg1 > arg2, compare==1
        // Debug.Log("Tempo salvo no GS: " + loadedTime + " - Tempo desse jogo: " + clockTime.timestring);
        if (string.Compare(clockTime.timestring, GameSparksManager.records[8]) == -1)
        {
            GameSparksManager.records[8] = clockTime.timestring;

            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("SAVE_STAGE_1_9")
                .SetEventAttribute("TIME_1_9", clockTime.timestring)
                .Send((response) =>
                {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Player Saved To GameSparks...");
                    }
                    else
                    {
                        Debug.Log("Error Saving Player Data...");
                    }
                });
        }
    }

    void SalvarTempoGameSparks_1_10()
    {

        // Se arg1 > arg2, compare==1
        // Debug.Log("Tempo salvo no GS: " + loadedTime + " - Tempo desse jogo: " + clockTime.timestring);
        if (string.Compare(clockTime.timestring, GameSparksManager.records[9]) == -1)
        {
            GameSparksManager.records[9] = clockTime.timestring;

            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("SAVE_STAGE_1_10")
                .SetEventAttribute("TIME_1_10", clockTime.timestring)
                .Send((response) =>
                {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Player Saved To GameSparks...");
                    }
                    else
                    {
                        Debug.Log("Error Saving Player Data...");
                    }
                });
        }
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
