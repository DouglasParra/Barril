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

	void Awake () {
		textCounter.text = counterTime.ToString("0");
        transform.GetComponent<Animator>().SetFloat("Contador", (float)counterTime);

        if (ContadorPadrao())
        {
            particulas = Instantiate(Resources.Load("Brilho_Contador"), transform.position, Quaternion.identity) as GameObject;
            particulas.transform.parent = this.transform;
        }

        gameManager = GameObject.Find("GameManager");
	}

    void Start() {

        if (ContadorPadrao())
        {
            textCounter.transform.parent = transform.parent;
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

		textCounter.text = seconds;

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

	void verifyLoseGame () {
		if (currentTime > counterTime && robotInField) {
			canRunTime = false;
			gameManager.SendMessage ("loseGame");
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Robot") {
			canRunTime = true;
			robotInField = true;
		}
	}

	void OnTriggerExit2D(Collider2D coll) {
        if (coll.gameObject.tag == "Robot")
        {
            canRunTime = false;
            robotInField = false;
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
}
