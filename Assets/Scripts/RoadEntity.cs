using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoadEntity : MonoBehaviour
{
    [SerializeField] float SPEED;

    Queue<Transform> pathQueue;
    private float carSpeed;

    [SerializeField] private UnityEvent onDestroyed;

    public void Init(GameObject path, UnityAction callback, in float carSpeedRef)
    {
        pathQueue = CreatePathQueue(path);
        transform.position = pathQueue.Peek().position;
        carSpeed = carSpeedRef;

        onDestroyed.AddListener(callback);
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
        transform.position = Vector3.MoveTowards(transform.position, pathQueue.Peek().position, Time.deltaTime * SPEED * carSpeed * 0.1f);
        if (transform.position == pathQueue.Peek().position)
        {
            pathQueue.Dequeue();
        }
        if (pathQueue.Count == 0)
        {
            onDestroyed.Invoke();
            onDestroyed.RemoveAllListeners();
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
