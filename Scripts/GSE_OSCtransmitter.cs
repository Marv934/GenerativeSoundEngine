/*
 * This code is part of Generative Sound Engine
 */
using System;
using UnityEngine;
using System.Globalization;
using extOSC;

namespace GenerativeSoundEngine
{
    [RequireComponent(typeof(GSE_Collector))]

    public class GSE_OSCtransmitter : MonoBehaviour
    {
        #region Public Vars
        public OSCTransmitter Transmitter;
        public string RemoteHost = "127.0.0.1";
        public int RemotePort = 7711;
        public string RootAddress = "/GSE";

        #endregion

        private GSE_Data collector;

        #region Unity Methods

        protected virtual void Start()
        {
            // init collector interface
            collector = GetComponent<GSE_Collector>();
            // Set remote host and port
            Transmitter.RemoteHost = RemoteHost;
            Transmitter.RemotePort = RemotePort;
            // send initial OSC Message
            var message = new OSCMessage(RootAddress);
            message.AddValue(OSCValue.String("Start transmitting parameters!"));
            Transmitter.Send(message);

        }


        void Update()
        {
            var message = new OSCMessage(RootAddress);
            message.AddValue(OSCValue.Float(collector.Speed));
            message.AddValue(OSCValue.Float(collector.Steering));
            message.AddValue(OSCValue.Bool(collector.Reverse));
            message.AddValue(OSCValue.String(collector.Blinker));
            message.AddValue(OSCValue.Float(collector.TurnInput));
            Transmitter.Send(message);
        }

        #endregion
    }
}