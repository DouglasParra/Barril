using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class PlayAd : MonoBehaviour {

    private GameObject gameSparksManager;

    void Awake() {
        gameSparksManager = GameObject.Find("GameSparks Manager");
    }

    public void ShowAd() {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResult });
        }
    }

    private void HandleAdResult(ShowResult result) {
        switch (result)
        {
            case ShowResult.Finished:
                gameSparksManager.GetComponent<EnergyTimeValues>().GanharVida();
                PlayerPrefs.SetInt("ADLifes", PlayerPrefs.GetInt("ADLifes") - 1);
                //Debug.Log(PlayerPrefs.GetInt("ADLifes"));
                //Debug.Log("Player gains 1 life");
                break;
            case ShowResult.Skipped:
                //Debug.Log("Player didn't fully watch the ad");
                break;
            case ShowResult.Failed:
                //Debug.Log("Player failed to launch the ad. Internet error?");
                break;
        }
    }
}
