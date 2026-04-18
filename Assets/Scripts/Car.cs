using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] Handbrake handbrake;
    [SerializeField] SteeringWheel steeringWheel;

    [SerializeField] private float INITIAL_SPEED; // Velocidad inicial al empezar el juego
    [SerializeField] private float BRAKE_SPEED; // Velocidad de desaceleración al usar el freno
    [SerializeField] private float UNBRAKE_SPEED; // Aceleración al dejar de frenar

    [SerializeField] private float MAX_HORIZONTAL_POSITION; // Limite de posición horizontal del auto
    [SerializeField] private float MAX_HORIZONTAL_SPEED; // Acelerazión máxima horizontal

    [field: SerializeField] public float speed { get; private set; } = 0.0f;

    private float horizontalSpeed;

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
