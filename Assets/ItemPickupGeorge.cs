
using UnityEngine;

public class ItemPickupGeorge : Interactable
{

    public Item item;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Pickin up " + item.name +".");
        // add item to invnetory
        bool wasPickedUp = InventoryGeorge.instance.Add(item);
        if (wasPickedUp)
            Destroy(gameObject);
    }
        
}
