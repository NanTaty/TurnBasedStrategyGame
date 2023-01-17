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
    [SerializeField] private Button returnToMenuButton;
    [SerializeField] private TextMeshProUGUI endGameText;
    [SerializeField] private GameObject endGameUI;
    void Start()
    {
        Unit.OnAnyUnitDead += Unit_OnAnyUnitDead;
        Debug.Log(enemiesRemaining);
        endGameUI.SetActive(false);
        
        returnToMenuButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
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
    }
    
}
