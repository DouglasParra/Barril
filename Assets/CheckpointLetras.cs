using UnityEngine;
using System.Collections;

public class CheckpointLetras : MonoBehaviour {

    public void destruirLetras()
    {
        Destroy(this.gameObject, 1.2f);
    }

}
