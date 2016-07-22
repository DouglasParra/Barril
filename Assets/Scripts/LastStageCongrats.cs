using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LastStageCongrats : MonoBehaviour {

    public GameObject creditsButton;

	// Use this for initialization
	void Start () {
        StartCoroutine("HabilitarBotao");
	}

    IEnumerator HabilitarBotao()
    {
        yield return new WaitForSeconds(3f);
        creditsButton.SetActive(true);
    }

    public void GoToCredits()
    {
        PlayerPrefs.SetInt("Credits", 1);
        SceneManager.LoadScene("StageSelect");
    }
}
