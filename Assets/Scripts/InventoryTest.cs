using UnityEngine;
using TMPro;
public class InventoryTest : MonoBehaviour
{

    [SerializeField] GameObject panel;
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] GameObject testItem;
    [SerializeField] Transform content;
    [SerializeField] int numberOfItems;

   
    public void OnClickOpenInventory ()
    {
        Debug.Log("TEST");
        panel.SetActive (false);
        inventoryPanel.SetActive (true);
        DisplayInventory();
    }

    private void DisplayInventory()
    {
        for (int i = 0; i < numberOfItems; i++)
        {
            Instantiate(testItem, content);
            Debug.Log("I AM TRYING TO ADD TO INVENTORY");
        }
    }
}
