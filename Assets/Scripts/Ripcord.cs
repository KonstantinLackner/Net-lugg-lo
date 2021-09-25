using UnityEngine;
using UnityEngine.UIElements;

public class Ripcord : MonoBehaviour
{
    public LineRenderer line;
    private Vector3[] linePositions;

    private void Start()
    {
        linePositions = new[] { new Vector3(-3.1f, -1.78f, 0f), transform.position };
        line.SetPositions(linePositions);
    }

    private void OnMouseDrag()
    {
        float y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;


        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0f;
        gameObject.transform.position = position;
        linePositions[1] = gameObject.transform.position;
        line.SetPositions(linePositions);
    }
}
