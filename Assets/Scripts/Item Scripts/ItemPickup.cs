using UnityEngine;

public class ItemPickup : Interactable
{
    public Item _item;
    //public Animator _animator;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        //_animator.SetBool("Take", true);
        //Debug.Log("Picking up " + _item.name);
        bool wasPickedUp = Inventory._instance.Add(_item);

        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }
}
