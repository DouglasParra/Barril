using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FieldFinal : MonoBehaviour {

    private GameObject gameManager;
    private GameObject shootButton;
    [SerializeField]
    private GameObject miniMapButton;

	// Use this for initialization
	void Awake () {
        gameManager = GameObject.Find("GameManager");
        shootButton = GameObject.Find("ShootButton");
        miniMapButton = gameManager.transform.parent.GetChild(4).gameObject;
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
                miniMapButton.GetComponent<Button>().interactable = false;

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
