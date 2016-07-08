using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


using GameSparks.Core;
using System.Collections.Generic;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour {

	public GameObject loseModal;
	public GameObject victoryModal;
	public GameObject pauseModal;
	public GameObject pauseButton;
	public GameObject clockPanel;

    public GameObject gameSparksManager;

	public Text victoryClockText;
	public ClockTime clockTime;
	public Button loseCheckpointButton;
	public Button pauseCheckponintButton;

    public Text energyText;
    public Text stageText;

	[Tooltip("Insira o numero de checkpoint e sete eles na posição e ordem correta")]
	public GameObject[] checkpoints;

    public GameObject[] portas;

    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;

    public AudioMixer masterMixer;

	void Awake () {
        gameSparksManager = GameObject.Find("GameSparks Manager");

		startAll ();
		verifyCheckpoint ();

        StartCoroutine("CarregarVida");
        // Se tem conexão com a internet
        /*if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            // Pega vida do GameSparks
            LoadLife();
        }
        else 
        {
            // Senão, pega do PlayerPrefs
            energyText.text = PlayerPrefs.GetInt("Vidas").ToString();
        }*/
	}

    private void CarregarTutorial() {
        if (SceneManager.GetActiveScene().name.Equals("TutorialScene"))
        {
            stageText.text = "Tutorial";
        }
        else
        {
            stageText.text = "Stage " + SceneManager.GetActiveScene().name;
        }

        masterMixer.SetFloat("sfxVol", PlayerPrefs.GetFloat("sfxVol"));
        masterMixer.SetFloat("musicVol", PlayerPrefs.GetFloat("musicVol"));

        GameSparks.Api.Messages.NewHighScoreMessage.Listener += HighScoreMessageHandler; // assign the New High Score message
    }

    void Start() {
        for (int i = 0; i < portas.Length; i++) {
            if(PlayerPrefs.HasKey("Porta" + portas[i].name)){
                if (PlayerPrefs.GetInt("Porta" + portas[i].name) == 0) {
                    portas[i].SetActive(false);
                }
            }
        }
    }

    void HighScoreMessageHandler(GameSparks.Api.Messages.NewHighScoreMessage _message)
    {
        //Debug.Log("NEW TIME RECORD\n " + _message.LeaderboardName);
    }

	// Update is called once per frame
	void Update () {

	}

	public void loseGame () {
		stopAll ();
		showLoseModal ();

        StartCoroutine("PerderVida");
        /*if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            //Debug.Log("Conectado, perdendo vida no GS" + (int.Parse(energyText.text) - 1).ToString());
            LoseLife(int.Parse(energyText.text) - 1);
        }
        else
        {
            //Debug.Log("Sem conexão, perdendo vida no PlayerPrefs " + (int.Parse(energyText.text) - 1).ToString());
            energyText.text = (int.Parse(energyText.text) - 1).ToString();
            PlayerPrefs.SetInt("Vidas", int.Parse(energyText.text));
        }*/

        // Desabilita botões de reiniciar fase do começo e do checkpoint
        /*if ((int.Parse(energyText.text)) <= 0)
        {
            loseModal.transform.GetChild(0).GetChild(1).GetComponent<Button>().interactable = false;
            loseModal.transform.GetChild(0).GetChild(2).GetComponent<Button>().interactable = false;
        }*/
	}

	public void victoryGame () {
        if (SceneManager.GetActiveScene().name.Equals("TutorialScene"))
        {
            stopAll();
            verifyTutorialDone();
            SceneManager.LoadScene("StageSelect");
        }
        else
        {
            stopAll();
            showVictoryModal();
            showClockTime();
            hidePauseButton();
            saveTime();
            verifyTutorialDone();
            resetCheckpoint();
        }
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
		resetCheckpoint ();
        if (!clockTime.timestring.Equals("00:00:000") && !victoryModal.activeInHierarchy && !loseModal.activeInHierarchy)
        {
            StartCoroutine("PerderVida");
            /*if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
            {
                LoseLife(int.Parse(energyText.text) - 1);
            }
            else 
            {
                energyText.text = (int.Parse(energyText.text) - 1).ToString();
                PlayerPrefs.SetInt("Vidas", int.Parse(energyText.text));
            }*/
        }
		SceneManager.LoadScene ("StageSelect");
	}

	public void goToNextScene () {
		try {
			resetCheckpoint ();
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
		}
		catch (System.Exception e) {
			//Debug.Log (e.ToString());
			goToStageSelectScene ();
		}
	}

	public void restart () {
        if (!clockTime.timestring.Equals("00:00:000") && !victoryModal.activeInHierarchy && !loseModal.activeInHierarchy)
        {
            StartCoroutine("PerderVida");
            /*if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
            {
                LoseLife(int.Parse(energyText.text) - 1);
            }
            else
            {
                energyText.text = (int.Parse(energyText.text) - 1).ToString();
                PlayerPrefs.SetInt("Vidas", int.Parse(energyText.text));
            }*/
        }
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	void saveTime () {
		//Debug.Log ("Venci - " + clockTime.timestring + " -- " + clockTime.timer);

        // Transforma o tempo em int
        int teste2 = ClockTimeInt();

        //Debug.Log(teste2);
        //Debug.Log("CT: " + clockTime.RetornaTempoString(teste2));

        StartCoroutine("SalvarTempo");
        /*if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            SalvarTempoGameSparks();
        }*/
	}

    private int ClockTimeInt() {
        return int.Parse(clockTime.timestring[0].ToString() +
                         clockTime.timestring[1].ToString() +
                         clockTime.timestring[3].ToString() +
                         clockTime.timestring[4].ToString() +
                         clockTime.timestring[6].ToString() +
                         clockTime.timestring[7].ToString() +
                         clockTime.timestring[8].ToString());
    }

    // Dado o nome da fase no formato "X-Y", retorna a posição no vetor GameSparksManager.records[]
    private int PosicaoVetorRecords(string mundo) {
        string[] m1 = mundo.Split('-'); 
        
        int m2 = int.Parse(m1[0]) - 1;
        int m3 = int.Parse(m1[1]) - 1;

        return int.Parse((m2.ToString() + m3.ToString()));
    }

    // Salva tempo no GS pro Leaderboard da fase que está jogando
    void SalvarTempoGameSparks()
    {
        // m1[0] = String da cena antes do '-' ; m1[1] = String da cena depois do '-' ; 
        string[] m1 = SceneManager.GetActiveScene().name.Split('-');

        // Se ClockTimeInt() < records[], salva
        if (ClockTimeInt() < GameSparksManager.records[PosicaoVetorRecords(SceneManager.GetActiveScene().name)])
        {
            GameSparksManager.records[PosicaoVetorRecords(SceneManager.GetActiveScene().name)] = ClockTimeInt();

            // mudar no gs para ficar 1-1 e assim usar o nome da cena concatenado
            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("SAVE_STAGE_" + m1[0] + "_" + m1[1])
                .SetEventAttribute("TIME_" + m1[0] + "_" + m1[1], ClockTimeInt())
                .Send((response) =>
                {

                    if (!response.HasErrors)
                    {
                        //Debug.Log("Player Saved To GameSparks...");
                        //Debug.Log("Score Posted Sucessfully...");
                    }
                    else
                    {
                        //Debug.Log("Error Saving Player Data...");
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

        Lowpass();

        if ((int.Parse(energyText.text)) <= 0)
        {
            pauseModal.transform.GetChild(0).GetChild(1).GetComponent<Button>().interactable = false;
        }
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
        Lowpass();
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

	public void checkpoint (int order) {
		PlayerPrefs.SetInt ("checkpointOrder", order);
		PlayerPrefs.SetFloat ("checkpointTimer", clockTime.timer);
		PlayerPrefs.SetInt ("hasCheckpoint", 1);
		activeCheckpointButton ();
	}

	void verifyCheckpoint () {
		if (PlayerPrefs.HasKey("startInCheckpoint") 
			&& PlayerPrefs.GetInt ("startInCheckpoint") == 1
			&& PlayerPrefs.HasKey ("hasCheckpoint") 
			&& PlayerPrefs.GetInt ("hasCheckpoint") == 1) {
			setRobotToCheckpoint ();
			setCheckpointTimer ();
			activeCheckpointButton ();
		}
	}

	void activeCheckpointButton () {
		loseCheckpointButton.interactable = true;
		pauseCheckponintButton.interactable = true;
	}

	void setRobotToCheckpoint () {
		GameObject checkpointField = checkpoints[PlayerPrefs.GetInt ("checkpointOrder")] ;
		GameObject.Find ("Robot").SendMessage ("goToField", checkpointField);
	}

	void setCheckpointTimer () {
		clockTime.statTimeCheckpoint (PlayerPrefs.GetFloat ("checkpointTimer"));
	}

	public void restartCheckpoint () {
		PlayerPrefs.SetInt("startInCheckpoint", 1);
		restart ();
	}

	public void restartWithoutCheckpoint () {
		resetCheckpoint ();
		restart ();
	}

	void resetCheckpoint () {
		PlayerPrefs.SetInt("startInCheckpoint", 0); 

        // Reseta portas
        for (int i = 0; i < portas.Length; i++) {
            if (PlayerPrefs.HasKey("Porta" + portas[i].name)) { 
                PlayerPrefs.DeleteKey("Porta" + portas[i].name);
            }
        }
	}

	void OnApplicationQuit() {
		resetCheckpoint ();
	}

    void Lowpass()
    {
        if (Time.timeScale == 0)
        {
            paused.TransitionTo(.01f);
        }
        else
        {
            unpaused.TransitionTo(.01f);
        }
    }

    // Carrega o valor da vida
    private void LoadLife()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("RETRIEVE_RECORDS")
                .Send((response) =>
                {

                    if (!response.HasErrors)
                    {
                        GSData data = response.ScriptData.GetGSData("player_Data");
                        energyText.text = data.GetInt("life").ToString();

                        //Debug.Log("Recieved Player Life Data From GameSparks...");
                    }
                    else
                    {
                        //Debug.Log("Error Loading Player Data...");
                    }
                });
    }

    private void LoseLife(int vida) {
        // Tira uma vida em jogo
        energyText.text = vida.ToString();
        PlayerPrefs.SetInt("Vidas", vida);

        // Tira uma vida no GS
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("SAVE_LIFES")
            .SetEventAttribute("LIFE", vida)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Perdeu uma vida...");

                    if ((int.Parse(energyText.text)) <= 0)
                    {
                        //Debug.Log("Vida <= 0, não pode jogar");
                    }
                    else if ((int.Parse(energyText.text)) == 4)
                    {
                        PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
                    }

                }
                else
                {
                    //Debug.Log("Error Saving Player Data...");
                }
            });
    }

    IEnumerator CarregarVida()
    {
        // Chama o teste de conexão em Modo Offline
        gameSparksManager.GetComponent<ModoOffline>().TestarConexao();

        // Aguarda até terminar o teste
        yield return new WaitUntil(() => gameSparksManager.GetComponent<ModoOffline>().getTestandoConexao() == false);

        // Age de acordo com o resultado, offline ou online
        if (gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            //Debug.Log("Acao - Offline");
            energyText.text = PlayerPrefs.GetInt("Vidas").ToString();
        }
        else
        {
            //Debug.Log("Acao - Online");
            LoadLife();
        }

        CarregarTutorial();
    }

    IEnumerator PerderVida()
    {
        // Chama o teste de conexão em ModoOffline
        gameSparksManager.GetComponent<ModoOffline>().TestarConexao();

        // Aguarda até terminar o teste
        yield return new WaitUntil(() => gameSparksManager.GetComponent<ModoOffline>().getTestandoConexao() == false);

        // Age de acordo com o resultado, offline ou online
        if (gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            //Debug.Log("Acao - Offline");
            energyText.text = (int.Parse(energyText.text) - 1).ToString();
            PlayerPrefs.SetInt("Vidas", int.Parse(energyText.text));
        }
        else
        {
            //Debug.Log("Acao - Online");
            LoseLife(int.Parse(energyText.text) - 1);
        }

        if ((int.Parse(energyText.text)) <= 0)
        {
            loseModal.transform.GetChild(0).GetChild(1).GetComponent<Button>().interactable = false;
            loseModal.transform.GetChild(0).GetChild(2).GetComponent<Button>().interactable = false;
        }
    }

    IEnumerator SalvarTempo()
    {
        // Chama o teste de conexão em ModoOffline
        gameSparksManager.GetComponent<ModoOffline>().TestarConexao();

        // Aguarda até terminar o teste
        yield return new WaitUntil(() => gameSparksManager.GetComponent<ModoOffline>().getTestandoConexao() == false);

        // Age de acordo com o resultado, offline ou online
        if (gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            //Debug.Log("Acao - Offline");
            // Avisar que está offline e não vai salvar o tempo?
        }
        else
        {
            //Debug.Log("Acao - Online");
            SalvarTempoGameSparks();
        }
    }
}
