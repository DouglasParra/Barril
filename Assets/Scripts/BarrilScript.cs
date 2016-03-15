using UnityEngine;
using System.Collections;

public class BarrilScript : MonoBehaviour {

    [HideInInspector]
    public GameObject prefab;

    [Tooltip("Barril onde a bola inicia na fase")]
    public bool start;

    [Space(10)]
    [Tooltip("Girar logo que a bola entrar?")]
    public bool onEnterTurn;
    [Tooltip("Girar quantos ângulos?")]
    public float angles;

    [Tooltip("Deve se mover apenas com a bola?")]
    public bool onEnterMove;

    [Tooltip("Pode se movimentar?")]
    [HideInInspector]
    public bool canMove;

    [Space(10)]
    [Tooltip("Velocidade de disparo da bola para este barril")]
    public float speed;

    [Tooltip("Força da gravidade agindo na bola após ser atirada por este barril")]
    public float gravity;

    public static bool atirar;

    [HideInInspector]
    public Camera camera;

    [Space(10)]
    [Tooltip("Barril deve rotacionar de forma não definida pelo Animator?\nPS: Desligar o animator se usar")]
    public bool rotatePosition;
    [Tooltip("Gira em quantos graus por vez?")]
    public int[] positionsVector;
    private int positionsAux;

    [Space(10)]
    [Tooltip("Bola vai atirar automaticamente? ")]
    public bool automaticShot;

    void Awake() {
        // Muda velocidade das animações
        // GetComponent<Animator>().speed = 1;
        atirar = false;
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        if (onEnterMove) canMove = false;
        if (rotatePosition) positionsAux = 0;
    }

	// Use this for initialization
	void Start () {
        // Verifica qual barril é o inicial
        if (start) {
            // Posiciona uma bola no barril inicial
            prefab = Instantiate(Resources.Load("Orb"), transform.GetChild(0).position, Quaternion.Euler(0, 0, 0)) as GameObject;
            prefab.transform.parent = transform.GetChild(0);
        }

        if (rotatePosition) InvokeRepeating("RotateBarrel", 1, 0.025f);
	}
	
	// Update is called once per frame
	void Update () {
        if (onEnterTurn && transform.GetChild(0).childCount > 0)
        {
            onEnterTurn = false;
            transform.Rotate(new Vector3(0, 0, angles));
        }

        if(atirar) ShootBall();
        if (automaticShot && transform.GetChild(0).childCount > 0) StartCoroutine(AutomaticShot());
	}

    public void ShootBall(){
        // Apenas atira o barril que possui a bola
        if (transform.GetChild(0).childCount > 0)
        {
            prefab.GetComponent<Rigidbody2D>().gravityScale = gravity;

            // Posiciona de maneira que a bola não toque no mesmo barril
            prefab.transform.position = transform.position + transform.up * 2;

            // Aplica uma velocidade na direção que a boca do barril está apontada
            Rigidbody2D rb = prefab.GetComponent<Rigidbody2D>();
            rb.velocity = transform.up * speed;

            // Não é mais filho do barril em que estava
            prefab.transform.parent = null;

            if (!onEnterTurn) {
                onEnterTurn = true;
                transform.Rotate(new Vector3(0, 0, -angles));
            }

            if (onEnterMove) {
                canMove = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (transform.GetChild(0).childCount > 0)
        {
            camera.transform.position = new Vector3(Mathf.Lerp(camera.transform.position.x, Mathf.Clamp(transform.position.x, camera.GetComponent<CameraValuesScript>().getXMin(), camera.GetComponent<CameraValuesScript>().getXMax()), .25f),
                                                    Mathf.Lerp(camera.transform.position.y, Mathf.Clamp(transform.position.y, camera.GetComponent<CameraValuesScript>().getYMin(), camera.GetComponent<CameraValuesScript>().getYMax()), .25f),
                                                    -10);
        }
    }

    private void RotateBarrel()
    {
        transform.Rotate(new Vector3(0, 0, positionsVector[positionsAux]));

        positionsAux += 1;
        if (positionsAux >= positionsVector.Length) positionsAux = 0;
    }

    IEnumerator AutomaticShot()
    {
        yield return new WaitForSeconds(.5f);
        ShootBall();
        yield return new WaitForSeconds(.5f);
    }
}
