using UnityEngine;

public class ItemUnlock : Interactable {

	public Item item;	// Item to unlock with

	// When the player interacts with the item
	public override void Interact()
	{
		base.Interact();

		Place();
	}

	// Pick up the item
	void Place ()
	{
		Debug.Log("Unlocking with " + item.name);
		EquipManager.instance.Unlock(item);	// Removes from inventory, instantiates
	}

}