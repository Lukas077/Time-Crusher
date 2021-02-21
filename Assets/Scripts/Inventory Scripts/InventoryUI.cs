using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform _itemsParent;
    public GameObject _inventoryUI;
    Inventory _inventory;

    InventorySlot[] _slots;

    // Start is called before the first frame update
    void Start()
    {
        _inventory = Inventory._instance;
        _inventory._onItemChangedCallback += UpdateUI;

        _slots = _itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            _inventoryUI.SetActive(!_inventoryUI.activeSelf);
        }
    }

    void UpdateUI()
    {
        //Debug.Log("UPDATE INVENTORY UI");
        for(int i = 0; i < _slots.Length; i++)
        {
            if (i < _inventory._items.Count)
            {
                _slots[i].AddItem(_inventory._items[i]);
            }
            else
            {
                _slots[i].ClearSlot();
            }
        }
    }
}
