using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
  This script is used to read all the data coming from the device. For instance,
  If arduino send ->
     {"1",
     "2",
     "3",}
  readQueue() will return ->
     "1", for the first call
     "2", for the second call
     "3", for the thirst call

  This is the perfect script for integration that need to avoid data loose.
  If you need speed and low latency take a look to wrmhlReadLatest.
*/

public class wrmhlRead : MonoBehaviour {
    // wrmhl is the bridge beetwen your computer and hardware.
    wrmhl myDevice = new wrmhl();

    [Tooltip("SerialPort of your device.")]
    public string portName = "COM8";

    [Tooltip("Baudrate")]
    public int baudRate = 250000;


    [Tooltip("Timeout")]
    public int ReadTimeout = 20;

    [Tooltip("QueueLenght")]
    public int QueueLenght = 1;

    void Start () {
        // This method set the communication with the following vars;
        // Serial Port, Baud Rates, Read Timeout and QueueLenght.
        myDevice.set (portName, baudRate, ReadTimeout, QueueLenght);
        // This method open the Serial communication with the vars previously given.
        myDevice.connect ();
    }

    void Update () {
        // myDevice.read() return the data coming from the device using thread.
        print (myDevice.readQueue () );
    }

    void OnApplicationQuit() {
        // close the Thread and Serial Port
        myDevice.close();
    }
}
