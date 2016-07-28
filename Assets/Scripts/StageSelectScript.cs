using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Facebook.Unity;

public class StageSelectScript : MonoBehaviour
{

    public Text playerName;
    public GameObject energyTime;

    [HideInInspector]
    public GameObject gameSparksManager;

    public GameObject[] mundos;
    public Sprite[] backgroundMundos;
    public Image backgroundImage;
    public GameObject cantPlayImage;

    public Button rankButton;

    private int QTDE_MUNDO = 8;
    private int mundoAtual;

    public GameObject loadingCanvas;
    public GameObject mainCanvas;
    public GameObject creditsCanvas;

    // Use this for initialization
    void Start()
    {
        // Se possui "DisplayName", não é novo usuário
        if (PlayerPrefs.HasKey("DisplayName"))
        {
            playerName.text = PlayerPrefs.GetString("DisplayName");
        }

        if (PlayerPrefs.GetInt("MainMenuOff") == 1)
        {
            mainCanvas.SetActive(false);
            PlayerPrefs.SetInt("MainMenuOff", 0);
        }

        if (PlayerPrefs.GetInt("Credits") == 1)
        {
            PlayerPrefs.SetInt("Credits", 0);
            creditsCanvas.SetActive(true);
            GetComponent<AudioSource>().Stop();
            creditsCanvas.GetComponent<AudioSource>().Play();
        }

        mundoAtual = 0;
        LiberarFases();
        gameSparksManager = GameObject.Find("GameSparks Manager");
    }

    void Update() {
        /*if (GameObject.Find("GameSparks Manager").GetComponent<ModoOffline>().getModoOffline())
        {
            rankButton.interactable = false;
        }
        else 
        {
            rankButton.interactable = true;
        }*/
    }

    private void LiberarFases()
    {
        int i = 0;
        int j = 0;
        int k = 0;

        while (i < PlayerPrefs.GetInt("Fases") && i <= 80)
        {
            mundos[j].transform.GetChild(k).GetComponent<Button>().interactable = true;
            mundos[j].transform.GetChild(k).GetChild(0).gameObject.SetActive(true);
            mundos[j].transform.GetChild(k).GetChild(1).gameObject.SetActive(false);

            k++;
            if (k > 9)
            {
                k = 0;
                j++;
            }
            i++;
        }
    }

    public void StageSelect()
    {   
        SceneManager.LoadScene(0);
    }

    public void StageSelect_Fases()
    {
        //PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
        SceneManager.LoadScene("StageSelect");
    }

    public bool canPlay()
    {
        if (int.Parse(energyTime.GetComponent<EnergyTime>().life.text) <= 0)
        {
            return false;
        }
        return true;
    }

    public void RankScene()
    {
        ////Debug.Log(energyTime.GetComponent<EnergyTime>().time.text);
        gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
        PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
        SaveMinuteSeconds();
        SceneManager.LoadScene("RankScene");
    }

    // The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
    IEnumerator LoadNewScene(string levelName)
    {

        // This line waits for 1 seconds before executing the next line in the coroutine.
        // This line is only necessary for this demo. The scenes are so simple that they load too fast to read the "Loading..." text.
        yield return new WaitForSeconds(1);

        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        AsyncOperation async = SceneManager.LoadSceneAsync(levelName);

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!async.isDone)
        {
            yield return null;
        }

    }

    public void loadScene(string scene)
    {
        if (scene.Equals("TutorialScene"))
        {
            gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
            gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
            gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
            PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
            SaveMinuteSeconds();

            loadingCanvas.SetActive(true);
            StartCoroutine("LoadNewScene", scene);
        }
        else if (canPlay())
        {
            gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
            gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
            gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
            PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
            SaveMinuteSeconds();

            loadingCanvas.SetActive(true);
            StartCoroutine("LoadNewScene", scene);

            //SceneManager.LoadScene(scene);
        }
        else
        {
            cantPlayImage.SetActive(true);
        }
    }

    public void nextWorld()
    {
        mundos[mundoAtual].gameObject.SetActive(false);
        mundoAtual = mundoAtual + 1;
        if (mundoAtual >= QTDE_MUNDO) mundoAtual = 0;
        mundos[mundoAtual].gameObject.SetActive(true);
        backgroundImage.sprite = backgroundMundos[mundoAtual];
    }

    public void previousWorld()
    {
        mundos[mundoAtual].gameObject.SetActive(false);
        mundoAtual = mundoAtual - 1;
        if (mundoAtual < 0) mundoAtual = QTDE_MUNDO - 1;
        mundos[mundoAtual].gameObject.SetActive(true);
        backgroundImage.sprite = backgroundMundos[mundoAtual];
    }

    // Chamar ao carregar uma fase
    private void SaveMinuteSeconds() {
        energyTime.GetComponent<EnergyTime>().SaveMinuteSeconds();
    }

    void OnApplicationQuit() {
        gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
        PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
        //SaveMinuteSeconds();
    }
}
