using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoadEntity : MonoBehaviour
{
    [SerializeField] float SPEED;

    Queue<Transform> pathQueue;
    public Action onDestroyed;

    [SerializeField] private UnityEvent onDes;

    public void Init(GameObject path, UnityAction callback)
    {
        pathQueue = CreatePathQueue(path);
        transform.position = pathQueue.Peek().position;

        onDes.AddListener(callback);
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
            onDes.Invoke();
            onDes.RemoveAllListeners();
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
