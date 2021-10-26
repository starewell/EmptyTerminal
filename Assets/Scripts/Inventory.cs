using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	public static Inventory instance;
	void Awake() {
		if (instance != null) {
			Debug.LogWarning("More than one instance of Invetory found!");
			return;
		}
		instance = this;
	}

	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

	public List<Item> startingItems = new List<Item>();
    public List<Item> items = new List<Item>();

    void Start() {
    	foreach (Item item in startingItems) items.Add(item);
    	if (onItemChangedCallback != null) 
    		onItemChangedCallback.Invoke();
    }

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
