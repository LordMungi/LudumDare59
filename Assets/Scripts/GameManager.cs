using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Sign;
    [SerializeField] GameObject PathLeft;

    [SerializeField] float SIGN_SPEED;

    private float timeOfNextSign;
    private bool signQueued;
    private float timeOfNextObstacle;
    private bool obstacleQueued;

    private GameObject signInstance;

    Queue<Transform> pathLeft;

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

        FollowPath(pathLeft, signInstance);
    }

    void QueueSign()
    {
        signQueued = true;
        timeOfNextSign = timer + 5;
    }

    void SpawnSign()
    {
        signQueued = false;
        signInstance = Instantiate(Sign);

        pathLeft = CreatePathQueue(PathLeft);
    }

    private void FollowPath(Queue<Transform> path, GameObject sign)
    {
        if (sign != null)
        {
            sign.transform.position = Vector3.MoveTowards(sign.transform.position, path.Peek().position, Time.deltaTime * SIGN_SPEED);
            if (sign.transform.position == path.Peek().position)
            {
                path.Dequeue();
            }
            if (path.Count == 0)
            {
                Destroy(sign);
                QueueSign();
            }
        }
    }

    private Queue<Transform> CreatePathQueue(GameObject path)
    {
        Queue<Transform> pathQueue = new Queue<Transform>();
        foreach (Transform child in path.transform)
        {
            pathQueue.Enqueue(child);
        }
        return pathQueue;
    }
}
