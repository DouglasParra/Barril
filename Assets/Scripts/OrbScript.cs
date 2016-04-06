using UnityEngine;
using System.Collections;

public class OrbScript : MonoBehaviour {

//    public Camera camera;

    void Awake()
    {
        // Muda velocidade das animações
//        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        if (transform.parent == null)
        {
//            camera.transform.position = new Vector3(Mathf.Lerp(camera.transform.position.x, Mathf.Clamp(transform.position.x, camera.GetComponent<CameraValuesScript>().getXMin(), camera.GetComponent<CameraValuesScript>().getXMax()), .25f),
//                                                    Mathf.Lerp(camera.transform.position.y, Mathf.Clamp(transform.position.y, camera.GetComponent<CameraValuesScript>().getYMin(), camera.GetComponent<CameraValuesScript>().getYMax()), .25f),
//                                                    -10);
        }
    }

    // Função para verificar colisão da bola
    void OnTriggerEnter2D(Collider2D obj)
    {
        // Se ela tocou em um Barril
        if (obj.tag == "Barril") {
            GetComponent<Rigidbody2D>().gravityScale = 0;

            // A bola torna-se filho do barril em questão
            transform.parent = obj.transform.GetChild(0);
            obj.GetComponent<BarrilScript>().prefab = transform.gameObject;

            // É posicionado na origem do OrbPlace
            transform.position = obj.transform.GetChild(0).transform.position;

            // Zera a velocidade da bola
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0,0);

            // Torna-se apta a atirar novamente
            BarrilScript.atirar = false;

            if (obj.GetComponent<BarrilScript>().onEnterMove)
            {
                obj.GetComponent<BarrilScript>().canMove = true;
            }
        }
		if (obj.tag == "Barril_Final") {
			victoryTutorial ();
		}
    }

	public void victoryTutorial () {
		PlayerPrefs.SetInt ("tutorialDone", 1);
	}
}
