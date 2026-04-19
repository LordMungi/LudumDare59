using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pathLeft;
    [SerializeField] GameObject obstaclePathLeft;
    [SerializeField] GameObject obstaclePathRight;
    [SerializeField] RoadEntity turnRightSign;
    [SerializeField] RoadEntity turnLeftSign;
    [SerializeField] RoadEntity obstacle;

    [SerializeField] float MIN_SIGN_COOLDOWN;
    [SerializeField] float MAX_SIGN_COOLDOWN;

    private float timeOfNextSign;
    private bool signQueued;
    private float timeOfNextObstacle;
    private bool obstacleQueued;

    private RoadEntity signInstance;
    private RoadEntity obstacleInstance;

    private GameObject nextObstaclePath;

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
            if (Random.Range(0, 2) == 1)
            {
                signInstance = SpawnRoadEntity(turnRightSign, pathLeft, QueueObstacle);
                nextObstaclePath = obstaclePathLeft;
            }
            else
            {
                signInstance = SpawnRoadEntity(turnLeftSign, pathLeft, QueueObstacle);
                nextObstaclePath = obstaclePathRight;
            }

            signQueued = false;
        }

        if (obstacleQueued && timer >= timeOfNextObstacle)
        {
            obstacleInstance = SpawnRoadEntity(obstacle, nextObstaclePath, QueueSign);
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
