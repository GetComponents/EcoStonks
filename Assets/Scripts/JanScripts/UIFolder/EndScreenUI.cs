using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScreenUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI treesPlantedText, monthsSurvivedText, moneySpentText, scoreText, highScoreText;

    private void Start()
    {
        treesPlantedText.text = $"Trees Planted: {PlayerStats.Instance.TreesPlanted}";
        monthsSurvivedText.text = $"Months Survived: {PlayerStats.Instance.MonthsPassed}";
        moneySpentText.text = $"Money Spent: {PlayerStats.Instance.MoneySpent}";
        PlayerStats.Instance.Score = (PlayerStats.Instance.MoneySpent / PlayerStats.Instance.MonthsPassed) + (PlayerStats.Instance.MonthsPassed * PlayerStats.Instance.TreesPlanted);
        scoreText.text = $"Score: {PlayerStats.Instance.Score}";
        if (PlayerStats.Instance.Score > PlayerStats.Instance.HighScore)
        {
            PlayerStats.Instance.HighScore = PlayerStats.Instance.Score;
        }
        highScoreText.text = $"Highscore: {PlayerStats.Instance.HighScore}";
    }    
}
