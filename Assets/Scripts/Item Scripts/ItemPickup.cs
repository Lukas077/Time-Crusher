using UnityEngine;

public class ItemPickup : Interactable
{
    public Item _item;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {

        Debug.Log("Picking up " + _item.name);
        bool wasPickedUp = Inventory._instance.Add(_item);

        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }
}
