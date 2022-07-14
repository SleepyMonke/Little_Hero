using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float movSpeed = 0.1f;
    [SerializeField] float leftPadding;
    [SerializeField] float rightPadding;
    [SerializeField] float topPadding;
    [SerializeField] float bottomPadding;
    Vector2 rawInput;
    Vector2 minBound;
    Vector2 maxBound;

    Shooter shooter;
    void Awake() 
    {
      shooter = GetComponent<Shooter>();
    }
    void Start()
    {
      InitBounds();
    }
    void Update()
    {
      move();
    }
    void InitBounds()
    {
      Camera mainCamera = Camera.main;
      minBound = mainCamera. ViewportToWorldPoint(new Vector2(0,0));
      maxBound = mainCamera. ViewportToWorldPoint(new Vector2(1,1)); 
    }
    void move()
    {
        Vector2 delta = rawInput*movSpeed*Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBound.x +leftPadding,maxBound.x -rightPadding);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBound.y+bottomPadding,maxBound.y-topPadding);
        transform.position = newPos;
    }
    void OnMove(InputValue value)
    {
      rawInput = value.Get<Vector2>();
    }
    void OnFire(InputValue value)
    {
      if(shooter != null)
      {
        shooter.isFiring = value.isPressed;
      }
    }
}
