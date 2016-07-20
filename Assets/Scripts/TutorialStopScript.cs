using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialStopScript : MonoBehaviour {

    public GameObject tutorialCanvas;
    public GameObject mainBgImage;
    public GameObject focusBgImage;
    public bool next;

    void Start()
    {
        next = true;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Robot" && next==true)
        {
            Time.timeScale = 0;
            tutorialCanvas.SetActive(true);
            focusBgImage.SetActive(true);
            mainBgImage.GetComponent<Image>().color = new Color(0,0,0,0);
            next = false;
            GetComponentInParent<AudioSource>().Play();
        }
    }
}
