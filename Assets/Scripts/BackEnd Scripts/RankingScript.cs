using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Facebook.Unity;

public class RankingScript : MonoBehaviour {

    [Header("Record Pessoal")]
    public Text worldNameRecord;
    public Text[] stageNameRecord;
    public Text[] record;

    private int mundoAtual;
    
    // Ranking Mundial
    [Header("Ranking Mundial")]
    [Space(10)]
    public Text nomeMundo;
    public Text nomeFase;
    public Text[] mundialRankRecords;
    public Text[] mundialNameRecords;
    public Text[] mundialTimeRecords;
    public Text[] stageNameMundialRecords;
    public Button[] mundialRankButtons;

    private int mundoAtualMundial;

    [Header("Ranking Amigos")]
    [Space(10)]
    public GameObject[] friendGrid;
    public Text nomeFaseFriends;
    public Text nomeMundoAmigos;
    public Button[] friendRankButtons;

    private Sprite teste;

    private int mundoAtualAmigos;

    private string stageSelected;

    private GameObject gameSparksManager;

    public GameObject connectWithFBPanel;
    public GameObject friendsStageSelectPanel;

	// Use this for initialization
	void Start () {
        gameSparksManager = GameObject.Find("GameSparks Manager");

        for (int i = 0; i < 10; i++) {
            record[i].text = RetornaTempoString(GameSparksManager.records[i]);
        }

        mundoAtual = 1;
        mundoAtualMundial = 1;
        mundoAtualAmigos = 1;

        resetMundialScores();

        if (!FB.IsInitialized)
        {
            connectWithFBPanel.SetActive(true);
            friendsStageSelectPanel.SetActive(false);
        } else {
            connectWithFBPanel.SetActive(false);
            friendsStageSelectPanel.SetActive(true);
        }
	}

    void Update() {
        if (FB.IsInitialized)
        {
            connectWithFBPanel.SetActive(false);
            friendsStageSelectPanel.SetActive(true);
        }
    }

    public void ChangeStageSelected(GameObject s) {
        stageSelected = s.GetComponentInChildren<Text>().text;
    }

    public string RetornaTempoString(int t)
    {
        string minutes = Mathf.Floor(t / 100000).ToString("00");
        string seconds = Mathf.Floor((t % 100000) / 1000).ToString("00");
        string fraction = Mathf.Floor(t % 1000).ToString("000");

        return minutes + ":" + seconds + ":" + fraction;
    }

    private void resetMundialScores() {
        for (int i = 0; i < mundialTimeRecords.Length; i++)
        {
            mundialRankRecords[i].text = "< N >";
            mundialNameRecords[i].text = "< Jogador >";
            mundialTimeRecords[i].text = "--:--:---";
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
        resetMundialScores();
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

    private void resetFriendScores()
    {
        for (int i = 0; i < friendGrid.Length; i++)
        {
            friendGrid[i].GetComponent<FriendEntry>().rank.text = "< N >";
            friendGrid[i].GetComponent<FriendEntry>().nameLabel.text = "< Jogador >";
            friendGrid[i].GetComponent<FriendEntry>().time.text = "--:--:---";
            friendGrid[i].GetComponent<FriendEntry>().profilePicture.sprite = null;
        }
    }

    public void GetLeaderboardSocial()
    {
        resetFriendScores();
        nomeFaseFriends.text = "Fase " + stageSelected;

        // m1[0] = String da cena antes do '-' ; m1[1] = String da cena depois do '-' ; 
        string[] m1 = stageSelected.Split('-');

        Debug.Log("Fetching Social Leaderboard Data...");

        int i = 0;

        new GameSparks.Api.Requests.SocialLeaderboardDataRequest()
            .SetLeaderboardShortCode("LEADERBOARD_" + m1[0] + "_" + m1[1])
            .SetEntryCount(GameSparksManager.records[PosicaoVetorRecords(stageSelected)])
            .SetSocial(true)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    Debug.Log("Found Leaderboard Data...");

                    foreach (GameSparks.Api.Responses.LeaderboardDataResponse._LeaderboardData entry in response.Data) // iterate through the leaderboard data
                    {
                        friendGrid[i].GetComponent<FriendEntry>().rank.text = entry.Rank.ToString();
                        friendGrid[i].GetComponent<FriendEntry>().nameLabel.text = entry.UserName;

                        int tempo = int.Parse(entry.JSONData["TIME_" + m1[0] + "_" + m1[1]].ToString());
                        friendGrid[i].GetComponent<FriendEntry>().time.text = RetornaTempoString(tempo);

                        friendGrid[i].GetComponent<FriendEntry>().UpdateFriendImage(entry.ExternalIds.GetString("FB"));

                        i++;
                        if (i >= 10) break;
                    }
                }
                else
                {
                    Debug.Log("Error Retrieving Social Leaderboard Data...");
                }

            });
    }

    public void nextWorldRecord() {
        mundoAtual += 1;
        if (mundoAtual >= 9) mundoAtual = 1;

        renameStageNameRecord();
    }

    public void previousWorldRecord()
    {
        mundoAtual -= 1;
        if (mundoAtual < 1) mundoAtual = 8;        

        renameStageNameRecord();
    }

    private void renameStageNameRecord() {
        worldNameRecord.text = "Mundo " + mundoAtual;

        for (int i = 1; i <= 10; i++)
        {
            stageNameRecord[i - 1].text = "Fase " + mundoAtual + "-" + i;
        }

        // Pegar os records em GameSparksManager.records[]
        int j = int.Parse((mundoAtual - 1).ToString() + "0");
        for (int i = 0; i < record.Length; i++) {
            record[i].text = RetornaTempoString(GameSparksManager.records[j]);
            j++;
        }
    }

    // Ranking Mundial
    public void nextWorldRanking()
    {
        mundoAtualMundial += 1;
        if (mundoAtualMundial >= 9) mundoAtualMundial = 1;

        renameStageNameRanking();
    }

    public void previousWorldRanking()
    {
        mundoAtualMundial -= 1;
        if (mundoAtualMundial < 1) mundoAtualMundial = 8;

        renameStageNameRanking();
    }

    private void renameStageNameRanking()
    {
        nomeMundo.text = "Mundo " + mundoAtualMundial;

        for (int i = 1; i <= 10; i++)
        {
            mundialRankButtons[i - 1].GetComponentInChildren<Text>().text = mundoAtualMundial + "-" + i;
        }
    }

    // Ranking Amigos
    public void nextWorldFriends()
    {
        mundoAtualAmigos += 1;
        if (mundoAtualAmigos >= 9) mundoAtualAmigos = 1;

        renameStageNameFriends();
    }

    public void previousWorldFriends()
    {
        mundoAtualAmigos -= 1;
        if (mundoAtualAmigos < 1) mundoAtualAmigos = 8;

        renameStageNameFriends();
    }

    private void renameStageNameFriends()
    {
        nomeMundoAmigos.text = "Mundo " + mundoAtualAmigos;

        for (int i = 1; i <= 10; i++)
        {
            friendRankButtons[i - 1].GetComponentInChildren<Text>().text = mundoAtualAmigos + "-" + i;
        }
    }

    // Chama o GSManager para se conectar ao FB;
    public void ConnectWithFacebook()
    {
        gameSparksManager.GetComponent<GameSparksManager>().ConnectWithFacebook();
    }
}
