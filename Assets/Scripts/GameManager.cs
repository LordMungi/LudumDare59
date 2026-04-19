using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject PathLeft;
    [SerializeField] Sign sign;

    [SerializeField] float MIN_SIGN_COOLDOWN;
    [SerializeField] float MAX_SIGN_COOLDOWN;

    private float timeOfNextSign;
    private bool signQueued;
    private float timeOfNextObstacle;
    private bool obstacleQueued;

    private Sign signInstance;

    private float timer;

    void Start()
    {
        timer = 0.0f;
        QueueSign();

    }
    void Update()
    {
        timer += Time.deltaTime;

        if (signInstance == null && !signQueued)
        {
            QueueSign();
        }

        if (signQueued && timer >= timeOfNextSign)
        {
            SpawnSign();
        }

    }

    void QueueSign()
    {
        signQueued = true;
        timeOfNextSign = timer + 5;
    }

    void SpawnSign()
    {
        signQueued = false;
        signInstance = Instantiate(sign);
        signInstance.path = PathLeft;
    }


}
