using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

    // Velocidade de movimento
    public float speed;

    // Serve tanto para x como para y
    public float posicaoInicial;

    // Serve tanto para x como para y
    public float posicaoFinal;

    // Se true, o barril move-se horizontalmente; se false, verticalmente
    public bool movimentoHorizontal;

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = transform.position;

        if (transform.GetComponent<BarrilScript>().canMove)
        {
            if (movimentoHorizontal)
            {
                if (transform.localPosition.x > posicaoFinal) speed = -speed;
                else if (transform.localPosition.x < posicaoInicial) speed = -speed;

                pos.x += speed;
            }
            else
            {
                if (transform.localPosition.y > posicaoFinal) speed = -speed;
                else if (transform.localPosition.y < posicaoInicial) speed = -speed;

                pos.y += speed;
            }

            transform.position = pos;
        }
    }

}
