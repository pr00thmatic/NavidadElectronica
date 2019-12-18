using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Score : MonoBehaviour {
    [Range(0,10)]
    public int puntuacion;
    public Text displayer;

    public void MarkOK () {
        puntuacion = Mathf.Min(10, puntuacion+1);
    }

    public void MarkFail () {
        puntuacion = Mathf.Max(0, puntuacion-1);
    }

    void Update () {
        displayer.text = puntuacion + "";
    }
}
