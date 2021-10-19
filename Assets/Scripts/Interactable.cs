using UnityEngine;
using UnityEngine.AI;

/*	
	This component is for all objects that the player can
	interact with collectables or objects. It is meant
	to be used as a base class.
*/

//[RequireComponent(typeof(ColorOnHover))]
public class Interactable : MonoBehaviour {

	public float radius = 2.5f;
	public Transform interactionTransform;
	public bool locked = false;

	bool onClick = false;
	Transform player;

	bool hasInteracted = false;	// Have we already interacted with the object?

	void Update ()
	{
		Debug.Log(onClick);
		if (onClick){
			float distance = Vector3.Distance(player.position, transform.position);
			if (distance <= radius) {
				if (!locked) {
					Debug.Log("Interact");
					Interact();
					hasInteracted = true;
				} else {
					Debug.Log ("Locked");
				}
			}
		}		
		onClick = false;
	}

	//recieving input from MouseLook
	public void OnClicked(Transform playerTransform) {
		onClick = true;
		player = playerTransform;
	}

	// This method is meant to be overwritten
	public virtual void Interact ()
	{
		
		Debug.Log("Interacting with " + transform.name);
	}

	void OnDrawGizmosSelected ()
	{
		if (interactionTransform == null) {
			interactionTransform = transform;
		}

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(interactionTransform.position, radius);
	}

}