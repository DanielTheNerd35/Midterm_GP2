using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
   public enum ToolType {NONE, BUCKET, SCYTHE, SEED1, SEED2, SEED3, SEED4}
   public ToolType toolType = ToolType.NONE;
   public int ID;
   public GameObject itemPrefab;

   public virtual void UseItem(Transform playerTransform)
   {
      GameObject equipedItem = Instantiate(itemPrefab);
      equipedItem.transform.SetParent(playerTransform);
      equipedItem.transform.localPosition = new Vector2(-0.5f, -0.2f);
      Destroy(gameObject);
   }
}
