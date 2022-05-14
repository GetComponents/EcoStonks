using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Instance.ResetStats();
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void ResetStats()
    {
        MoneySpent = 0;
        TreesPlanted = 0;
        MonthsPassed = 0;
        Score = 0;
    }


    public float MoneySpent;
    public int TreesPlanted;
    public int MonthsPassed;

    public float Score;
    public float HighScore;
}
