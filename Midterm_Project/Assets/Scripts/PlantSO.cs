using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlantSO", menuName = "Scriptable Objects/PlantSO")]
public class PlantSO : ScriptableObject
{
    public string plantName;
    public List<GameObject> PlantPrefabs;

    public float CropTime;
    public int CropReward;

    public int MaxStage {get {return PlantPrefabs.Count;}}

    public GameObject GetPlantByStage(int stage)
    {
        if (stage >= MaxStage)
        {
            return null;
        }
        return PlantPrefabs[stage];
    }
    
}
