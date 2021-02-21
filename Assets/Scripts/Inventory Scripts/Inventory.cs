using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory _instance;

    void Awake()
    {
        if(_instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        _instance = this;
    }

    public delegate void OnItemChanged();

    public OnItemChanged _onItemChangedCallback;

    public int _inventorySpace = 20;
    public List<Item> _items = new List<Item>();

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if(_items.Count >= _inventorySpace)
            {
                Debug.Log("Inventory is full.");
                return false;
            }

            _items.Add(item);

            if(_onItemChangedCallback != null)
            {
                _onItemChangedCallback.Invoke();
            }
        }

        return true;
    }

    public void Remove(Item item)
    {
        _items.Remove(item);

        if (_onItemChangedCallback != null)
        {
            _onItemChangedCallback.Invoke();
        }
    }
}
