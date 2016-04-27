using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Facebook.Unity;

public class StageSelectScript : MonoBehaviour {

    public Text playerName;

    public GameObject[] mundos;

    private int QTDE_MUNDO = 8;
    private int mundoAtual;

	// Use this for initialization
	void Start () {
        playerName.text = PlayerPrefs.GetString("DisplayName");
        mundoAtual = 0;
	}

    // Update is called once per frame
	void Update () {
	
	}

    public void StageSelect() {
        SceneManager.LoadScene(0);
    }

    public void StageSelect_Fases()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void RankScene()
    {
        SceneManager.LoadScene("RankScene");
    }

    public void scene1_1()
    {
        SceneManager.LoadScene("1-1");
    }

	public void scene1_2()
	{
		SceneManager.LoadScene("1-2");
	}

	public void scene1_3()
	{
		SceneManager.LoadScene("1-3");
	}

	public void scene1_4()
	{
		SceneManager.LoadScene("1-4");
	}

	public void scene1_5()
	{
		SceneManager.LoadScene("1-5");
	}

	public void scene1_6()
	{
		SceneManager.LoadScene("1-6");
	}

	public void scene1_7()
	{
		SceneManager.LoadScene("1-7");
	}

	public void scene1_8()
	{
		SceneManager.LoadScene("1-8");
	}

	public void scene1_9()
	{
		SceneManager.LoadScene("1-9");
	}

	public void scene1_10()
	{
		SceneManager.LoadScene("1-10");
	}

	public void tutorial()
	{
		SceneManager.LoadScene("TutorialScene");
	}

    public void loadScene(string scene) {
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
}
