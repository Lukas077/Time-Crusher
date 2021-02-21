using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image _icon;
    public Button removeButton;

    Item _item;

    public void AddItem(Item newItem)
    {
        _item = newItem;
        _icon.sprite = _item.icon;
        _icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        _item = null;

        _icon.sprite = null;
        _icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory._instance.Remove(_item);
    }

    public void UseItem()
    {
        if(_item != null)
        {
            _item.Use();
        }
    }
}
