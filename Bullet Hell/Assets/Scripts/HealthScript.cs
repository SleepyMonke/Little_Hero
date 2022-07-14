using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
  [SerializeField] bool isPlayer;
   [SerializeField] bool isBoss;
  [SerializeField] int health = 50;
  [SerializeField] ParticleSystem hitEffect;
  [SerializeField] bool applyCameraShake;
  [SerializeField]int score;
  CameraShake cs;
  SoundEffects se;
  ScoreKeeper sk;
  LevelManager lm;

  void Awake() 
  {
    cs = Camera.main.GetComponent<CameraShake>(); // camera.main has find component inbuilt
    se = FindObjectOfType<SoundEffects>();
    sk = FindObjectOfType<ScoreKeeper>();
    lm = FindObjectOfType<LevelManager>();
  }

 void OnTriggerEnter2D(Collider2D other) 
 {
   DamageDealer dd = other.GetComponent<DamageDealer>();
    if(dd != null)
    {
       TakeDamage(dd.GetDamage());
       PlayHitEffct();
       ShakeCamera();
       se.PlayHittingClip();
       dd.Hit();
    }   
 }
 void TakeDamage(int damage)
 {
     health -= damage;
     if(health <= 0)
     {
        Die();
     }
 }
void Die()
{
   if(isPlayer)
   {
     
      lm.LoadGameOver();
   }
   else if(isBoss)
   {
      lm.LoadLevelClear();
   }
   
   else
   {
      sk.IncreaseScore(score);
   }
   Destroy(gameObject);
}
 void PlayHitEffct()
    {
       if(hitEffect != null)
       {
          ParticleSystem instance = Instantiate(hitEffect,transform.position, Quaternion.identity);
          Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMin);
       }
    }
    void ShakeCamera()
    {
       if(cs != null && applyCameraShake)
       {
          cs.Play();
       }
    }
    public int GetPlayerHealth()
    {
       return health;
    }
}

