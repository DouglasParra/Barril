using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class RankingScript : MonoBehaviour {

    public Text[] record;

    public Text nomeFase;
    public Text[] mundialRankRecords;
    public Text[] mundialNameRecords;
    public Text[] mundialTimeRecords;

    public Text[] stageNameMundialRecords;

    private string stageSelected;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < record.Length; i++) {
            record[i].text = RetornaTempoString(GameSparksManager.records[i]);
        }

        resetMundialScores();
	}

    public void ChangeStageSelected(string s) {
        stageSelected = s;
    }

    public string RetornaTempoString(int t)
    {
        string minutes = Mathf.Floor(t / 10000).ToString("00");
        string seconds = Mathf.Floor((t % 10000) / 100).ToString("00");
        string fraction = Mathf.Floor(t % 100).ToString("00");

        return minutes + ":" + seconds + ":" + fraction;
    }

    private void resetMundialScores() {
        for (int i = 0; i < mundialTimeRecords.Length; i++)
        {
            mundialTimeRecords[i].text = "--:--:--";
        }
    }

    // Dado o nome da fase no formato "X-Y", retorna a posição no vetor GameSparksManager.records[]
    private int PosicaoVetorRecords(string mundo)
    {
        string[] m1 = mundo.Split('-');

        int m2 = int.Parse(m1[0]) - 1;
        int m3 = int.Parse(m1[1]) - 1;

        return int.Parse((m2.ToString() + m3.ToString()));
    }

    public void GetLeaderboard()
    {
        nomeFase.text = "Fase " + stageSelected;

        // m1[0] = String da cena antes do '-' ; m1[1] = String da cena depois do '-' ; 
        string[] m1 = stageSelected.Split('-');

        Debug.Log("Fetching Leaderboard Data...");

        int i = 0;

        new GameSparks.Api.Requests.LeaderboardDataRequest()
            .SetLeaderboardShortCode("LEADERBOARD_" + m1[0] + "_" + m1[1])
            .SetEntryCount(GameSparksManager.records[PosicaoVetorRecords(stageSelected)]) // we need to parse this text input, since the entry count only takes long
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    Debug.Log("Found Leaderboard Data...");

                    foreach (GameSparks.Api.Responses.LeaderboardDataResponse._LeaderboardData entry in response.Data) // iterate through the leaderboard data
                    {
                        mundialRankRecords[i].text = entry.Rank.ToString(); // we can get the rank directly
                        mundialNameRecords[i].text = entry.UserName;
                        int tempo = int.Parse(entry.JSONData["TIME_" + m1[0] + "_" + m1[1]].ToString());
                        mundialTimeRecords[i].text = RetornaTempoString(tempo); // we need to get the key, in order to get the score

                        i++;

                    }
                }
                else
                {
                    Debug.Log("Error Retrieving Leaderboard Data...");
                }

            });
    }
}
