/*
 * This code is part of Arcade Car Physics for Unity by Saarg (2018)
 * 
 * This is distributed under the MIT Licence (see LICENSE.md for details)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VehicleBehaviour {

    [RequireComponent(typeof(WheelVehicle))]

    public class GSE_Mapper : MonoBehaviour {

        // Set GUI elements for tuning values

        // Speed
        [Header("Speed parameter")]
        public float flatoutSpeed = 300.0f;
        public float minSpeed = 0;
        public float maxSpeed = 5000;

        // Init Interface to GSE_WheelVehicle
        private IVehicle _vehicle;


        void Start () {
            
            // Get WheelVhiicle Component
            _vehicle = GetComponent<WheelVehicle>();

        }
        
        void Update () {

            // Get emitter from FMOD event
            var emitter = GetComponent<FMODUnity.StudioEventEmitter>();

            // map vehicle data to FMOD emitter
            // Speed
            float effectiveSpeed = Mathf.Lerp(minSpeed, maxSpeed, Mathf.Abs(_vehicle.Speed) / flatoutSpeed);
            emitter.SetParameter("RPM", effectiveSpeed);
        
        }
    }
}
