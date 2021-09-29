using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActiveOnce : MonoBehaviour
{
    public Sprite activated;
    public Sprite deactivated;
    private AudioSource source;
    public AudioClip activateSound;
    public bool active { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        gameObject.AddComponent<AudioSource>();
        source = gameObject.GetComponent<AudioSource>();
        GetComponent<SpriteRenderer>().sprite = deactivated;
    }

    public void OnMouseDown()
    {
        if (!active)
        {
            active = true;
            source.PlayOneShot(activateSound);
            GetComponent<SpriteRenderer>().sprite = activated;
        }
    }
}
