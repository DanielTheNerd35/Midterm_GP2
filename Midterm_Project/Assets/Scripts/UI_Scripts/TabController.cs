using UnityEngine;
using UnityEngine.UI;

public class TabController : MonoBehaviour
{
    public Image[] tabImages; // An array of all the tab images
    public GameObject[] pages; // An array for all the page images

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ActiveTab(0); // Sets the menu to always show the first tab when the player opens the menu
    }


    /* This is a for loop that will go through all the pages and deactivates them if they are not being used
    And! greys out the tabs that are not being used as well!*/
    public void ActiveTab(int tabNO)
    {
        for(int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
            tabImages[i].color = Color.grey;
        }
        pages[tabNO].SetActive(true);
        tabImages[tabNO].color = Color.white;
    }
}
