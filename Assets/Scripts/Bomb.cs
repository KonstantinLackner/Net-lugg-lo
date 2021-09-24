using System;
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
        private GameObject ripcord;
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
            ripcord = GameObject.Find("ripcord");
            redButton = GameObject.Find("redButton").GetComponent<TriggerActive>();
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
        }

        private bool bombConditionsFullfilled()
        {
            int checkSum = 0;
            
            if (blueButtonValue != redButtonValue)
            {
                checkSum++;
            }

            if (greenButtonValue)
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

            if (blueButtonValue && blueButtonValue)
            {
                checkSum++;
            }

            if (blueCableValue)
            {
                checkSum++;
            }

            if (!bellowInUpperThird)
            {
                checkSum++;
            }
            
            if (!ripcordNotToFarOut)
            {
                checkSum++;
            }

            return checkSum == 0;
        }
    }
}