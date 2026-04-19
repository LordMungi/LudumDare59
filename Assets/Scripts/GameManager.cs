using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] Car car;

    [SerializeField] GameObject pathLeft;
    [SerializeField] GameObject obstaclePathLeft;
    [SerializeField] GameObject obstaclePathRight;
    [SerializeField] RoadEntity turnRightSign;
    [SerializeField] RoadEntity turnLeftSign;
    [SerializeField] RoadEntity obstacle;

    [SerializeField] float MIN_SIGN_DISTANCE;
    [SerializeField] float MAX_SIGN_DISTANCE;

    [SerializeField] float OBSTACLE_COOLDOWN;

    private float distanceOfNextSign;
    private bool signQueued;
    private float distanceOfNextObstacle;
    private bool obstacleQueued;

    private RoadEntity signInstance;
    private RoadEntity obstacleInstance;

    private GameObject nextObstaclePath;

    private float distance;

    void Start()
    {
        distance = 0.0f;
        QueueSign();

    }
    void Update()
    {
        distance += car.speed * Time.deltaTime;

        if (signQueued && distance >= distanceOfNextSign)
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

        if (obstacleQueued && distance >= distanceOfNextObstacle)
        {
            obstacleInstance = SpawnRoadEntity(obstacle, nextObstaclePath, QueueSign);
            obstacleQueued = false;
        }

    }

    void QueueSign()
    {
        signQueued = true;
        distanceOfNextSign = distance + UnityEngine.Random.Range(MIN_SIGN_DISTANCE, MAX_SIGN_DISTANCE); 
    }
    void QueueObstacle()
    {
        obstacleQueued = true;
        distanceOfNextObstacle = distance + OBSTACLE_COOLDOWN;
    }

    RoadEntity SpawnRoadEntity(RoadEntity prefab, GameObject path, UnityAction callback)
    {
        RoadEntity newRoadEntity;
        newRoadEntity = Instantiate(prefab);
        newRoadEntity.Init(path, callback);
        return newRoadEntity;
    }
}
