using UnityEngine;
using System.Collections.Generic;

// Define a serializable dictionary that can be used within the Unity inspector
[System.Serializable]
public class SerializableDictionary<TKey, TValue> : ISerializationCallbackReceiver
{
    [SerializeField]
    private List<TKey> keys = new List<TKey>();  // List to hold the keys for serialization

    [SerializeField]
    private List<TValue> values = new List<TValue>();  // List to hold the values for serialization

    private Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();  // The actual dictionary data

    // Method called by Unity before the object is serialized
    public void OnBeforeSerialize()
    {
        keys.Clear();  // Clear the keys list
        values.Clear();  // Clear the values list

        // Populate the keys and values lists from the dictionary
        foreach (var kvp in dictionary)
        {
            keys.Add(kvp.Key);
            values.Add(kvp.Value);
        }
    }

    // Method called by Unity after the object has been deserialized
    public void OnAfterDeserialize()
    {
        dictionary = new Dictionary<TKey, TValue>();  // Create a new dictionary

        // Populate the dictionary from the keys and values lists
        for (int i = 0; i < keys.Count; i++)
        {
            dictionary.Add(keys[i], values[i]);
        }
    }

    // Indexer to allow getting and setting values via keys, mimicking dictionary behavior
    public TValue this[TKey key]
    {
        get { return dictionary[key]; }  // Get the value for the specified key
        set { dictionary[key] = value; }  // Set the value for the specified key
    }

    // Method to add a new key-value pair to the dictionary
    public void Add(TKey key, TValue value)
    {
        dictionary.Add(key, value);
    }

    // Method to try to get a value for a specified key
    public bool TryGetValue(TKey key, out TValue value)
    {
        return dictionary.TryGetValue(key, out value);
    }

    // Property to get the count of key-value pairs in the dictionary
    public int Count
    {
        get { return dictionary.Count; }
    }
}
