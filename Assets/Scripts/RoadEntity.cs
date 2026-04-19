using System.Collections.Generic;
using UnityEngine;

public class RoadEntity : MonoBehaviour
{
    [SerializeField] float SPEED;

    Queue<Transform> pathQueue;

    public void Init(GameObject path)
    {
        pathQueue = CreatePathQueue(path);
        transform.position = pathQueue.Peek().position;
    }

    void Start()
    {

    }

    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        transform.position = Vector3.MoveTowards(transform.position, pathQueue.Peek().position, Time.deltaTime * SPEED);
        if (transform.position == pathQueue.Peek().position)
        {
            pathQueue.Dequeue();
        }
        if (pathQueue.Count == 0)
        {
            Destroy(gameObject);
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
