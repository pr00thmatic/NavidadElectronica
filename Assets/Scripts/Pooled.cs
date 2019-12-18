using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pooled : MonoBehaviour {
    public event System.Action onPonerAlFinal;

    public GameObject root;
    public PooledManager manager;
    public Transform dondeVaElSiguiente;

    void Start () {
        if (!manager.fueGenerado) {
            manager.fueGenerado = true;
            manager.elFinal = this;
            manager.Generar();
        }
    }

    void OnTriggerExit (Collider c) {
        if (c.GetComponent<AreaDeVision>()) {
            PonerAlFinal();
        }
    }

    public void PonerAlFinal () {
        root.transform.position =
            manager.elFinal.dondeVaElSiguiente.position;
        manager.elFinal = this;

        if (onPonerAlFinal != null) {
            onPonerAlFinal();
        }
    }
}
