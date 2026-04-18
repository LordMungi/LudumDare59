using System;
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
        if (isPressing)
        {
            wheelPosition = Math.Clamp((Input.mousePosition.x - mouseClickPosition), -MAX_STEER, MAX_STEER);
            //Rotar el volante
            transform.rotation = Quaternion.Euler(0, 0, -wheelPosition);
        }

    }

    private void OnMouseDown()
    {
        //Guardo posicion del mouse
        mouseClickPosition = Input.mousePosition.x;
        isPressing = true;
    }

    private void OnMouseUp()
    {
        isPressing = false;
    }

}
