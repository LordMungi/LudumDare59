using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] Handbrake handbrake;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (handbrake.isPressed)
        {
        }
    }
}
