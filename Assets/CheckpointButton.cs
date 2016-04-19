using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckpointButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		verifyCheckpoint ();
	}

	void verifyCheckpoint () {
		if (PlayerPrefs.HasKey ("startInCheckpoint")
		    && PlayerPrefs.GetInt ("startInCheckpoint") == 1) {
			GetComponent<Button>().interactable = true;

		}
	}

}
