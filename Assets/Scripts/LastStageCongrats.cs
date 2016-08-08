using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LastStageCongrats : MonoBehaviour {

    public GameObject creditsButton;

    IEnumerator HabilitarBotao()
    {
        Debug.Log("Esperando 3s");
        yield return new WaitForSeconds(3);
        creditsButton.SetActive(true);
    }

    public void GoToCredits()
    {
        PlayerPrefs.SetInt("Credits", 1);
        SceneManager.LoadScene("StageSelect");
    }

    public void Esperar3Segundos()
    {
        StartCoroutine(HabilitarBotao());
    }
}
