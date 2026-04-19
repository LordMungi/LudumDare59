using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Sign;

    private float timeOfNextSign;
    private bool signQueued;
    private float timeOfNextObstacle;
    private bool obstacleQueued;

    private GameObject signInstance;

    private float timer;

    void Start()
    {
        timer = 0.0f;
        QueueSign();
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (signQueued && timer >= timeOfNextSign)
        {
            SpawnSign();
        }
    }

    void QueueSign()
    {
        timeOfNextSign = timer + 5;
        signQueued = true;
    }

    void SpawnSign()
    {
        signInstance = Instantiate(Sign);
        signQueued = false;
        QueueSign();
    }
}
