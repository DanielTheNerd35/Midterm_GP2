using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
     public static TimeManager instance;

     private void Awake()
     {
        if (instance == null)
        {
            instance = this;
        }
     }

}
