using UnityEngine;
using System.Collections;

public class FieldChave : MonoBehaviour {

    private GameObject robot;
    public GameObject porta;

    [Tooltip("0 - Roxo; 1 - Azul; 2 - Verde; 3 - Amarelo; 4 - Laranja; 5 - Vermelho;")]
    public int numeroPorta;

    // Use this for initialization
    void Start()
    {
        GetComponent<Animator>().SetInteger("Cor", numeroPorta);
        porta.GetComponent<Animator>().SetInteger("Cor", numeroPorta);
        robot = GameObject.Find("Robot");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator AutomaticShot()
    {
        yield return new WaitForSeconds(.1f);
        robot.SendMessage("launch");
        //		yield return new WaitForSeconds(.1f);
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Robot")
        {
            //porta.SetActive(false);
            porta.GetComponent<Animator>().SetBool("Aberta", true);
            porta.GetComponent<BoxCollider2D>().enabled = false;
            if (GetComponent<Animator>().GetBool("Piscando") == false)
            {
                GetComponent<AudioSource>().Play();
            }
            GetComponent<Animator>().SetBool("Piscando", true);
            StartCoroutine(AutomaticShot());
        }
    }

}
