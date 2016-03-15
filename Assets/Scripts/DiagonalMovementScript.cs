using UnityEngine;
using System.Collections;

public class DiagonalMovementScript : MonoBehaviour
{

    public Transform volta1;
    public Transform volta2;

    [Tooltip("Se diagonal principal == true, valor deve ser oposto de speedY")]
    public float speedX;
    [Tooltip("Se diagonal principal == true, valor deve ser oposto de speedX")]
    public float speedY;

    private float volta1X, volta1Y;
    private float volta2X, volta2Y;

    [Tooltip("Se true, movimento deve ser feito na diagonal principal")]
    public bool diagonalPrincipal;

    void Start() {
        volta1X = volta1.position.x;
        volta1Y = volta1.position.y;

        volta2X = volta2.position.x;
        volta2Y = volta2.position.y;
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 pos = transform.position;

        if (!diagonalPrincipal)
        {
            if ((transform.position.x >= volta1X && transform.position.y >= volta1Y) ||
                (transform.position.x <= volta2X && transform.position.y <= volta2Y))
            {
                speedX = -speedX;
                speedY = -speedY;
            }
        }
        else {
            if ((transform.position.x >= volta1X && transform.position.y <= volta1Y) ||
                (transform.position.x <= volta2X && transform.position.y >= volta2Y))
            {
                speedX = -speedX;
                speedY = -speedY;
            }
        }

        pos.x += speedX;
        pos.y += speedY;

        transform.position = pos;
	}
}
