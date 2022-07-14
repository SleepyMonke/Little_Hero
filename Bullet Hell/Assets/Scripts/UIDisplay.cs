using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] HealthScript playerHealth;

    [Header("Score")] 
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper sk;

    void Awake() 
    {
       sk = FindObjectOfType<ScoreKeeper>(); 
    }
    void Start()
    {
        healthSlider.maxValue = playerHealth.GetPlayerHealth();
    }

    void Update()
    {
        healthSlider.value = playerHealth.GetPlayerHealth();
        scoreText.text = sk.GetScore().ToString("000000000");
    }
}
