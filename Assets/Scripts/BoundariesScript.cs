using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoundariesScript : MonoBehaviour {

    private GameObject gameManager;
    private GameObject mainCamera;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        mainCamera = GameObject.Find("Main Camera");
    }

    IEnumerator TocarAnimacaoColisaoLaser()
    {
        yield return new WaitForSeconds(1.1f);
        gameManager.SendMessage("loseGame");
    }

    void OnTriggerEnter2D(Collider2D obj) {
        if (obj.tag == "Robot") {
            if (obj.gameObject.GetComponent<SpriteRenderer>().enabled)
            {
                GameObject g = Instantiate(Resources.Load("RobotColisaoLaser"), obj.transform.position, obj.transform.rotation) as GameObject;
                g.GetComponent<Animator>().SetInteger("Skin", obj.gameObject.GetComponent<RobotSkins>().skinNo);
                GetComponent<AudioSource>().Play();
            }
            mainCamera.GetComponent<CameraValuesScript>().podeMover = false;
            //obj.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(obj.gameObject);

            StartCoroutine("TocarAnimacaoColisaoLaser");
        }
    }
}
