using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingScene : MonoBehaviour {

    public Transform loadingBar;
    public int loadingValue;

    [SerializeField]
    private float currentAmmount;

    [SerializeField]
    private float speed;

    // Update is called once per frame
    void Update()
    {

        if (currentAmmount < loadingValue)
        {
            currentAmmount += speed * Time.deltaTime;
        }
        else
        {
            if (currentAmmount >= 100)
            {
                currentAmmount = 0;
            }
        }

        loadingBar.GetComponent<Image>().fillAmount = currentAmmount / 100;

    }

}
