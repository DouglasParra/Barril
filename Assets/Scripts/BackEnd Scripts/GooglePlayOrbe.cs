using UnityEngine;
using System.Collections;
using GooglePlayGames;

public class GooglePlayOrbe : MonoBehaviour {

    private string achievementClearWorld1 = "CgkIlq3pg48YEAIQAA";
    private string achievementClearWorld2 = "CgkIlq3pg48YEAIQAQ";
    private string achievementClearWorld3 = "CgkIlq3pg48YEAIQAg";
    private string achievementClearWorld4 = "CgkIlq3pg48YEAIQAw";
    private string achievementClearWorld5 = "CgkIlq3pg48YEAIQBA";
    private string achievementClearWorld6 = "CgkIlq3pg48YEAIQBQ";
    private string achievementClearWorld7 = "CgkIlq3pg48YEAIQBg";
    private string achievementClearWorld8 = "CgkIlq3pg48YEAIQBw";

    private string achievementStage1_1Time = "CgkIlq3pg48YEAIQCA";
    private string achievementStage2_9Time = "CgkIlq3pg48YEAIQCQ";
    private string achievementStage3_5Time = "CgkIlq3pg48YEAIQCg";
    private string achievementStage4_3Time = "CgkIlq3pg48YEAIQCw";
    private string achievementStage5_4Time = "CgkIlq3pg48YEAIQDA";
    private string achievementStage6_7Time = "CgkIlq3pg48YEAIQDQ";
    private string achievementStage7_9Time = "CgkIlq3pg48YEAIQDg";
    private string achievementStage8_10Time = "CgkIlq3pg48YEAIQDw";

    void Awake()
    {
        //PlayGamesPlatform.Activate();
        //GooglePlayLogin();
    }

	public void GooglePlayOrbeActivate(){
        // recommended for debugging:
        //PlayGamesPlatform.DebugLogEnabled = true;
        // Activate the Google Play Games platform
        //PlayGamesPlatform.Activate();

        GooglePlayLogin();
    }

    private void GooglePlayLogin()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            // handle success or failure
            if (success == true)
            {
                Debug.Log("Logado google play");
            }
            else
            {
                Debug.Log("Google play login error");
            }
        });

    }

    public void ShowAchievementsGooglePlay()
    {
        Social.ShowAchievementsUI();
    }

    public void UnlockAchievementClearWorld1()
    {
        Social.ReportProgress(achievementClearWorld1, 100.0f, (bool success) =>
        {
            // Achievement unlocked
        });
    }

    public void UnlockAchievementClearWorld2()
    {
        Social.ReportProgress(achievementClearWorld2, 100.0f, (bool success) =>
        {
            // Achievement unlocked
        });
    }

    public void UnlockAchievementClearWorld3()
    {
        Social.ReportProgress(achievementClearWorld3, 100.0f, (bool success) =>
        {
            // Achievement unlocked
        });
    }

    public void UnlockAchievementClearWorld4()
    {
        Social.ReportProgress(achievementClearWorld4, 100.0f, (bool success) =>
        {
            // Achievement unlocked
        });
    }

    public void UnlockAchievementClearWorld5()
    {
        Social.ReportProgress(achievementClearWorld5, 100.0f, (bool success) =>
        {
            // Achievement unlocked
        });
    }

    public void UnlockAchievementClearWorld6()
    {
        Social.ReportProgress(achievementClearWorld6, 100.0f, (bool success) =>
        {
            // Achievement unlocked
        });
    }

    public void UnlockAchievementClearWorld7()
    {
        Social.ReportProgress(achievementClearWorld7, 100.0f, (bool success) =>
        {
            // Achievement unlocked
        });
    }

    public void UnlockAchievementClearWorld8()
    {
        Social.ReportProgress(achievementClearWorld8, 100.0f, (bool success) =>
        {
            // Achievement unlocked
        });
    }

    public void UnlockAchievementStage1_1Time()
    {
        Social.ReportProgress(achievementStage1_1Time, 100.0f, (bool success) =>
        {
            // Achievement unlocked
        });
    }

    public void UnlockAchievementStage2_9Time()
    {
        Social.ReportProgress(achievementStage2_9Time, 100.0f, (bool success) =>
        {
            // Achievement unlocked
        });
    }

    public void UnlockAchievementStage3_5Time()
    {
        Social.ReportProgress(achievementStage3_5Time, 100.0f, (bool success) =>
        {
            // Achievement unlocked
        });
    }

    public void UnlockAchievementStage4_3Time()
    {
        Social.ReportProgress(achievementStage4_3Time, 100.0f, (bool success) =>
        {
            // Achievement unlocked
        });
    }

    public void UnlockAchievementStage5_4Time()
    {
        Social.ReportProgress(achievementStage5_4Time, 100.0f, (bool success) =>
        {
            // Achievement unlocked
        });
    }

    public void UnlockAchievementStage6_7Time()
    {
        Social.ReportProgress(achievementStage6_7Time, 100.0f, (bool success) =>
        {
            // Achievement unlocked
        });
    }

    public void UnlockAchievementStage7_9Time()
    {
        Social.ReportProgress(achievementStage7_9Time, 100.0f, (bool success) =>
        {
            // Achievement unlocked
        });
    }

    public void UnlockAchievementStage8_10Time()
    {
        Social.ReportProgress(achievementStage8_10Time, 100.0f, (bool success) =>
        {
            // Achievement unlocked
        });
    }
}