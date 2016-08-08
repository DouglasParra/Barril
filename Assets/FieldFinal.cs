using UnityEngine;
using System.Collections;

public class FieldFinal : MonoBehaviour {

    private GameObject gameManager;
    private GameObject shootButton;


	// Use this for initialization
	void Awake () {
        gameManager = GameObject.Find("GameManager");
        shootButton = GameObject.Find("ShootButton");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator TocarAnimacaoFinal(GameObject g)
    {
        yield return new WaitForSeconds(0.857f);
        GameObject.Destroy(g);
        gameManager.SendMessage("victoryGame");
    }

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Robot") {
			if (gameManager) {
                shootButton.SetActive(false);
                coll.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                GameObject g = Instantiate(Resources.Load("RobotFinal"), transform.position, Quaternion.identity) as GameObject;
                g.GetComponent<Animator>().SetInteger("Skin", coll.gameObject.GetComponent<RobotSkins>().skinNo);
                g.transform.parent = this.transform;
                GetComponent<AudioSource>().Play();
                StartCoroutine("TocarAnimacaoFinal", g);
			}
		}
	}
}
