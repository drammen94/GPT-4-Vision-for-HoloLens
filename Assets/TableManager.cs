using System.Collections.Generic;
using UnityEngine;
using TMPro; // Make sure to include this if you're using TextMeshPro for text rendering

public class TableManager : MonoBehaviour
{
    public GameObject rowPrefab; // Assign this in the inspector with your row prefab

    // Start is used for initialization
    void Start()
    {
        // Example data to test the table
        List<(string, string, int)> testData = new List<(string, string, int)>
        {
            ("001", "Item A", 10),
            ("002", "Item B", 20),
            // Add more test data as needed
        };

        UpdateTable(testData);
    }

    // Method to update the table with new data
    public void UpdateTable(List<(string itemId, string itemName, int quantity)> newData)
    {
        // Clear existing rows except the header
        foreach (Transform child in transform)
        {
            if (child != transform.GetChild(0)) // Assuming the first child is the header
                Destroy(child.gameObject);
        }

        // Populate the table with new data
        foreach (var (itemId, itemName, quantity) in newData)
        {
            CreateRow(itemId, itemName, quantity);
        }
    }

    // Method to create a new row in the table
    private void CreateRow(string itemId, string itemName, int quantity)
    {
        GameObject newRow = Instantiate(rowPrefab, transform);
        TextMeshProUGUI[] texts = newRow.GetComponentsInChildren<TextMeshProUGUI>();
        if (texts.Length >= 1)
        {
            texts[0].text = itemId;
            texts[1].text = itemName;
            texts[2].text = quantity.ToString();
        }
    }
}
