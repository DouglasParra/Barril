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
            Instantiate(Resources.Load("LetrasCheckpoint"), transform.position, Quaternion.identity);
        }
	}
}
