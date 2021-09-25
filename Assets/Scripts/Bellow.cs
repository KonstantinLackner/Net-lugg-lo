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
        private AudioSource source;
        public AudioClip activateSound;
        public AudioClip deactivateSound;
        
        private void Start()
        {
            needle = GameObject.Find("needle");
            pumpCount = 0;
            gameObject.AddComponent<AudioSource>();
            source = gameObject.GetComponent<AudioSource>();
        }

        private void Update()
        {
            rotateNeedle(10f);
        }

        private void rotateNeedle(float rotation)
        {
            needle.transform.Rotate(0f,0f,rotation * Time.deltaTime);
            
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
            rotateNeedle(-5000f);
            GetComponent<SpriteRenderer>().sprite = squeezed;
            source.PlayOneShot(activateSound);
        }

        private void OnMouseUp()
        {
            rotateNeedle(50f);
            GetComponent<SpriteRenderer>().sprite = notSqueezed;
            source.PlayOneShot(deactivateSound);
        }
    }
}