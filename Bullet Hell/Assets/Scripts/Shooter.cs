using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float firingRate = 1f;

    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float shootRandomness = 0.5f;
    [SerializeField]float minShootDelay = 0.3f;
    Coroutine firing;

    SoundEffects se;

    void Awake() 
    {
      se = FindObjectOfType<SoundEffects>();
    }

    [HideInInspector]public bool isFiring;
    void Start()
    {
      if(useAI)
      {
          isFiring = true;
      }
    }

    void Update()
    {
        Fire();
    }
 
   void Fire()
   {
       if(isFiring && firing == null)
       {
         firing = StartCoroutine(FireContinuosly());
       }
       else if (!isFiring && firing != null)
       {
           StopCoroutine(firing);
           firing = null;
       }
   }
   IEnumerator FireContinuosly()
   {
     while(true)
     {
         GameObject instance = Instantiate(projectilePrefab,
                                            transform.position,
                                             Quaternion.identity);
          Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
          if(rb !=null)
          {
              rb.velocity = transform.up * projectileSpeed;
          }                                   
          Destroy(instance,projectileLifetime);
          se.PlayShootingClip();
          float shootDelay = Random.Range(firingRate-shootRandomness, firingRate+shootRandomness);
          yield return new WaitForSeconds(Mathf.Clamp(shootDelay,minShootDelay,float.MaxValue));
     }
   }
}
