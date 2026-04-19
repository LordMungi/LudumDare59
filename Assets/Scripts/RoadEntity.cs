using System.Collections.Generic;
using UnityEngine;

public class RoadEntity : MonoBehaviour
{
    [SerializeField] float SPEED;

    Queue<Transform> pathQueue;
    public delegate void OnDestroy();
    OnDestroy onDestroy; 

    public void Init(GameObject path, OnDestroy callback)
    {
        pathQueue = CreatePathQueue(path);
        transform.position = pathQueue.Peek().position;

        onDestroy = callback;
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
            onDestroy();
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
