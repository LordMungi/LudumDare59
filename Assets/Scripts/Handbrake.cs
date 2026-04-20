using UnityEngine;

public class Handbrake : MonoBehaviour
{
    [field: SerializeField] public bool isPressed { get; private set; } = false;
    [SerializeField] private SpriteRenderer brake;
    [SerializeField] private Sprite brakeOn;
    [SerializeField] private Sprite brakeOff;

   void Start()
    {
    }

    void Update()
    {
    }

    private void OnMouseDown()
    {
        isPressed = true;
        brake.sprite = brakeOn;
    }

    private void OnMouseUp()
    {
        isPressed = false;
        brake.sprite = brakeOff;
    }
}
