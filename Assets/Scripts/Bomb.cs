﻿using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Bomb: MonoBehaviour
    {
        private GameObject bellowNeedle;
        private TriggerActive blueButton;
        private TriggerActive blueCable;
        private TriggerActive greenButton;
        private TriggerActive redSwitch;
        private TriggerActive blueSwitch;
        private TriggerActive orangeCable;
        private TriggerActive greenCable;
        private Ripcord ripcord;
        private TriggerActive redButton;
        
        private bool bellowInUpperThird;
        private bool blueButtonValue;
        private bool blueCableValue;
        private bool greenButtonValue;
        private bool redSwitchValue;
        private bool blueSwitchValue;
        private bool orangeCableValue;
        private bool greenCableValue;
        private bool ripcordNotToFarOut;
        private bool redButtonValue;

        private Timer timer;

        private void Start()
        {
            bellowNeedle = GameObject.Find("needle");
            blueButton = GameObject.Find("blueButton").GetComponent<TriggerActive>();
            blueCable = GameObject.Find("blueCable").GetComponent<TriggerActive>();
            greenButton = GameObject.Find("greenButton").GetComponent<TriggerActive>();
            redSwitch = GameObject.Find("redSwitch").GetComponent<TriggerActive>();
            blueSwitch = GameObject.Find("blueSwitch").GetComponent<TriggerActive>();
            orangeCable = GameObject.Find("orangeCable").GetComponent<TriggerActive>();
            greenCable = GameObject.Find("greenCable").GetComponent<TriggerActive>();
            ripcord = GameObject.Find("ripcord").GetComponent<Ripcord>();
            redButton = GameObject.Find("redButton").GetComponent<TriggerActive>();

            timer = GameObject.Find("timer").GetComponent<Timer>();
        }

        private void Update()
        {
            bellowInUpperThird = bellowNeedle.transform.localRotation.z > 0.55f;
            blueButtonValue = blueButton.active;
            blueCableValue = blueCable.active;
            greenButtonValue = greenButton.active;
            redSwitchValue = redSwitch.active;
            blueSwitchValue = blueSwitch.active;
            orangeCableValue = orangeCable.active;
            greenCableValue = greenCable.active;
            // ripcordNotToFarOut
            redButtonValue = redButton.active;

            if (timer.timeValue <= 0)
            {
                Debug.Log("timer ran out");
                if (bombConditionsFullfilled())
                {
                    Debug.Log("Won");
                }
                else
                {
                    Debug.Log("Lost");
                }
            }
            
        }

        private bool bombConditionsFullfilled()
        {
            int checkSum = 0;
            
            if (blueButtonValue == redButtonValue)
            {
                checkSum++;
            }

            if (greenButtonValue != redButtonValue)
            {
                if (!redButtonValue)
                {
                    checkSum++;
                }
            }

            if (redSwitchValue && redButtonValue)
            {
                checkSum++;
            }

            if (blueSwitchValue && blueButtonValue)
            {
                checkSum++;
            }

            if (redButtonValue && orangeCableValue)
            {
                checkSum++;
            }

            if (greenButtonValue && greenCableValue)
            {
                checkSum++;
            }

            if (blueButtonValue && blueCableValue)
            {
                checkSum++;
            }

            if (blueCableValue)
            {
                checkSum++;
            }

            if (Vector3.Distance(ripcord.line.GetPosition(0), ripcord.line.GetPosition(1)) > 1.3f)
            {
                checkSum++;
            }

            if (bellowNeedle.transform.localRotation.z < -0.5f)
            {
                checkSum++;
            }

            if (!blueButtonValue)
            {
                if (!blueCableValue)
                {
                    checkSum++;
                }
            }

            if (!redButtonValue)
            {
                if (!orangeCableValue)
                {
                    checkSum++;
                }
            }

            if (!greenButtonValue)
            {
                if (!greenCableValue)
                {
                    checkSum++;
                }
            }
            
            return checkSum == 0;
        }
    }
}