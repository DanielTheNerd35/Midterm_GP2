using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
   public ToolType toolType = ToolType.NONE;
   public SeedType seedType = SeedType.NONE;

   public int ID;
   public GameObject itemPrefab;

   public virtual void UseItem(Transform playerTransform)
   {
      GameObject equipedItem = Instantiate(itemPrefab);
      equipedItem.transform.SetParent(playerTransform);
      equipedItem.transform.localPosition = new Vector2(-0.5f, -0.2f);

      PlayerMovement player = playerTransform.GetComponent<PlayerMovement>();
      if (player != null)
      {
         player.SetHeldItem(toolType, seedType);
      }

      Destroy(gameObject);
   }
}
