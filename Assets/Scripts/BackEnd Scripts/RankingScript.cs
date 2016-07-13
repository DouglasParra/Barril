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
    public Text[] stageNameMundialRecords;
    public Button[] mundialRankButtons;
    public GameObject rankingEntry;
    public GameObject globalViewport;

    private int mundoAtualMundial;

    [Header("Ranking Amigos")]
    [Space(10)]
    public GameObject friendRankingEntry;
    public GameObject friendViewport;
    public Text nomeFaseFriends;
    public Text nomeMundoAmigos;
    public Button[] friendRankButtons;

    private Sprite teste;

    private int mundoAtualAmigos;

    private string stageSelected;

    private GameObject gameSparksManager;

    public GameObject connectWithFBPanel;
    public GameObject friendsStageSelectPanel;

    private const int passo = -80;
    private bool redo;

	// Use this for initialization
	void Start () {
        gameSparksManager = GameObject.Find("GameSparks Manager");

        for (int i = 0; i < 10; i++) {
            record[i].text = RetornaTempoString(GameSparksManager.records[i]);
        }

        mundoAtual = 1;
        mundoAtualMundial = 1;
        mundoAtualAmigos = 1;

        redo = false;
        //resetMundialScores();

        if (PlayerPrefs.HasKey("FB") && PlayerPrefs.GetInt("FB") == 1)
        {
            ConnectWithFacebook();
        }

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
        //Debug.Log(globalViewport.transform.childCount);
        for (int i = 0; i < globalViewport.transform.childCount; i++)
        {
            GameObject.Destroy(globalViewport.transform.GetChild(i).gameObject);
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
        if (redo == false)
        {
            redo = true;
        }
        resetMundialScores();
        nomeFase.text = "Stage " + stageSelected;

        // m1[0] = String da cena antes do '-' ; m1[1] = String da cena depois do '-' ; 
        string[] m1 = stageSelected.Split('-');

        Debug.Log("Fetching Leaderboard Data..." + stageSelected);

        int i = 0;

        new GameSparks.Api.Requests.LeaderboardDataRequest()
            .SetLeaderboardShortCode("LEADERBOARD_" + m1[0] + "_" + m1[1])
            .SetEntryCount(GameSparksManager.records[PosicaoVetorRecords(stageSelected)]) // we need to parse this text input, since the entry count only takes long
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Found Leaderboard Data...");

                    foreach (GameSparks.Api.Responses.LeaderboardDataResponse._LeaderboardData entry in response.Data) // iterate through the leaderboard data
                    {
                        GameObject g = Instantiate(rankingEntry, Vector3.zero, Quaternion.identity) as GameObject;

                        g.transform.GetChild(0).GetComponent<Text>().text = entry.Rank.ToString();
                        g.transform.GetChild(1).GetComponent<Text>().text = entry.UserName;
                        int tempo = int.Parse(entry.JSONData["TIME_" + m1[0] + "_" + m1[1]].ToString());
                        g.transform.GetChild(2).GetComponent<Text>().text = RetornaTempoString(tempo);

                        g.transform.SetParent(globalViewport.transform);
                        g.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
                        g.GetComponent<RectTransform>().offsetMax = new Vector2(900, 70);
                        g.GetComponent<RectTransform>().localPosition = new Vector2(510, i * passo - 40);

                        i++;
                    }

                    globalViewport.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
                    globalViewport.GetComponent<RectTransform>().offsetMin = new Vector2(0, (i-1) * passo);

                    Refazer();
                }
                else
                {
                    //Debug.Log("Error Retrieving Leaderboard Data...");
                }

            });
    }

    private void Refazer()
    {
        if (redo)
        {
            GetLeaderboard();
            redo = false;
        }
    }

    private void resetFriendScores()
    {
        for (int i = 0; i < friendViewport.transform.childCount; i++)
        {
            GameObject.Destroy(friendViewport.transform.GetChild(i).gameObject);
        }
    }

    public void GetLeaderboardSocial()
    {
        if (redo == false)
        {
            redo = true;
        }

        resetFriendScores();
        nomeFaseFriends.text = "Stage " + stageSelected;

        // m1[0] = String da cena antes do '-' ; m1[1] = String da cena depois do '-' ; 
        string[] m1 = stageSelected.Split('-');

        //Debug.Log("Fetching Social Leaderboard Data...");

        int i = 0;

        new GameSparks.Api.Requests.SocialLeaderboardDataRequest()
            .SetLeaderboardShortCode("LEADERBOARD_" + m1[0] + "_" + m1[1])
            .SetEntryCount(GameSparksManager.records[PosicaoVetorRecords(stageSelected)])
            .SetSocial(true)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Found Leaderboard Data...");

                    foreach (GameSparks.Api.Responses.LeaderboardDataResponse._LeaderboardData entry in response.Data) // iterate through the leaderboard data
                    {
                        GameObject g = Instantiate(friendRankingEntry, Vector3.zero, Quaternion.identity) as GameObject;

                        g.transform.GetChild(0).GetComponent<Text>().text = entry.Rank.ToString();
                        g.transform.GetChild(1).GetComponent<Text>().text = entry.UserName;
                        int tempo = int.Parse(entry.JSONData["TIME_" + m1[0] + "_" + m1[1]].ToString());
                        g.transform.GetChild(2).GetComponent<Text>().text = RetornaTempoString(tempo);
                        g.GetComponent<FriendEntry>().UpdateFriendImage(entry.ExternalIds.GetString("FB"));
                        //friendGrid[i].GetComponent<FriendEntry>().UpdateFriendImage(entry.ExternalIds.GetString("FB"));

                        g.transform.SetParent(friendViewport.transform);
                        g.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
                        g.GetComponent<RectTransform>().offsetMax = new Vector2(900, 70);
                        g.GetComponent<RectTransform>().localPosition = new Vector2(510, i * passo - 40);

                        i++;

                        //if (i >= 10) break;
                    }

                    friendViewport.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
                    friendViewport.GetComponent<RectTransform>().offsetMin = new Vector2(0, (i - 1) * passo);

                    RefazerAmigos();
                }
                else
                {
                    //Debug.Log("Error Retrieving Social Leaderboard Data...");
                }

            });
    }

    private void RefazerAmigos()
    {
        if (redo)
        {
            GetLeaderboardSocial();
            redo = false;
        }
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
        worldNameRecord.text = "World " + mundoAtual;

        for (int i = 1; i <= 10; i++)
        {
            stageNameRecord[i - 1].text = "Stage " + mundoAtual + "-" + i;
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
        nomeMundo.text = "World " + mundoAtualMundial;

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
        nomeMundoAmigos.text = "World " + mundoAtualAmigos;

        for (int i = 1; i <= 10; i++)
        {
            friendRankButtons[i - 1].GetComponentInChildren<Text>().text = mundoAtualAmigos + "-" + i;
        }
    }

    // Chama o GSManager para se conectar ao FB;
    public void ConnectWithFacebook()
    {
        gameSparksManager.GetComponent<GameSparksManager>().ConnectWithFacebook();
        if (FB.IsInitialized)
        {
            connectWithFBPanel.SetActive(false);
            friendsStageSelectPanel.SetActive(true);

            if (!PlayerPrefs.HasKey("FB"))
            {
                PlayerPrefs.SetInt("FB", 1);
            }
        }
    }

    public void StageSelectScene() {
        SceneManager.LoadScene("StageSelect");
    }
}
