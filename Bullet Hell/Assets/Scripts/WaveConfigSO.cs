using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
  [SerializeField] List<GameObject> enemyPrefabs;
  [SerializeField] Transform pathPrefab;
  [SerializeField] float movSpeed;
  [SerializeField] float spawnDelay = 1f;
  [SerializeField] float spawnRandomness = 0.1f;
  [SerializeField] float minSpawnDelay= 0.2f;
  public float GetMoveSpeed()
  {
      return movSpeed;
  }
  public Transform GetStartingWaypoint()
  {
      return pathPrefab.GetChild(0);
  }
  public List<Transform> GetWayPoints()
  {
      List<Transform> waypoints = new List<Transform>();
      foreach(Transform child in pathPrefab)
      {
          waypoints.Add(child);
      }
      return waypoints;
  }
  public int GetEnemyCount()
  {
     return enemyPrefabs.Count;
  }
  public GameObject GetEnemyPrefab(int Index)
  {
    return enemyPrefabs[Index];
  }
  public float GetSpawnDelay()
  {
    float spawnTime = Random.Range(spawnDelay-spawnRandomness, spawnDelay+spawnRandomness);
    return Mathf.Clamp(spawnTime,minSpawnDelay,float.MaxValue);
  }
}
