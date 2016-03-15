using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StageSelectScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StageSelect() {
        SceneManager.LoadScene(0);
    }

    public void Stage1()
    {
        SceneManager.LoadScene(1);
    }

    public void Stage2()
    {
        SceneManager.LoadScene(2);
    }

    public void Stage3()
    {
        SceneManager.LoadScene(3);
    }

    public void Stage4()
    {
        SceneManager.LoadScene(4);
    }
}
