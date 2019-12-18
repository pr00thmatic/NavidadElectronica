using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PooledManager : MonoBehaviour {
    public int cantidad;
    public Pooled elFinal;
    public bool fueGenerado;

    public void Generar () {
        for (int i=0; i<cantidad; i++) {
            Pooled creado = Instantiate(elFinal.root)
                .GetComponentInChildren<Pooled>();
            creado.PonerAlFinal();
        }
    }
}
