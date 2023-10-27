using UnityEngine;

public class TestDictionary : MonoBehaviour
{
    // Define a serializable dictionary to hold string-integer key-value pairs
    [SerializeField]
    private SerializableDictionary<string, int> myDictionary;

    void Start()
    {
        // Add some key-value pairs to the dictionary
        myDictionary.Add("Apple", 1);
        myDictionary.Add("Banana", 2);
        myDictionary.Add("Cherry", 3);

        // Log the count of key-value pairs in the dictionary
        Debug.Log("Dictionary count: " + myDictionary.Count);

        // Try to get a value from the dictionary and log it
        if (myDictionary.TryGetValue("Banana", out int value))
        {
            Debug.Log("Value for key 'Banana': " + value);
        }
        else
        {
            Debug.Log("Key 'Banana' not found in dictionary");
        }
    }
}
