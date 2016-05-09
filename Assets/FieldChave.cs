using UnityEngine;
using System.Collections;

public class FieldChave : MonoBehaviour {

    private GameObject robot;
    public GameObject parede;

    // Use this for initialization
    void Start()
    {
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
            parede.SetActive(false);
            StartCoroutine(AutomaticShot());
        }
    }

}
