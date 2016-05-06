using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Facebook.Unity;

public class StageSelectScript : MonoBehaviour {

    public Text playerName;
    public GameObject energyTime;
    public GameObject gameSparksManager;

    public GameObject[] mundos;

    private int QTDE_MUNDO = 8;
    private int mundoAtual;

	// Use this for initialization
	void Start () {
        playerName.text = PlayerPrefs.GetString("DisplayName");
        mundoAtual = 0;
        gameSparksManager = GameObject.Find("GameSparks Manager");
	}

    // Update is called once per frame
	void Awake () {
	
	}

    public void StageSelect() {
        SceneManager.LoadScene(0);
    }

    public void StageSelect_Fases()
    {
        //PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
        SceneManager.LoadScene("StageSelect");
    }

    public void RankScene()
    {
        //Debug.Log(energyTime.GetComponent<EnergyTime>().time.text);
        gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
        PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
        SceneManager.LoadScene("RankScene");
    }

    public void scene1_1()
    {
        gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
        PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
        SceneManager.LoadScene("1-1");
    }

	public void scene1_2()
	{
        gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
        PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
		SceneManager.LoadScene("1-2");
	}

	public void scene1_3()
	{
        gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
        PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
		SceneManager.LoadScene("1-3");
	}

	public void scene1_4()
	{
        gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
        PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
		SceneManager.LoadScene("1-4");
	}

	public void scene1_5()
	{
        gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
        PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
		SceneManager.LoadScene("1-5");
	}

	public void scene1_6()
	{
        gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
        PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
		SceneManager.LoadScene("1-6");
	}

	public void scene1_7()
	{
        gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
        PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
		SceneManager.LoadScene("1-7");
	}

	public void scene1_8()
	{
        gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
        PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
		SceneManager.LoadScene("1-8");
	}

	public void scene1_9()
	{
        gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
        PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
		SceneManager.LoadScene("1-9");
	}

	public void scene1_10()
	{
        gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
        PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
		SceneManager.LoadScene("1-10");
	}

	public void tutorial()
	{
        gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
        PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
		SceneManager.LoadScene("TutorialScene");
	}

    public void loadScene(string scene) {
        gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(energyTime.GetComponent<EnergyTime>().minutos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(energyTime.GetComponent<EnergyTime>().segundos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setTempoDesdeInicio((int)Time.realtimeSinceStartup);
        PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
        SceneManager.LoadScene(scene);
    }

    public void nextWorld() {
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

    private bool verificarVidas() {
        return true;
        return false;
    }
}
