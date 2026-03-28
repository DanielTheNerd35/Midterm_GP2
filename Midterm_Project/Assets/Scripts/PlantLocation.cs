using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantLocation : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite[] growingGraphics;
    public Sprite bluePlant;
    public Sprite pinkPlant;
    public Sprite purplePlant;
    public Sprite redPlant;

    public SpriteRenderer waterIcon;

    private SeedType plantedSeed = SeedType.NONE;

    public const float seedGrowthTime = 3f;

    private int seedStep = 0;
    private float seedTimer = -1;
    private bool _needsWater = false;

    public enum PlantState { NONE, UNPLANTED, GROWING, HARVESTABLE }
    public PlantState currentState = PlantState.UNPLANTED;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (sr == null)
        {
            sr = GetComponent<SpriteRenderer>();
        }

        ResetLocation();
        SetNeedsWater (false);
    }

    private void ResetLocation()
    {
        currentState = PlantState.UNPLANTED;
        plantedSeed = SeedType.NONE;
        SetGrowingStep (0);
    }

    public void OnTriggerEnter2D (Collider2D collision)
    {
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
        if (player == null)
        {
            return;
        }

        ToolType tool = player.GetHeldTool();

        if (tool == ToolType.NONE)
        {
            Debug.Log("player has no tool");
            return;
        }

        switch(currentState)
        {
            case PlantState.UNPLANTED:
                if (tool == ToolType.SEED)
                {
                    SeedType seed = player.GetHeldSeed();
                    
                    if (seed != SeedType.NONE)
                    {
                        PlantSeed(seed);
                        player.SetHeldItem(ToolType.NONE, SeedType.NONE);
                    }
                }
                else 
                {
                    Debug.Log("No seed type assigned!");
                }
                break;
            case PlantState.GROWING:
                if (tool == ToolType.BUCKET)
                {
                    if (_needsWater)
                    {
                        SetNeedsWater (false);
                    }
                }
                break;
            case PlantState.HARVESTABLE:
                if (tool == ToolType.SCYTHE)
                {
                    HarvestLocation();
                }
                break;
        }

    }

    private void PlantSeed (SeedType seed)
    {
        currentState = PlantState.GROWING;
        plantedSeed = seed;
        SetGrowingStep (1);
        SetNeedsWater (true);
    }

    private void SetGrowingStep (int newStep)
    {
        seedStep = newStep;
        seedTimer = seedGrowthTime;

        sr.sprite = growingGraphics[seedStep];
        SetNeedsWater (true);
    }

    private void AdvanceSeedStep()
    {
        if (seedStep < growingGraphics.Length -1)
        {
            seedStep += 1;
            SetGrowingStep (seedStep);
        }
        else if (seedStep == growingGraphics.Length -1)
        {
            SetHarvestable();
        }
    }

    private void SetNeedsWater (bool needsWater)
    {
        _needsWater = (needsWater);
        waterIcon.enabled = needsWater;
    }

    private void SetHarvestable()
    {
        if (plantedSeed == SeedType.BLUE)
        {
            sr.sprite = bluePlant;
        }
        if (plantedSeed == SeedType.PINK)
        {
            sr.sprite = pinkPlant;
        }
        if (plantedSeed == SeedType.PURPLE)
        {
            sr.sprite = purplePlant;
        }
        if (plantedSeed == SeedType.RED)
        {
            sr.sprite = redPlant;
        }

        currentState = PlantState.HARVESTABLE;
    }

    private void HarvestLocation()
    {
        GameManager.instance.onPlantHarvested?.Invoke(plantedSeed);
        ResetLocation();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == PlantState.GROWING)
        {
            if (!_needsWater)
            {
                seedTimer -= Time.deltaTime;
                if (seedTimer <= 0)
                {
                    AdvanceSeedStep();
                }
            }
        }
    }
}
