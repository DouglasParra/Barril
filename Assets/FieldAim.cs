using UnityEngine;
using System.Collections;

public class FieldAim : MonoBehaviour {

	public float[] angles;

	public float TURN_TIME = 1.0f;

	private int nextAngle = 0;



	// Use this for initialization
	void Start () {
		StartCoroutine ("rotateRoutine");
	}

//	void FixedUpdate () {

		//transform.Rotate(Vector3.forward, Time.deltaTime * 180, Space.Self);
//	}

	// 1) Sete a rotacao inicial
	// 2) Sete a quantidade de rotações, se quer apontar pra 2 lugares, sete o vetor como 2, se quer 3, sete como 3.
	// 3) Rotacao positiva = sentindo anti-horario / Rotacao negativa = sentido horario
	// Exemplo
	// Digamos que queria apontar pro direita e pra baixo. Iniciando da direita.
	// 1) Sete a rotacao Z para 270
	// 2) Sete o primeiro angulo de rotacao para (-)90 (Baixo esta 90 grau em sentindo horario da posicao a direita) OU (+)270 
	// 3) Sete o segundo angulo querendo voltar a posicao direita, logo pode ser (+)90 graus OU (-)270 graus
	IEnumerator rotateRoutine()
	{
		while (true) {
			this.transform.Rotate (0.0f, 0.0f, angles [nextAngle]);
			nextAngle++;
			if (nextAngle > angles.Length - 1) {
				nextAngle = 0;
			}
			yield return new WaitForSeconds (TURN_TIME);
		}

	}

    public void launchAim() {
        StopCoroutine("rotateRoutine");
        GetComponent<Animator>().SetTrigger("Launch");
        StartCoroutine("restartAim");
    }

    IEnumerator restartAim() {
        yield return new WaitForSeconds(0.75f);
        StartCoroutine("rotateRoutine");
    }
}
