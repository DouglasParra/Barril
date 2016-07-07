using UnityEngine;
using System.Collections;

public class ModoOffline : MonoBehaviour {

    // private float tempoParaTeste;
    
    // Uma vez a cada 10 segundos, faz teste de conexão
    // private const int DELAY_TESTE = 10;

    private bool modoOffline;
    private bool testandoConexao;

    IEnumerator checkInternetConnection()
    {
        testandoConexao = true;

        WWW www = new WWW("http://google.com");
        yield return www;
        if (www.error != null)
        {
            //Debug.Log("Sem conexao");
            testandoConexao = false;
            modoOffline = true;
        }
        else
        {
            //Debug.Log("Conectado");
            testandoConexao = false;
            modoOffline = false;
        }
    }

    public void TestarConexao()
    {
        modoOffline = false;
        StartCoroutine("checkInternetConnection");
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

    public bool getModoOffline() {
        return modoOffline;
    }

    public bool getTestandoConexao()
    {
        return testandoConexao;
    }
}
