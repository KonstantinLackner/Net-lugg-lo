using UnityEngine;

public class TriggerActive : MonoBehaviour
{
    public Sprite activated;
    public Sprite deactivated;
    private AudioSource source;
    public AudioClip activateSound;
    public AudioClip deactivateSound;
    private bool active;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        gameObject.AddComponent<AudioSource>();
        source = gameObject.GetComponent<AudioSource>();
    }

    public void OnMouseDown()
    {
        if (!active)
        {
            active = true;
            source.PlayOneShot(activateSound);
            GetComponent<SpriteRenderer>().sprite = activated;
        }
        else
        {
            active = false;
            source.PlayOneShot(deactivateSound);
            GetComponent<SpriteRenderer>().sprite = deactivated;
        }
    }
}
