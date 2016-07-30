using UnityEngine;
using System.Collections;

public class FieldCheckpoint : MonoBehaviour {

	[Tooltip("Ordem do checkpoint, se esse for o primeiro, sete como 0")]
	public int order;

    private GameObject gameManager;

    void Awake() {
        gameManager = GameObject.Find("GameManager");
    }

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Robot") {
			gameManager.SendMessage ("checkpoint", order);
            GetComponent<AudioSource>().Play();
            Instantiate(Resources.Load("LetrasCheckpoint"), transform.position, Quaternion.identity);

            // Salva quais portas não estão ativas 
            for (int i = 0; i < gameManager.GetComponent<GameManager>().portas.Length; i++) {
                if (gameManager.GetComponent<GameManager>().portas[i].GetComponent<Animator>().GetBool("Aberta")) {
                    //Debug.Log("Salvou porta " + gameManager.GetComponent<GameManager>().portas[i].name);
                    PlayerPrefs.SetInt("Porta" + gameManager.GetComponent<GameManager>().portas[i].name, 0);
                }
            }
        }
	}
}
