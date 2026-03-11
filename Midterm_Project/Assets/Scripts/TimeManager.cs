using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
     private List<PlantObject> plantObjects = new List<PlantObject>();

     public static TimeManager instance;

     private void Awake()
     {
        if (instance == null)
        {
            instance = this;
        }
     }

     public void RegisterPlant(PlantObject plantObject)
     {
        plantObjects.Add(plantObject);
     }

     public void UnregisterPlant(PlantObject plantObject)
     {
        plantObjects.Remove(plantObject);
     }

     public void Update()
     {
        foreach (PlantObject plantObject in plantObjects)
        {
            plantObject.CheckPlant(Time.deltaTime);
        }
        plantObjects.RemoveAll(X => X.HasMaxLevel());
     }
}
