using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

	public Image icon;
	public Image empty;
	public Button button;

	Item item;

	void Start() {
		ClearSlot();
	}

	public void AddItem(Item newItem) {
		item = newItem;

		icon.sprite = item.icon;
		icon.enabled = true;
		button.interactable = true;
		empty.enabled = false;
	}

	public void ClearSlot() {
		item = null;

		icon.sprite = null;
		icon.enabled = false;
		button.interactable = true;
		empty.enabled = true;
	}

	public void OnItemButton() {
		Inventory.instance.Remove(item);
	}
}
