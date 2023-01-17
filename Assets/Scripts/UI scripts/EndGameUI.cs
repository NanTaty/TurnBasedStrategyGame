using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] private int enemiesRemaining;
    [SerializeField] private int squadMembersRemaining;
    [SerializeField] private Button returnToMenuButton;
    [SerializeField] private Button restartLevelButton;
    [SerializeField] private GameObject endGameUI;
    [SerializeField] private GameObject gameOverUI;
    void Start()
    {
        Unit.OnAnyUnitDead += Unit_OnAnyUnitDead;
        endGameUI.SetActive(false);
        gameOverUI.SetActive(false);
        
        returnToMenuButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
        });
        
        restartLevelButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
        
    }

    private void Awake()
    {
        
    }

    void Update()
    {
        
    }

    private void Unit_OnAnyUnitDead(object sender, EventArgs e)
    {
        Unit unit = sender as Unit;
        if (unit.IsEnemy())
        {
            enemiesRemaining--;
            if (enemiesRemaining <= 0)
            {
                endGameUI.SetActive(true);
            }
        }
        else
        {
            squadMembersRemaining--;
            if (squadMembersRemaining <= 0)
            {
                gameOverUI.SetActive(true);
            }
        }
    }
    
}
