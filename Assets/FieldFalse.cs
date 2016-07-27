using UnityEngine;
using System.Collections;

public class FieldFalse : MonoBehaviour {

    private GameObject gameManager;
    private GameObject shootButton;

    void Awake() {
        gameManager = GameObject.Find("GameManager");
        shootButton = GameObject.Find("ShootButton");
    }

    IEnumerator TocarAnimacaoFalso()
    {
        yield return new WaitForSeconds(2f);
        gameManager.SendMessage("loseGame");
        GetComponent<Animator>().SetBool("Destruindo", true);
    }

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Robot") {
            shootButton.SetActive(false);
            GetComponent<AudioSource>().Play();
            coll.gameObject.GetComponent<Animator>().enabled = true;
            StartCoroutine("TocarAnimacaoFalso");
		}
	}
}
