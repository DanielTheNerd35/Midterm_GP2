using UnityEngine;

public class MenuController : MonoBehaviour
{
    /* Pretty simple. Just sets the menuUI to deactive, then sets it active with the push of a button.
    */
    public GameObject menuCanvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuCanvas.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            menuCanvas.SetActive(!menuCanvas.activeSelf);
        }
    }
}
