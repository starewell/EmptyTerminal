using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

	public Image icon;
	public Button button;
	public Text itemName;

	public GameObject[] full;
	public GameObject empty;

	Item item;

	void Start() {
		ClearSlot();
	}

	public void AddItem(Item newItem) {
		foreach(GameObject go in full) go.SetActive(true);
		empty.SetActive(false);

		item = newItem;
		icon.sprite = item.icon;
		itemName.text = newItem.name;		
	}

	public void ClearSlot() {
		foreach(GameObject go in full) go.SetActive(false);
		empty.SetActive(true);

		item = null;
		icon.sprite = null;
	}

	public void OnItemButton() {
		if (item != null) {
			item.Equip();
			InventoryUI.instance.ToggleUI();
		}
	}
}
