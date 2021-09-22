using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    private float time;

    private float lastTime;

    private float seconds;

    private float minutes;
    
    private AudioSource source;
    
    public AudioClip ticSound;
    
    public Text timeScreen;
        
    // Start is called before the first frame update
    void Start()
    {
        time = 90;
        lastTime = time % 60;
        Debug.Log(lastTime);
        gameObject.AddComponent<AudioSource>();
        source = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        calculate();
    }

    void calculate()
    {
        time -= Time.deltaTime;
        seconds = time % 60;
        minutes = time / 60;
        
        // Only works for times < 60
        if (lastTime - seconds >= 1)
        {
            Debug.Log(Time.deltaTime);
            source.PlayOneShot(ticSound);
            lastTime = seconds;
        }
        
        timeScreen.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
