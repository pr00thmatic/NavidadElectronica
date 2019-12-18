using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Casa : MonoBehaviour {
    public Pooled pool;
    public Transform minimo;
    public Transform maximo;
    public GameObject frosty;

    public Material[] colorBase;
    public Material[] colorTecho;

    public MeshRenderer rend;

    void OnEnable () {
        pool.onPonerAlFinal += Aleatorizar;
    }

    void OnDisable () {
        pool.onPonerAlFinal -= Aleatorizar;
    }

    public void Aleatorizar () {
        // tamaño
        transform.localScale =
            new Vector3(Random.Range(minimo.localScale.x, maximo.localScale.x),
                        Random.Range(minimo.localScale.y, maximo.localScale.y),
                        Random.Range(minimo.localScale.z, maximo.localScale.z));

        // color
        int colorAleatorio = Random.Range(0, colorBase.Length);
        Material[] materials = rend.materials;
        materials[1] = colorBase[colorAleatorio];
        materials[0] = colorTecho[colorAleatorio];
        rend.materials = materials;

        // frosty :D
        frosty.SetActive(Random.Range(0, 1f) < 0.5);
    }
}
