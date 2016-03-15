using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RetryScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Retry() {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
}
