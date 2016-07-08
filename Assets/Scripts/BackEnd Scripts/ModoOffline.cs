using UnityEngine;
using System.Collections;

public class ModoOffline : MonoBehaviour {

    // private float tempoParaTeste;
    
    // Uma vez a cada 10 segundos, faz teste de conexão
    // private const int DELAY_TESTE = 10;

    [SerializeField]
    private bool testandoConexao;
    [SerializeField]
    private bool modoOffline;

    IEnumerator checkInternetConnection()
    {
        testandoConexao = true;
        Debug.Log("Testando conexão");

        WWW www = new WWW("http://google.com");
        yield return www;
        if (www.error != null)
        {
            Debug.Log("Sem conexao");
            modoOffline = true;
            testandoConexao = false;
        }
        else
        {
            Debug.Log("Conectado");
            modoOffline = false;
            testandoConexao = false;
        }

        Debug.Log("Acabou teste");
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
        Debug.Log("Chamando checkInternetConnection");
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
