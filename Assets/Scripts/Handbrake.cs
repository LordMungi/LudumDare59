using UnityEngine;

public class Handbrake : MonoBehaviour
{
    [field: SerializeField] public bool isPressed { get; private set; } = false;

    void Start()
    {
    }

    void Update()
    {
    }

    private void OnMouseDown()
    {
        isPressed = true;
    }

    private void OnMouseUp()
    {
        isPressed = false;
    }
}
