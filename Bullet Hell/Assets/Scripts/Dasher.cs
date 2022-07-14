using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dasher : MonoBehaviour
{
    [SerializeField] float dashSpeed = 2f;
    [SerializeField] float dasherLifetime = 4f;
    [SerializeField] float minDashtime = 1f;
    [SerializeField] float maxDashtime = 3f;
    void Update()
    {
      StartCoroutine(Dash()); 
    }
    IEnumerator Dash()
    {
     // Random.seed = System.DataTime.Now.Millisecond;
      float dashDelay = Random.Range(minDashtime,maxDashtime);
      yield return new WaitForSeconds(dashDelay);
      Rigidbody2D rb = GetComponent<Rigidbody2D>();
      if(rb != null)
      {
          rb.velocity = transform.up * dashSpeed;
      }
      Destroy(gameObject, dasherLifetime);
    }
}
