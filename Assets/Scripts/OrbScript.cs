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
