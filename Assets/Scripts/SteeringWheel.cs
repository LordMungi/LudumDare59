using UnityEngine;

public class SteeringWheel : MonoBehaviour
{
    [field: SerializeField] public float wheelPosition { get; private set; } = 0;

    [SerializeField] private float MAX_STEER; // Punto máximo al que llega el volante 

    private float mouseClickPosition = 0.0f;
    private bool isPressing = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        isPressing = true;
    }

    private void OnMouseUp()
    {
        isPressing = false;
    }

}
