using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
   EnemySpawner es;
   WaveConfigSO wc;
   List<Transform> waypoints;
   int waypointIndex = 0;
   void Awake()
   {
     es = FindObjectOfType<EnemySpawner>();
   }
    void Start()
    {
      wc = es.GetCurrentWave();
      waypoints = wc.GetWayPoints();
      transform.position = waypoints[waypointIndex].position;
    }
    void Update()
    {
      FollowPoint();
    }
    void FollowPoint()
    {
        if(waypointIndex < waypoints.Count)
        {
          Vector3 targetPosition = waypoints[waypointIndex].position;
          float delta = wc.GetMoveSpeed() * Time.deltaTime;
          transform.position = Vector3.MoveTowards(transform.position,targetPosition,delta);
          if(transform.position ==  targetPosition)
          {
              waypointIndex++;
          }
        }
        else
        {
              Destroy(gameObject);
        }
        
    }
}
