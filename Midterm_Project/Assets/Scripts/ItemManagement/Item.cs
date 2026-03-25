using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
   public int ID;
   public string Name;
   public GameObject itemPrefab;
   //[SerializeField] private Transform player;

   public virtual void UseItem(Transform playerTransform)
   {
      Debug.Log("Using item " + Name);
      GameObject equipedItem = Instantiate(itemPrefab);
      equipedItem.transform.SetParent(playerTransform);
      equipedItem.transform.localPosition = new Vector2(-0.5f, -0.2f);
   }
}
