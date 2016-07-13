using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {

    public void PlayAnimationDestroy()
    {
        Destroy(this.gameObject);
    }
}
