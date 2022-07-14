using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovments : MonoBehaviour
{
   [SerializeField] float moveSpeed = 0.5f;
    void Update()
    {
      RandomMove();
    }
    

    void RandomMove()
    {
      Rigidbody2D rb = GetComponent<Rigidbody2D>();
      int random = Random.Range(0,3);
      if(rb != null)
      {
      if(random == 1 ||transform.position.x <= -1.52)
      {
          rb.velocity = transform.right * moveSpeed;
      }
      else if(random == 2|| transform.position.x >= 1.3 )
      {
        rb.velocity = transform.right * -moveSpeed;
      }
    }
  } 
}
