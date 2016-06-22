using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Facebook.Unity;

public class StageSelectScript : MonoBehaviour
{

    public Text playerName;
    public GameObject energyTime;
    public GameObject gameSparksManager;

    public GameObject[] mundos;
    public GameObject cantPlayImage;

    private int QTDE_MUNDO = 8;
    private int mundoAtual;

    // Use this for initialization
    void Start()
    {
        playerName.text = PlayerPrefs.GetString("DisplayName");
        mundoAtual = 0;
        gameSparksManager = GameObject.Find("GameSparks Manager");
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
        //Debug.Log(energyTime.GetComponent<EnergyTime>().time.text);
        gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
        PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
        SaveMinuteSeconds();
        SceneManager.LoadScene("RankScene");
    }

    public void scene1_1()
    {
        if (canPlay())
        {
            gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
            gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
            gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
            PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
            SaveMinuteSeconds();
            SceneManager.LoadScene("1-1");
        }
        else
        {
            cantPlayImage.SetActive(true);
        }
    }

    public void scene1_2()
    {
        if (canPlay())
        {

            gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
            gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
            gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
            PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
            SaveMinuteSeconds();
            SceneManager.LoadScene("1-2");
        }
        else
        {
            cantPlayImage.SetActive(true);
        }
    }

    public void scene1_3()
    {
        if (canPlay())
        {
            gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
            gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
            gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
            PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
            SaveMinuteSeconds();
            SceneManager.LoadScene("1-3");
        }
        else
        {
            cantPlayImage.SetActive(true);
        }

    }

    public void scene1_4()
    {
        if (canPlay())
        {
            gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
            gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
            gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
            PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
            SaveMinuteSeconds();
            SceneManager.LoadScene("1-4");
        }
        else
        {
            cantPlayImage.SetActive(true);
        }
    }

    public void scene1_5()
    {
        if (canPlay())
        {
            gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
            gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
            gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
            PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
            SaveMinuteSeconds();
            SceneManager.LoadScene("1-5");
        }
        else
        {
            cantPlayImage.SetActive(true);
        }
    }

    public void scene1_6()
    {
        if (canPlay())
        {
            gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
            gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
            gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
            PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
            SaveMinuteSeconds();
            SceneManager.LoadScene("1-6");
        }
        else
        {
            cantPlayImage.SetActive(true);
        }
    }

    public void scene1_7()
    {
        if (canPlay())
        {
            gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
            gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
            gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
            PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
            SaveMinuteSeconds();
            SceneManager.LoadScene("1-7");
        }
        else
        {
            cantPlayImage.SetActive(true);
        }
    }

    public void scene1_8()
    {
        if (canPlay())
        {
            gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
            gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
            gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
            PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
            SaveMinuteSeconds();
            SceneManager.LoadScene("1-8");
        }
        else
        {
            cantPlayImage.SetActive(true);
        }
    }

    public void scene1_9()
    {
        if (canPlay())
        {
            gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
            gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
            gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
            PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
            SaveMinuteSeconds();
            SceneManager.LoadScene("1-9");
        }
        else
        {
            cantPlayImage.SetActive(true);
        }
    }

    public void scene1_10()
    {
        if (canPlay())
        {
            gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
            gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
            gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
            PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
            SaveMinuteSeconds();
            SceneManager.LoadScene("1-10");
        }
        else
        {
            cantPlayImage.SetActive(true);
        }
    }

    public void tutorial()
    {
        gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
        PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
        SaveMinuteSeconds();
        SceneManager.LoadScene("TutorialScene");
    }

    public void loadScene(string scene)
    {
        if (canPlay())
        {
            gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
            gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
            gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
            PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
            SaveMinuteSeconds();
            SceneManager.LoadScene(scene);
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
    }

    public void previousWorld()
    {
        mundos[mundoAtual].gameObject.SetActive(false);
        mundoAtual = mundoAtual - 1;
        if (mundoAtual < 0) mundoAtual = QTDE_MUNDO - 1;
        mundos[mundoAtual].gameObject.SetActive(true);
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
