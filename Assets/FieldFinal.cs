using UnityEngine;
using System.Collections;

public class FieldFinal : MonoBehaviour {

    private GameObject gameManager;

	// Use this for initialization
	void Awake () {
        gameManager = GameObject.Find("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Robot") {
			if (gameManager) {
				gameManager.SendMessage ("victoryGame");
			}
		}
	}
}
