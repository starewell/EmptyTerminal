using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    public static EquipManager instance;
	void Awake() {
	    instance = this;
	}

    Inventory inventory;
    public Item currentEquipped;

    //public delegate void OnEquipChange(Item newItem, Item oldItem);
    //public OnEquipChange onEquipChange;

    public GameObject currentGO;
    public Transform itemHoldTransform;
   
    void Start() {
    	inventory = Inventory.instance;
    }
    
    void Update() {
    	if (Input.GetMouseButtonDown(1)) {
    		Unequip(true);
    		Debug.Log("Unequip");
    	}
    }

    public void Equip (Item newItem) {
    	Item prevEquipped = null;

		if(currentEquipped != null) {
			Unequip(true);
		}

		//if (onEquipChange != null) {
		//	onEquipChange.Invoke(newItem, prevEquipped);
		//}

    	currentEquipped = newItem;

    	GameObject newGO = Instantiate(newItem.go, itemHoldTransform);
    	newGO.transform.parent = itemHoldTransform.transform;

    	currentGO = newGO;
    }

    public void Unequip (bool returnToPlayer) {
    	if(currentEquipped != null) {
    		if(currentGO != null) {
    			Destroy(currentGO.gameObject);
    		}
    		if (returnToPlayer == true) {
    			Item prevEquipped = currentEquipped;
    			inventory.Add(prevEquipped);
    		}
    		
    		currentEquipped = null;

    	//	if (onEquipChange != null) {
		//		onEquipChange.Invoke(null, prevEquipped);
		//	}
    	}
    }

    public void Place(Item item, Transform placement) {
    	if(currentEquipped != null) {
    		if(currentEquipped == item) {
    			GameObject newGO = Instantiate<GameObject>(currentEquipped.go, placement);
    			newGO.transform.parent = placement.transform;
    			Unequip(false);

    			currentEquipped = null;
    		}
    	}
    }

    public void Unlock(Item item) {
    	if(currentEquipped !=null) {
    		if (currentEquipped == item) {
    			Unequip(true);

    			currentEquipped = null;
    		}
    	}
    }
}
