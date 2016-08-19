using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ModoOffline : MonoBehaviour {

    // private float tempoParaTeste;
    
    // Uma vez a cada 10 segundos, faz teste de conexão
    // private const int DELAY_TESTE = 10;

    [SerializeField]
    private bool testandoConexao;
    [SerializeField]
    private bool modoOffline;

    private int testeNo;

    public InputField debugText;

    IEnumerator checkInternetConnection()
    {
        testandoConexao = true;

        //if (SceneManager.GetActiveScene().name.Equals("TitleScene"))
          //  debugText.text += "\nTestando conexão";

        //Debug.Log("Testando conexão");

        WWW www = new WWW("https://facebook.com");
        yield return www;

        if (www.error != null)
        {
            if (testeNo > 5)
            {
                //Debug.Log("Sem conexao");
                //if (SceneManager.GetActiveScene().name.Equals("TitleScene"))
                  //  debugText.text += "\nSem conexao definitiva" + testeNo;

                modoOffline = true;
                testandoConexao = false;
            }
            else
            {
                //if (SceneManager.GetActiveScene().name.Equals("TitleScene"))
                  //  debugText.text += "\nSem conexao. Teste: " + testeNo;

                testeNo++;
                yield return new WaitForSeconds(0.5f);
                StartCoroutine(checkInternetConnection());
            }
        }
        else
        {
            //Debug.Log("Conectado");
            modoOffline = false;
            testandoConexao = false;
        }

        //Debug.Log("Acabou teste");
    }

    void Awake() {
        //tempoParaTeste = Time.time;    
    }

    void Update()
    {
        /*if (Time.time >= tempoParaTeste)
        {
            tempoParaTeste = Time.time + DELAY_TESTE;
            StartCoroutine("checkInternetConnection");
        }*/
    }

    public void TestarConexao()
    {
        modoOffline = false;
        testeNo = 1;
        //Debug.Log("Chamando checkInternetConnection");
        //if (SceneManager.GetActiveScene().name.Equals("TitleScene"))
          //  debugText.text += "\nChamando checkInternetConnection";

        StartCoroutine("checkInternetConnection");
    }

    public bool getModoOffline() {
        return modoOffline;
    }

    public bool getTestandoConexao()
    {
        return testandoConexao;
    }
}
