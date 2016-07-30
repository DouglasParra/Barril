using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FieldCounter : MonoBehaviour {

	[Tooltip("Tempo em segundos para ativar a derrota. Valor Float")]
	public float counterTime;

	public Text textCounter;

	private bool canRunTime = false;

	private float currentTime = 0.0f;

	private bool robotInField = false;

    private GameObject gameManager;

    private GameObject particulas;

    private GameObject shootButton;

	void Awake () {
		textCounter.text = counterTime.ToString("0");
        transform.GetComponent<Animator>().SetFloat("Contador", (float)counterTime);

        if (ContadorPadrao())
        {
            particulas = Instantiate(Resources.Load("Brilho_Contador"), transform.position, Quaternion.identity) as GameObject;
            particulas.transform.parent = this.transform;
        }

        gameManager = GameObject.Find("GameManager");
        shootButton = GameObject.Find("ShootButton");
	}

    void Start() {

        if (ContadorPadrao())
        {
            textCounter.transform.SetParent(transform.parent);
        }

        if (float.Parse(textCounter.text) >= 8.0f)
        //if (counterTime >= 8.0f)
        {
            textCounter.color = Color.green;
            if (ContadorPadrao())
            {
                particulas.GetComponent<Animator>().SetFloat("Contador", 10.0f);
            }
            else if (ContadorMovimento())
            {
                GetComponent<FieldMove>().rastro.GetComponent<Animator>().SetFloat("Contador", 10.0f);
                GetComponent<FieldMove>().rastroB.GetComponent<Animator>().SetFloat("Contador", 10.0f);
            }
        }
        else if (float.Parse(textCounter.text) >= 5.0f)
        //else if (counterTime >= 5.0f)
        {
            textCounter.color =  Color.yellow;
            if (ContadorPadrao())
            {
                particulas.GetComponent<Animator>().SetFloat("Contador", 7.0f);
            }
            else if (ContadorMovimento())
            {
                GetComponent<FieldMove>().rastro.GetComponent<Animator>().SetFloat("Contador", 7.0f);
                GetComponent<FieldMove>().rastroB.GetComponent<Animator>().SetFloat("Contador", 7.0f);
            }
        }
        else if (float.Parse(textCounter.text) >= 3.0f)
        //else if (counterTime >= 3.0f)
        {
            textCounter.color = new Color(1, 0.5f, 0, 1);
            if (ContadorPadrao())
            {
                particulas.GetComponent<Animator>().SetFloat("Contador", 4.0f);
            }
            else if (ContadorMovimento())
            {
                GetComponent<FieldMove>().rastro.GetComponent<Animator>().SetFloat("Contador", 4.0f);
                GetComponent<FieldMove>().rastroB.GetComponent<Animator>().SetFloat("Contador", 4.0f);
            }
        }
        else
        {
            textCounter.color = Color.red;
            if (ContadorPadrao())
            {
                particulas.GetComponent<Animator>().SetFloat("Contador", 2.0f);
            }
            else if (ContadorMovimento())
            {
                GetComponent<FieldMove>().rastro.GetComponent<Animator>().SetFloat("Contador", 2.0f);
                GetComponent<FieldMove>().rastroB.GetComponent<Animator>().SetFloat("Contador", 2.0f);
            }
        }
    }

	void Update () {
		if (canRunTime) {
			updateTimes ();
			updateTextComponent ();
			verifyLoseGame ();
		}
	}

	void updateTimes () {
		currentTime += Time.deltaTime;
	}

	void updateTextComponent () {
		string seconds = Mathf.Floor((counterTime - currentTime) % 60).ToString("0");
        transform.GetComponent<Animator>().SetFloat("Contador", float.Parse(seconds));

        //Debug.Log(transform.name + " - " + float.Parse(seconds));

        if (int.Parse(seconds) >= 0)
        {
            textCounter.text = seconds;
        }

        if (ContadorPadrao())
        {
            particulas.GetComponent<Animator>().SetFloat("Contador", float.Parse(seconds));
        }
        else if (ContadorMovimento())
        {
            GetComponent<FieldMove>().rastro.GetComponent<Animator>().SetFloat("Contador", float.Parse(seconds));
            GetComponent<FieldMove>().rastroB.GetComponent<Animator>().SetFloat("Contador", float.Parse(seconds));
        }

		//textCounter.color = Color.Lerp(Color.green, Color.red, 	currentTime/counterTime);
        if (float.Parse(textCounter.text) >= 8.0f)
        {
            textCounter.color = Color.green;
        }
        else if (float.Parse(textCounter.text) >= 5.0f)
        {
            textCounter.color = Color.yellow;
        }
        else if (float.Parse(textCounter.text) >= 3.0f)
        {
            textCounter.color = new Color(1, 0.5f, 0, 1);
        }
        else
        {
            textCounter.color = Color.red;
        }
	}

    IEnumerator TocarAnimacaoColisaoLaser()
    {
        yield return new WaitForSeconds(1.1f);
        gameManager.SendMessage("loseGame");
    }

	void verifyLoseGame () {
		if (currentTime > counterTime && robotInField) {
			canRunTime = false;
            shootButton.SetActive(false);
            GameObject robot = GameObject.FindGameObjectWithTag("Robot");

            if (robot.GetComponent<SpriteRenderer>().enabled)
            {
                GameObject g = Instantiate(Resources.Load("RobotColisaoLaser"), robot.transform.position, robot.transform.rotation) as GameObject;
                g.transform.parent = this.transform;
                GetComponent<AudioSource>().Play();
            }

            robot.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            //Destroy(robot);

            StartCoroutine("TocarAnimacaoColisaoLaser");
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Robot") {
			canRunTime = true;
			robotInField = true;
            if (ContadorPadrao()) ResetarAnimacao();
		}
	}

	void OnTriggerExit2D(Collider2D coll) {
        if (coll.gameObject.tag == "Robot")
        {
            canRunTime = false;
            robotInField = false;
            if (ContadorPadrao()) ResetarAnimacao();
        }
	}

    private bool ContadorPadrao() {
        if (transform.name.StartsWith("C-AIM")) return true;
        return false;
    }

    private bool ContadorMovimento()
    {
        if (transform.name.StartsWith("C-MOV")) return true;
        return false;
    }

    private void ResetarAnimacao()
    {
        if (float.Parse(textCounter.text) >= 8.0f)
        {
            GetComponent<Animator>().Play("Contador_Padrão_Verde", 0, GetComponent<FieldAim>().TURN_TIME);
        }
        else if (float.Parse(textCounter.text) >= 5.0f)
        {
            GetComponent<Animator>().Play("Contador_Padrão_Amarelo", 0, GetComponent<FieldAim>().TURN_TIME);
        }
        else if (float.Parse(textCounter.text) >= 3.0f)
        {
            GetComponent<Animator>().Play("Contador_Padrão_Laranja", 0, GetComponent<FieldAim>().TURN_TIME);
        }
        else
        {
            GetComponent<Animator>().Play("Contador_Padrão_Vermelho", 0, GetComponent<FieldAim>().TURN_TIME);
        }
    }
}
