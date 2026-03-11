using UnityEngine;

public class PlantObject : MonoBehaviour
{
    [SerializeField] private PlantSO plant;

    private int currentStage;
    private float currentTime;
    private GameObject currentPlant;

    private void Start()
    {
        TimeManager.instance.RegisterPlant(this);
        currentPlant = Instantiate(plant.GetPlantByStage(currentStage), transform);
    }

    public void CheckPlant(float deltaTime)
    {
        currentTime += deltaTime;
        if (currentTime >= plant.CropTime)
        {
            currentStage++;
            currentTime = 0;
            Destroy(currentPlant);
            currentPlant = Instantiate(plant.GetPlantByStage(currentStage), transform);
            Debug.Log(plant.CropReward * currentStage);
        }
    }

    public bool HasMaxLevel()
    {
        return currentStage == plant.MaxStage;
    }
}
