using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface for GSE_Collector
public interface GSE_Data
{
    // Vehicle State
    float Speed { get; }
    float Steering { get; }

    bool Reverse { get; }

    string Blinker { get; }

    // Inputs
    float TurnInput { get; }
}

namespace GenerativeSoundEngine
{

    // Requiered Components
    [RequireComponent(typeof(VehicleBehaviour.WheelVehicle))]

    public class GSE_Collector : MonoBehaviour, GSE_Data
    {

        // Method to get Input, copyed from "WheelVehicle.cs"
        private float GetInput(string input)
        {
#if MULTIOSCONTROLS
        return MultiOSControls.GetValue(input, playerId);
#else
            return Input.GetAxis(input);
#endif
        }

        // Init Inputs
        string turninput = "Horizontal";
        //string blinkersLeftInput = "blinker_left";
        //string blinkersRightInput = "blinker_right";

        // Steering Input curve
        AnimationCurve turnInputCurve = AnimationCurve.Linear(-1.0f, -1.0f, 1.0f, 1.0f);

        // Init Interface members
        // Speed
        float speed = 0.0f;
        public float Speed { get { return speed; } }

        // TurnInput
        float turnInput;
        public float TurnInput { get { return turnInput; } }

        // Steering
        float steering;
        public float Steering { get { return steering; } }

        // Reverse
        bool reverse = false;
        public bool Reverse { get { return reverse; } }

        // Blinker
        string blinker = "off";
        public string Blinker { get { return blinker; } }



        // Init Interface to other Classes
        private IVehicle Vehicle;

        // Start is called before the first frame update
        void Start()
        {

            // Get Components from other Classes
            Vehicle = GetComponent<VehicleBehaviour.WheelVehicle>();

        }

        // Update is called once per frame
        void Update()
        {

            // Update Interface Members
            // Speed
            speed = Vehicle.Speed;

            // Steering
            turnInput = GetInput(turninput);
            steering = turnInputCurve.Evaluate(turnInput);

            // Forward/Reverse
            if (Input.GetButtonDown("forward"))
            {
                reverse = false;
            }
            else if (Input.GetButtonDown("reverse"))
            {
                reverse = true;
            }
            // Blinker
            if (Input.GetButtonDown("blinker_left"))
            {
                if (blinker != "Left")
                {
                    blinker = "Left";
                }
                else
                {
                    blinker = "Off";
                }
            }
            else if (Input.GetButtonDown("blinker_right"))
            {
                if (blinker != "Right")
                {
                    blinker = "Right";
                }
                else
                {
                    blinker = "Off";
                }
            }
            else if (Input.GetButtonDown("blinker_clear"))
            {
                blinker = "Off";
            }
        }
    }
}
