using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    public static QuestController Instance {get; private set;}
    public List<QuestProgress> activateQuests = new();
    private QuestUI questUI;
    public InventoryController inventoryController;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        questUI = FindObjectOfType<QuestUI>();
        inventoryController = GetComponent<InventoryController>();
    }

    void Start()
    {
        inventoryController.OnInventoryChanged += CheckInventoryForQuest;
    }

    public void CheckInventoryForQuest()
    {
        Dictionary<int, int> itemCounts = inventoryController.GetItemCounts();
        foreach(QuestProgress quest in activateQuests)
        {
            foreach(QuestObjective questObjective in quest.objectives)
            {
                if (questObjective.type != ObjectiveType.CollectItem) continue;
                if (!int.TryParse(questObjective.objectiveID, out int itemID)) continue;
                
                int newAmount = itemCounts.TryGetValue(itemID, out int count) ? Mathf.Min(count, questObjective.requiredAmount) : 0;

                if(questObjective.currentAmount != newAmount)
                {
                    questObjective.currentAmount = newAmount;
                }
            }
        }

        questUI.UpdateQuestUI();
    }
    

}
