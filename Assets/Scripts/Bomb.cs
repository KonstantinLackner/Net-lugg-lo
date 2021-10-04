using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class Bomb: MonoBehaviour
    {
        private GameObject bellowNeedle;
        private TriggerActive blueButton;
        private TriggerActiveOnce blueCable;
        private TriggerActive greenButton;
        private TriggerActive redSwitch;
        private TriggerActive blueSwitch;
        private TriggerActiveOnce orangeCable;
        private TriggerActiveOnce greenCable;
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

        private float bellowNeedleValue;

        private Timer timer;

        private void Start()
        {
            bellowNeedle = GameObject.Find("needle");
            blueButton = GameObject.Find("blueButton").GetComponent<TriggerActive>();
            blueCable = GameObject.Find("blueCable").GetComponent<TriggerActiveOnce>();
            greenButton = GameObject.Find("greenButton").GetComponent<TriggerActive>();
            redSwitch = GameObject.Find("redSwitch").GetComponent<TriggerActive>();
            blueSwitch = GameObject.Find("blueSwitch").GetComponent<TriggerActive>();
            orangeCable = GameObject.Find("orangeCable").GetComponent<TriggerActiveOnce>();
            greenCable = GameObject.Find("greenCable").GetComponent<TriggerActiveOnce>();
            ripcord = GameObject.Find("ripcord").GetComponent<Ripcord>();
            redButton = GameObject.Find("redButton").GetComponent<TriggerActive>();

            timer = GameObject.Find("timer").GetComponent<Timer>();

            bellowNeedleValue = bellowNeedle.transform.localRotation.z;
        }

        private void Update()
        {
            bellowNeedleValue = bellowNeedle.transform.localRotation.z;

            Debug.Log(bellowNeedle.transform.localRotation.z);
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
                    SceneManager.LoadScene("Scenes/WinScreen");
                    Debug.Log("Won");
                }
                else
                {
                    SceneManager.LoadScene("Scenes/LoseScreen");
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

            if (bellowNeedle.transform.localRotation.z > -0.5f)
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