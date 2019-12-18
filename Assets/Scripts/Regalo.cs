using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Regalo : MonoBehaviour {
    public Score score;
    public bool consumido = false;

    void OnTriggerEnter (Collider c) {
        if (consumido) return;

        if (c.GetComponent<AreaOK>()) {
            score.MarkOK();
            consumido = true;
        } else if (c.GetComponent<AreaNotOK>()) {
            score.MarkFail();
            consumido = true;
        }
    }

    void OnTriggerExit (Collider c) {
        if (c.GetComponent<AreaDeVision>()) {
            Destroy(gameObject);
        }
    }
}
