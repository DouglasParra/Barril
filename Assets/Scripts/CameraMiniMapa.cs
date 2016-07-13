using UnityEngine;
using System.Collections;

public class CameraMiniMapa : MonoBehaviour {

    public Camera miniMapCamera;
    private GameObject mainCamera;
    private GameObject backgroundMainCamera;

    public GameObject shootButton;
    public GameObject mainCameraMiniMapButton;

    private bool zoom;
    private float speed = 2f;
    private float t = 0f;

    private Vector3 Origin;
    private Vector3 Diference;
    private bool Drag = false;

	// Use this for initialization
	void Start () {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        backgroundMainCamera = GameObject.Find("background");
        zoom = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (zoom)
        {
            t += Time.deltaTime * speed;
            miniMapCamera.orthographicSize = Mathf.Lerp(8.0f, 16.0f, t);

            if (miniMapCamera.orthographicSize >= 16.0f)
            {
                zoom = false;
                Time.timeScale = 0;
            }
        }
	}

    void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Diference = (GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) - GetComponent<Camera>().transform.position;
            if (!Drag)
            {
                Drag = true;
                Origin = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            Drag = false;
        }

        if (Drag)
        {
            Vector3 aux = Origin - Diference;

            float x = Mathf.Clamp(aux.x, mainCamera.GetComponent<CameraValuesScript>().getXMin(), mainCamera.GetComponent<CameraValuesScript>().getXMax());
            float y = Mathf.Clamp(aux.y, mainCamera.GetComponent<CameraValuesScript>().getYMin(), mainCamera.GetComponent<CameraValuesScript>().getYMax());

            aux = new Vector3(x,y,-10);

            GetComponent<Camera>().transform.position = aux;
        }
    }

    public void startMiniMap() {
        mainCamera.SetActive(false);
        miniMapCamera.enabled = true;
        backgroundMainCamera.SetActive(false);
        shootButton.SetActive(false);
        mainCameraMiniMapButton.SetActive(false);

        if (PlayerPrefs.GetInt("soundOnOff") == 1)
        {
            miniMapCamera.GetComponent<AudioListener>().enabled = true;
        }
        else
        {
            miniMapCamera.GetComponent<AudioListener>().enabled = false;
        }

        zoom = true;
    }

    public void exitMiniMap()
    {
        mainCamera.SetActive(true);
        miniMapCamera.enabled = false;
        backgroundMainCamera.SetActive(true);
        shootButton.SetActive(true);
        mainCameraMiniMapButton.SetActive(true);
        miniMapCamera.GetComponent<AudioListener>().enabled = false;

        zoom = false;
        t = 0f;
        miniMapCamera.transform.position = mainCamera.transform.position;
        miniMapCamera.orthographicSize = 8.0f;
        Time.timeScale = 1;
    }
}

