using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject endGameModal;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void endGame () {
		if (endGameModal) {
			endGameModal.SetActive (true);
		}
	}
}
