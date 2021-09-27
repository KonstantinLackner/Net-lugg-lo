using System.Collections;
using UnityEngine;

public class Heinz : MonoBehaviour
{
    public AudioSource source;
    public AudioSource source2;
    public AudioClip hints;
    private bool playing;
    public AudioClip[] interruptsBad;
    public AudioClip[] interruptsGood;
    
    // Start is called before the first frame update
    void Start()
    {
        playing = false;
        source.loop = true;
        playHints();
    }

    private void playHints()
    {
        playing = true;
        source.PlayOneShot(hints);
    }

    private void pauseAudio()
    {
        playing = false;
        source.Pause();
    }

    private void resumeAudio()
    {
        playing = true;
        source.UnPause();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playing)
        {
            StartCoroutine(interruptBad());
        }
    }

    IEnumerator interruptBad()
    {
        pauseAudio();
        source2.PlayOneShot(interruptsBad[Random.Range(0,interruptsBad.Length)]);
        yield return new WaitWhile(() => source.isPlaying);
        resumeAudio();
    }

    IEnumerator interruptGood()
    {
        pauseAudio();
        source.PlayOneShot(interruptsGood[Random.Range(0, interruptsGood.Length)]);
        yield return new WaitWhile(() => source.isPlaying);
        resumeAudio();
    }
}
