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
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void Init(GameObject path, UnityAction callback)
    {
        pathQueue = CreatePathQueue(path);
        transform.position = pathQueue.Peek().position;
        spriteRenderer.sortingOrder = (int)pathQueue.Peek().position.z;

        onDestroyed.AddListener(callback);
    }

    void Start()
    {
    }

    void Update()
    {

    }

    public void FollowPath(float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, pathQueue.Peek().position, Time.deltaTime * SPEED * speed * 0.1f);
        if (transform.position == pathQueue.Peek().position)
        {
            spriteRenderer.sortingOrder = (int)pathQueue.Peek().position.z;
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
