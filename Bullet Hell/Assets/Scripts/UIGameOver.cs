using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
  [SerializeField] TextMeshProUGUI scoreText;
  ScoreKeeper sk;
    void Awake() 
    {
      sk = FindObjectOfType<ScoreKeeper>();  
    }
    void Start() 
    {
      scoreText.text = "Score:" + sk.GetScore();  
    }
}
