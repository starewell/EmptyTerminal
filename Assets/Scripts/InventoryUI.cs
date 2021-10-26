using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
	public static InventoryUI instance;
	void Awake() {
	    instance = this;
	}

	public Transform itemsParent;

    Inventory inventory;

    InventorySlot[] slots;
    public LockMouse mouseLock;
    public GameObject inventoryUI;

    void Start() {
    	inventory = Inventory.instance;
    	inventory.onItemChangedCallback += UpdateUI;

    	slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    	inventoryUI.SetActive(false);
    	Update();
    }

    void Update() {
    	if(Input.GetButtonDown("InventoryB")) {
    		ToggleUI();
    	}
    }

    public void ToggleUI() {
    	inventoryUI.SetActive(!inventoryUI.activeSelf);
    	mouseLock.ToggleLock();
    	Time.timeScale = 1.0f - Time.timeScale;
    }

    void UpdateUI() {
    	for (int i = 0; i < slots.Length; i++) {
    		if (i < inventory.items.Count) {
    			slots[i].AddItem(inventory.items[i]);
   	 		} else {
    			slots[i].ClearSlot();
    		}
    	}
    }
}
