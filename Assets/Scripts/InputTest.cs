using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputTest : MonoBehaviour {
    public wrmhl device = new wrmhl();

    public Transform a;
    public Transform b;

    void OnEnable () {
        device.set("COM5", 9600, 100, 1);
        device.connect();
    }

    void OnDisable () {
        device.close();
    }

    void Update () {
        string raw = device.readQueue();

        if (raw != null) {
            int value = int.Parse(raw);

            transform.position =
                Vector3.Lerp(a.position, b.position,
                             value/1024f);
        }
    }
}
