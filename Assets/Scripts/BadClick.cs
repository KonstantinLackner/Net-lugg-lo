using UnityEngine;

public class BadClick : MonoBehaviour
{
    private Heinz heinz;
    private bool clicked;
    
    // Start is called before the first frame update
    void Start()
    {
        clicked = false;
        heinz = GameObject.Find("AudioPlayer").GetComponent<Heinz>();
    }

    private void OnMouseDown()
    {
        if (!clicked)
        {
            clicked = true;
            heinz.interrupt();
        }
    }
}
