using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Car : MonoBehaviour
{
    [SerializeField] Handbrake handbrake;
    [SerializeField] SteeringWheel steeringWheel;
    [SerializeField] Camera car;

    [SerializeField] private float INITIAL_SPEED; // Velocidad inicial al empezar el juego
    [SerializeField] private float BRAKE_SPEED; // Velocidad de desaceleración al usar el freno
    [SerializeField] private float UNBRAKE_SPEED; // Aceleración al dejar de frenar

    [SerializeField] private float MAX_HORIZONTAL_POSITION; // Limite de posición horizontal del auto
    [SerializeField] private float MAX_HORIZONTAL_SPEED; // Acelerazión máxima horizontal

    [field: SerializeField] public float speed { get; private set; } = 0.0f;

    private float horizontalSpeed;

    void Start()
    {
       speed = INITIAL_SPEED;
    }

    void Update()
    {
        if (handbrake.isPressed)
        {
            Brake();
        }
        else
        {
            Unbrake();
        }
        Steer(steeringWheel.wheelPosition);

        Debug.Log(speed);
    }

    private void Brake()
    {
        // Frenar
        speed = Mathf.Max(speed - BRAKE_SPEED * Time.deltaTime, 0);
    }
    private void Unbrake()
    {
        // Desfrenar 
        speed = Mathf.Min(speed + UNBRAKE_SPEED * Time.deltaTime, INITIAL_SPEED);
    }

    private void Steer(float wheelPosition)
    {
        // Girar el volante
    }
}
