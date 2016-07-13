using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingProgressBar : MonoBehaviour {

    public Transform loadingBar;
    public Transform textIndicator;
    public int loadingValue;

    [SerializeField]
    private float currentAmmount;

    [SerializeField]
    private float speed;
	
	// Update is called once per frame
	void Update () {

        if (currentAmmount < loadingValue)
        {
            currentAmmount += speed * Time.deltaTime;
            textIndicator.GetComponent<Text>().text = "Loading data... " + ((int)currentAmmount).ToString() + "%";
        }
        else 
        {
            if (currentAmmount >= 100)
            {
                textIndicator.GetComponent<Text>().text = "Done!";
            }
        }

        loadingBar.GetComponent<Image>().fillAmount = currentAmmount / 100;

	}

    public void goToLoading(int value) {
        loadingValue = value;
    }
}
