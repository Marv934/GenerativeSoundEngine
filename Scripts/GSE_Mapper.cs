/*
 * This code is part of Generative Sound Engine
 */
using System.Collections;
using System.Collections.Generic;
//using System.IO;
//using System;
using UnityEngine;

namespace GenerativeSoundEngine
{
    // [RequireComponent(typeof(VehicleBehaviour.WheelVehicle))]

    public class GSE_Mapper : MonoBehaviour {

        // Set GUI elements for tuning values

        // Speed
        // [Header("Speed parameter")]
        // public float flatoutSpeed = 300.0f;
        // public float minSpeed = 0;
        // public float maxSpeed = 5000;

        // Init Interface to GSE_WheelVehicle
        // private IVehicle Vehicle;


        void Start () {
            
            // Get WheelVhiicle Component
            // Vehicle = GetComponent< VehicleBehaviour.WheelVehicle >();

        }
        
        void Update () {

            // Get emitter from FMOD event
            // var emitter = GetComponent<FMODUnity.StudioEventEmitter>();

            // map vehicle data to FMOD emitter
            // Speed
            // float effectiveSpeed = Mathf.Lerp(minSpeed, maxSpeed, Mathf.Abs(Vehicle.Speed) / flatoutSpeed);
            // emitter.SetParameter("RPM", effectiveSpeed); // Do When FMOD is configured
            // string log = DateTime.Now + ", " + Vehicle.Speed.ToString() + ";" + System.Environment.NewLine;
            // File.AppendAllText(@"D:\logfile.txt", log);

        }
    }
}
