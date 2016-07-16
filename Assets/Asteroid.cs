using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

    private GameObject gameManager;
    private GameObject mainCamera;

    void Awake() {
        gameManager = GameObject.Find("GameManager");
        mainCamera = GameObject.Find("Main Camera");
    }

    IEnumerator TocarAnimacaoColisaoAsteroide()
    {
        yield return new WaitForSeconds(0.65f);
        gameManager.SendMessage("loseGame");
    }

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Robot") {
            //Debug.Log("ColisaoRobo");
            
            if (coll.gameObject.GetComponent<SpriteRenderer>().enabled)
            {
                GameObject g = Instantiate(Resources.Load("RobotColisaoAsteroide"), coll.transform.position, coll.transform.rotation) as GameObject;
                GetComponent<AudioSource>().Play();
            }
            mainCamera.GetComponent<CameraValuesScript>().podeMover = false;
            coll.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            //Destroy(coll.gameObject);

            StartCoroutine("TocarAnimacaoColisaoAsteroide");
		}
	}
}
