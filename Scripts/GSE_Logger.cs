using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
using UnityEngine;

namespace GenerativeSoundEngine
{
    // Requiered Components
    [RequireComponent(typeof(GSE_Collector))]

    public class GSE_Logger : MonoBehaviour
    {
        [Header("PATH")]
        // Init <logfile>.csv
        [SerializeField] string logFilePath = @"D:";
        string startDate = DateTime.Now.ToString().Replace(" ", "-").Replace(".", "-").Replace(":", "-");
        string logFile;
        string logSeperator = ",";
        string stringWrite;

        // Init Interface to GSE_WheelVehicle
        private GSE_Data collector;

        // Start is called before the first frame update
        void Start()
        {
            logFile = logFilePath + "/GSE_LOG_" + startDate + ".csv";

            // Get Collector Components
            collector = GetComponent<GSE_Collector>();

            // Create logfile
            //
            // Column name String
            string[] headerArray = { "Timestamp", "TurnInput", "Speed", "Steering", "Reverse", "Blinker"};
            // Join Strings
            //int ilength = stringArray.GetLength(0);
            //for (int i = 0; i < ilength; i++)
            //{
            stringWrite = string.Join(logSeperator, headerArray) + ";" + System.Environment.NewLine;
            //}

            // Create and write logfile
            File.WriteAllText(logFile, stringWrite);

        }

        // Update is called once per frame
        void Update()
        {

            // Value String Array
            string value = 
                DateTime.Now.ToString() + logSeperator +
                collector.TurnInput.ToString("0.0000", CultureInfo.GetCultureInfo("en-US")) + logSeperator +
                collector.Speed.ToString("0.0000", CultureInfo.GetCultureInfo("en-US")) + logSeperator +
                collector.Steering.ToString("0.0000", CultureInfo.GetCultureInfo("en-US")) + logSeperator +
                collector.Reverse.ToString() + logSeperator +
                collector.Blinker.ToString() +
                ";" + System.Environment.NewLine;

            // Join Strings
            //stringWrite = string.Join(logSeperator, valueArray) + ";" + System.Environment.NewLine;

            // Write to logfile
            File.AppendAllText(logFile, value);
        }
    }
}
