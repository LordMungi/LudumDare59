using System;
using TMPro;
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
    [SerializeField] private Animator streetAnimation;

    [SerializeField] private float MAX_HORIZONTAL_POSITION; // Limite de posición horizontal del auto
    [SerializeField] private float HORIZONTAL_ACCELERATION; // Aceleración horizontal
    [SerializeField] private int MAX_LIVES; // Vidas

    [SerializeField] private TextMeshProUGUI carSpeedText;

    [field: SerializeField] public float speed { get; private set; } = 0.0f;
    [field: SerializeField] public int lives { get; private set; }

    private float maxSpeed;
    private float horizontalSpeed;


    void Start()
    {
        maxSpeed = INITIAL_SPEED;
        lives = MAX_LIVES;
    }

    void Update()
    {
        maxSpeed += Time.deltaTime;
        if (handbrake.isPressed)
        {
            Brake();
        }
        else
        {
            Unbrake();
        }
        Steer(steeringWheel.wheelPosition);
    }

    private void Brake()
    {
        // Frenar
        speed = Mathf.Max(speed - BRAKE_SPEED * Time.deltaTime, 0);
        carSpeedText.text = (int)speed + " KM";
        streetAnimation.speed = speed / maxSpeed;
    }
    private void Unbrake()
    {
        // Desfrenar 
        speed = Mathf.Min(speed + UNBRAKE_SPEED * Time.deltaTime, maxSpeed);
        carSpeedText.text = (int)speed + " KM";
        streetAnimation.speed = speed / maxSpeed;
    }

    private void Steer(float wheelPosition)
    {
        // Girar el volante
        if (Math.Abs(car.transform.position.x) == MAX_HORIZONTAL_POSITION)
            horizontalSpeed = 0;

        if (wheelPosition > horizontalSpeed)
            horizontalSpeed = Math.Min(horizontalSpeed + HORIZONTAL_ACCELERATION * Time.deltaTime, wheelPosition);
        else
            horizontalSpeed = Math.Max(horizontalSpeed - HORIZONTAL_ACCELERATION * Time.deltaTime, wheelPosition);

        if (horizontalSpeed > 0)
            horizontalSpeed = Math.Min(horizontalSpeed * speed, horizontalSpeed * INITIAL_SPEED) * 0.01f;
        else
            horizontalSpeed = Math.Max(horizontalSpeed * speed, horizontalSpeed * INITIAL_SPEED) * 0.01f;

        car.transform.position = new Vector3 ( Math.Clamp(car.transform.position.x + horizontalSpeed * Time.deltaTime, -MAX_HORIZONTAL_POSITION, MAX_HORIZONTAL_POSITION), car.transform.position.y, car.transform.position.z);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (lives > 0)
            lives--;
    }

}
