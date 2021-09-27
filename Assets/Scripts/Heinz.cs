using System.Collections;
using UnityEngine;

public class Heinz : MonoBehaviour
{
    public AudioSource source;
    public AudioSource source2;
    public AudioClip hints;
    private bool playing;
    public AudioClip[] interruptsBad;
    
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

    public void interrupt()
    {
        StartCoroutine(interruptCoRoutine());
    }

    private IEnumerator interruptCoRoutine()
    {
        pauseAudio();
        yield return new WaitForSeconds(0.5f);
        source2.PlayOneShot(interruptsBad[Random.Range(0,interruptsBad.Length)]);
        yield return new WaitWhile(() => source2.isPlaying);
        yield return new WaitForSeconds(0.5f);
        resumeAudio();
    }
}
