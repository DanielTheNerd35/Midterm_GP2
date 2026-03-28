using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

     public static GameManager instance;

     public OnPlantHarvested onPlantHarvested;
     public OnScoreUpdated onScoreUpdated;

     private Dictionary<SeedType, int> currentScore;

     private float timer;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        onPlantHarvested += OnPlantHarvested;

        ResetGame();
    }

    private void ResetGame()
    {
        if(currentScore == null)
        {
            currentScore = new Dictionary<SeedType, int> ();
        }

        foreach (SeedType type in SeedType.GetValues(typeof(SeedType)))
        {
            if (type == SeedType.NONE)
            {
                continue;
            }
            else if (!currentScore.ContainsKey(type))
            {
                currentScore.Add(type, 0);
            }
            else 
            {
                currentScore[type] = 0;
            }
        }
    }

    private void OnPlantHarvested(SeedType seed)
    {
        currentScore[seed] += 1;
        onScoreUpdated?.Invoke(currentScore);
    }

    void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;    
        }
    }

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
