using UnityEngine;

public class ItemPlace : Interactable {

	public Item item;	// Item to place
	public Transform placement;

	// When the player interacts with the item
	public override void Interact()
	{
		base.Interact();

		Place();
	}

	// Pick up the item
	void Place ()
	{
		Debug.Log("Placing " + item.name);
		EquipManager.instance.Place(item, placement);	// Removes from inventory, instantiates
	}

}