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
        yield return new WaitForSeconds(0.9f);
        gameManager.SendMessage("loseGame");
    }

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Robot") {
            //Debug.Log("ColisaoRobo");
            
            if (coll.gameObject.GetComponent<SpriteRenderer>().enabled)
            {
                GameObject g = Instantiate(Resources.Load("RobotColisaoAsteroide"), coll.transform.position, coll.transform.rotation) as GameObject;
                //SetColisaoAsteroidAnimation(g);
                g.GetComponent<Animator>().SetInteger("Skin", coll.gameObject.GetComponent<RobotSkins>().skinNo);
                GetComponent<AudioSource>().Play();
            }
            mainCamera.GetComponent<CameraValuesScript>().podeMover = false;
            //coll.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(coll.gameObject);

            StartCoroutine("TocarAnimacaoColisaoAsteroide");
		}
	}

    private void SetColisaoAsteroidAnimation(GameObject g) {
        if (PlayerPrefs.GetInt("Skin1") == 1)
        {
            g.GetComponent<Animator>().SetInteger("Skin", 1);
        }
        else if (PlayerPrefs.GetInt("Skin2") == 1)
        {
            g.GetComponent<Animator>().SetInteger("Skin", 2);
        }
        else if (PlayerPrefs.GetInt("Skin3") == 1)
        {
            g.GetComponent<Animator>().SetInteger("Skin", 3);
        }
        else if (PlayerPrefs.GetInt("Skin4") == 1)
        {
            g.GetComponent<Animator>().SetInteger("Skin", 4);
        }
        else if (PlayerPrefs.GetInt("Skin5") == 1)
        {
            g.GetComponent<Animator>().SetInteger("Skin", 5);
        }
        else if (PlayerPrefs.GetInt("Skin6") == 1)
        {
            g.GetComponent<Animator>().SetInteger("Skin", 6);
        }
        else if (PlayerPrefs.GetInt("Skin7") == 1)
        {
            g.GetComponent<Animator>().SetInteger("Skin", 7);
        }
        else if (PlayerPrefs.GetInt("Skin8") == 1)
        {
            g.GetComponent<Animator>().SetInteger("Skin", 8);
        }
        else if (PlayerPrefs.GetInt("Skin9") == 1)
        {
            g.GetComponent<Animator>().SetInteger("Skin", 9);
        }
        else if (PlayerPrefs.GetInt("Skin10") == 1)
        {
            g.GetComponent<Animator>().SetInteger("Skin", 10);
        }
        else if (PlayerPrefs.GetInt("Skin11") == 1)
        {
            g.GetComponent<Animator>().SetInteger("Skin", 11);
        }
        else if (PlayerPrefs.GetInt("Skin12") == 1)
        {
            g.GetComponent<Animator>().SetInteger("Skin", 12);
        }
        else if (PlayerPrefs.GetInt("Skin13") == 1)
        {
            g.GetComponent<Animator>().SetInteger("Skin", 13);
        }
        else
        {
            g.GetComponent<Animator>().SetInteger("Skin", 0);
        }
    }
}
