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

    IEnumerator TocarAnimacaoFinal()
    {
        yield return new WaitForSeconds(0.857f);
        gameManager.SendMessage("victoryGame");
    }

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Robot") {
			if (gameManager) {
                coll.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                GameObject g = Instantiate(Resources.Load("RobotFinal"), transform.position, Quaternion.identity) as GameObject;
                g.transform.parent = this.transform;
                StartCoroutine("TocarAnimacaoFinal");
			}
		}
	}
}
