using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FieldCounter : MonoBehaviour {

	[Tooltip("Tempo em segundos para ativar a derrota. Valor Float")]
	public float counterTime = 5.0f;

	public Text textCounter;

	private bool canRunTime = false;

	private float currentTime = 0.0f;

	private bool robotInField = false;

	void Awake () {
		textCounter.text = counterTime.ToString("0");
	}

	void Update () {
		if (canRunTime) {
			updateTimes ();
			updateTextComponent ();
			verifyLoseGame ();
		}
	}

	void updateTimes () {
		currentTime += Time.deltaTime;
	}

	void updateTextComponent () {
		string seconds = Mathf.Floor((counterTime - currentTime) % 60).ToString("0");
		textCounter.text = seconds;
		textCounter.color = Color.Lerp(Color.green, Color.red, 	currentTime/counterTime);
	}

	void verifyLoseGame () {
		if (currentTime > counterTime && robotInField) {
			canRunTime = false;
			GameObject.Find ("GameManager").SendMessage ("loseGame");
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Robot") {
			canRunTime = true;
			robotInField = true;
		}
	}

	void OnTriggerExit2D(Collider2D coll) {
		canRunTime = false;
		robotInField = false;
	}
}
