using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] Handbrake handbrake;
    [SerializeField] SteeringWheel steeringWheel;

    [field: SerializeField] public float position { get; private set; } = 0.0f;
    [field: SerializeField] public float speed { get; private set; } = 0.0f;


    void Start()
    {
        
    }

    void Update()
    {
        if (handbrake.isPressed)
        {
            Brake();
        }
        Steer(steeringWheel.wheelPosition);
    }

    private void Brake()
    {
        // Frenar
    }

    private void Steer(float wheelPosition)
    {
        // Girar el volante
    }
}
