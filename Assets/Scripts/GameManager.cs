using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pathLeft;
    [SerializeField] GameObject obstaclePathLeft;
    [SerializeField] RoadEntity sign;
    [SerializeField] RoadEntity obstacle;

    [SerializeField] float MIN_SIGN_COOLDOWN;
    [SerializeField] float MAX_SIGN_COOLDOWN;

    private float timeOfNextSign;
    private bool signQueued;
    private float timeOfNextObstacle;
    private bool obstacleQueued;

    private RoadEntity signInstance;
    private RoadEntity obstacleInstance;

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
            signInstance = SpawnRoadEntity(sign, pathLeft, QueueObstacle);
            signQueued = false;
        }

        if (obstacleQueued && timer >= timeOfNextObstacle)
        {
            obstacleInstance = SpawnRoadEntity(obstacle, obstaclePathLeft, QueueSign);
            obstacleQueued = false;
        }

    }

    void QueueSign()
    {
        signQueued = true;
        timeOfNextSign = timer + Random.Range(MIN_SIGN_COOLDOWN, MAX_SIGN_COOLDOWN); 
    }
    void QueueObstacle()
    {
        obstacleQueued = true;
        timeOfNextObstacle = timer + 3;
    }

    RoadEntity SpawnRoadEntity(RoadEntity prefab, GameObject path, RoadEntity.OnDestroy callback)
    {
        RoadEntity newRoadEntity;
        newRoadEntity = Instantiate(prefab);
        newRoadEntity.Init(path, callback);
        return newRoadEntity;
    }
}
