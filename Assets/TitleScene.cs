using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour {

    public GameObject loadingMini;
    public GameObject buttonSFX;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
    IEnumerator LoadNewScene(string levelName)
    {

        // This line waits for 1 seconds before executing the next line in the coroutine.
        // This line is only necessary for this demo. The scenes are so simple that they load too fast to read the "Loading..." text.
        yield return new WaitForSeconds(1);

        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        AsyncOperation async = SceneManager.LoadSceneAsync(levelName);

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!async.isDone)
        {
            yield return null;
        }

    }

	public void changeScene() {
        if (PlayerPrefs.GetInt("soundOnOff") == 1)
        {
            buttonSFX.GetComponent<AudioSource>().Play();
        }

		if (PlayerPrefs.HasKey("tutorialDone") && PlayerPrefs.GetInt("tutorialDone")==1) {
            loadingMini.SetActive(true);
            StartCoroutine("LoadNewScene", "StageSelect");
			//SceneManager.LoadScene ("StageSelect");
		} else {
            loadingMini.SetActive(true);
            StartCoroutine("LoadNewScene", "TutorialScene");
			//SceneManager.LoadScene ("TutorialScene");
		}
	}
}
