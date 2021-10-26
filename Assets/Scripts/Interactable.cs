using UnityEngine;
using UnityEngine.AI;
/*	
	This component is for all objects that the player can
	interact with such as collectables or objects. It is meant
	to be used as a base class.
*/

[RequireComponent(typeof(ColorOnHover))]
public class Interactable : MonoBehaviour {

	public bool interactOnce;
	public float radius = 2.5f;
	public Transform interactionTransform;
	public Progression progress = Progression.none;
	public int progressionIndex = 0;
	public bool locked = false;
	bool accessible;
	public Item key;

	ColorOnHover highlight;

	bool onClick = false;
	Transform player;

	bool hasInteracted = false;	// Have we already interacted with the object?

	void Start() {
		highlight = GetComponent<ColorOnHover>();
	}

	void Update () {

		//check whether interactable has been interacted with already, or restricted by this
		if(!interactOnce || (interactOnce && !hasInteracted)) {
			//check if player is holding key, update accessible bool
			if (locked) {
				if (EquipManager.instance.currentEquipped == key) accessible = true;
				else accessible = false;
			} else accessible = true;
		
			//check whether or not the click warrants an interaction
			if (onClick) {
				//player must be within wireframe gizmo
				float distance = Vector3.Distance(player.position, transform.position);
				if (distance <= radius) {
					//interact
					if (accessible) {
						highlight.Deactivate();
						Interact();
						hasInteracted = true;
					//locked
					} else {
						Debug.Log ("Locked");
					}
				}
			}		
		} else accessible = false;
		onClick = false;
	}

	//recieving input from MouseLook
	public void OnClicked(Transform playerTransform) {
		onClick = true;
		player = playerTransform;
		//Debug.Log("Click registered");
	}

	// This method is meant to be overwritten
	public virtual void Interact () {

		if (progress != Progression.none) ProgressionManager.instance.TriggerProgress(progress, progressionIndex);
		Debug.Log("Interacting with " + transform.name);
	}

	void OnMouseEnter () {
		if (accessible) highlight.Activate();		
	}

	void OnMouseExit() {
		highlight.Deactivate();		
	}

	void OnDrawGizmosSelected () {
		if (interactionTransform == null) {
			interactionTransform = transform;
		}

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(interactionTransform.position, radius);
	}

}