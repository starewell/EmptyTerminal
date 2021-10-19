using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

	public static Inventory instance;

	void Awake() {
		if (instance != null) {
			Debug.LogWarning("More than one instance of Invetory found!");
			return;
		}
		instance = this;
	}


    public List<Item> items = new List<Item>();

    public void Add(Item item) {
    	items.Add(item);

    	if (onItemChangedCallback != null) 
    		onItemChangedCallback.Invoke();
    	
    }

    public void Remove(Item item) {
    	items.Remove(item);

    	if (onItemChangedCallback != null) 
    		onItemChangedCallback.Invoke();
    }
}
