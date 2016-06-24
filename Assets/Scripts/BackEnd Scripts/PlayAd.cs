using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class PlayAd : MonoBehaviour {

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
                Debug.Log("Player gains 1 life");
                break;
            case ShowResult.Skipped:
                Debug.Log("Player didn't fully watch the ad");
                break;
            case ShowResult.Failed:
                Debug.Log("Player failed to launch the ad. Internet error?");
                break;
        }
    }
}
