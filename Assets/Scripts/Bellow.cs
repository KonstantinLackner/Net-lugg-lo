using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Bellow: MonoBehaviour
    {
        public GameObject needle;
        private int pumpCount;
        public Sprite squeezed;
        public Sprite notSqueezed;
        
        private void Start()
        {
            needle = GameObject.Find("needle");
            pumpCount = 0;
        }

        private void Update()
        {
            rotateNeedle(0.01f);
        }

        private void rotateNeedle(float rotation)
        {
            needle.transform.Rotate(0f,0f,rotation);
            
            // Sanity check
            if (needle.transform.localRotation.z > 0.7f)
            {
                needle.transform.rotation = Quaternion.Euler(0f, 0f, 88f);
            } else if (needle.transform .localRotation.z < -0.65f)
            {
                needle.transform.rotation = Quaternion.Euler(0f, 0f, -75f);
            }
        }

        private void OnMouseDown()
        {
            rotateNeedle(-10f);
            GetComponent<SpriteRenderer>().sprite = squeezed;
        }

        private void OnMouseUp()
        {
            rotateNeedle(0.5f);
            GetComponent<SpriteRenderer>().sprite = notSqueezed;
        }
    }
}