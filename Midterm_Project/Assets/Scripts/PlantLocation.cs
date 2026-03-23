using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantLocation : MonoBehaviour
{
    public ItemType itemType;
    private bool playerInRange = false;
    private HotbarController hotbar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hotbar = FindObjectOfType<HotbarController>();
    }

    public void OnTriggerEnter2D (Collider2D collision)
    {
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
        if (player == null)
        {
            return;
        }
               
        playerInRange = true;
    }

    public void OnTriggerExit2D (Collider2D collision)
    {
        playerInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerInRange) return;

        if (hotbar.currentlyUsedItem.ID == 2)
        {
            Debug.Log("Has WaterCan!");
        }
    }
}

public enum ItemType
{
    WaterCan,
    Seed,
    Tool
}
