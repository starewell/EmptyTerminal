using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Types of progression. 
//Add to this enum, create a new Serializzed class, and call functions from that class in the TriggerProgress function to make a new category of progression
//Progression is a publically accessible state, when setting up interactables you can assign what kind of Progression it will trigger
public enum Progression {none, conveyorInteraction, towardsGateTriggers, leavingTerminal}

public class ProgressionManager : MonoBehaviour {
	
	public static ProgressionManager instance;
	void Awake() {
	    instance = this;
	}

	public ConveyorProgress conveyor;
	public TowardsGateProgress towards;
	public LeavingTerminalProgress leaving;

	//Function called by interactables and triggerColliders
	public void TriggerProgress(Progression progress, int progressionIndex) {
		//Check what kind of progress and index, call class function that corresponds		int state machine
		if (progress == Progression.conveyorInteraction) {
			if (progressionIndex == 0) conveyor.LuggageOut();			
			if (progressionIndex == 1) conveyor.PlacedSuitcase();	
			if (progressionIndex == 2) conveyor.MovementTriggerTwo();		
			if (progressionIndex == 3) conveyor.PickedUpSuitcase();
			if (progressionIndex == 4) conveyor.ExitsTSA();
		}

		if (progress == Progression.towardsGateTriggers) {
			if(progressionIndex == 0) towards.FinalCall();
			if(progressionIndex == 1) towards.ApproachingGate();
			if(progressionIndex == 2) towards.PlacedTickets();
		}

		if (progress == Progression.leavingTerminal) {
			if(progressionIndex ==0) leaving.ForgotTeddy();
			if(progressionIndex ==1) leaving.PickUpTeddy();
			if(progressionIndex ==2) leaving.LeaveWithTeddy();
			if(progressionIndex ==3) leaving.PlaceTeddy();
			if(progressionIndex ==4) leaving.GetOut();
		}
	}
}

//Class triggered by enum index, Serializable so it can be edited in the inspector
[System.Serializable]
public class ConveyorProgress {
	//public variables used only for this class' progression type
	public AudioSource[] audioSources;
	public AudioClip[] announcements;
	public GameObject[] progressionGates;
	public GameObject[] movementTriggers;

	public Animator suitcaseAnim;
	public GameObject interactionZone;

	//functions called to activate progress signifiers (audio, visual, progression gating)
	public void LuggageOut() {
		//play audio clip from list
		audioSources[1].clip = announcements[0];
		audioSources[1].Play();
		audioSources[0].clip = announcements[1];
		audioSources[0].Play();
		//activate/deactivate colliders
		progressionGates[0].SetActive(true);
		movementTriggers[0].SetActive(false);	
	}
	public void PlacedSuitcase() {
		interactionZone.SetActive(false);
		suitcaseAnim.SetBool("placed", true);

		progressionGates[0].SetActive(false);
		movementTriggers[1].SetActive(true);
	}
	public void MovementTriggerTwo() {
		audioSources[1].clip = announcements[0];
		audioSources[1].Play();
		audioSources[0].clip = announcements[2];
		audioSources[0].Play();
		movementTriggers[1].SetActive(false);
	}
	public void PickedUpSuitcase() {
		progressionGates[0].SetActive(true);
		progressionGates[1].SetActive(false);
	}
	public void ExitsTSA() {
		audioSources[1].clip = announcements[0];
		audioSources[1].Play();
		audioSources[0].clip = announcements[3];
		audioSources[0].Play();
	}
}

[System.Serializable]
public class TowardsGateProgress {
	public AudioClip[] announcements;
	public AudioSource[] audioSources;

	public GameObject[] movementTriggers;
	public GameObject interactionZone;
	public GameObject teddy;

	public void FinalCall() {
		audioSources[1].clip = announcements[0];
		audioSources[1].Play();
		audioSources[0].clip = announcements[1];
		audioSources[0].Play();
		movementTriggers[0].SetActive(false);
	}

	public void ApproachingGate() {
		audioSources[1].clip = announcements[0];
		audioSources[1].Play();
		audioSources[0].clip = announcements[2];
		audioSources[0].Play();
		movementTriggers[1].SetActive(false);
	}

	public void PlacedTickets() {
		teddy.SetActive(true);
		interactionZone.SetActive(false);
		audioSources[1].clip = announcements[0];
		audioSources[1].Play();
		audioSources[0].clip = announcements[3];
		audioSources[0].Play();
		movementTriggers[2].SetActive(true);
	}
}

[System.Serializable]
public class LeavingTerminalProgress {
	public AudioClip[] announcements;
	public AudioSource[] audioSources;

	public GameObject[] progressionGates;
	public GameObject[] movementTriggers;

	public void ForgotTeddy() {
		audioSources[1].clip = announcements[0];
		audioSources[1].Play();
		audioSources[0].clip = announcements[1];
		audioSources[0].Play();
		movementTriggers[0].SetActive(false);
	}

	public void PickUpTeddy() {
		audioSources[1].clip = announcements[0];
		audioSources[1].Play();
		audioSources[0].clip = announcements[2];
		audioSources[0].Play();
		movementTriggers[0].SetActive(false);
		movementTriggers[1].SetActive(true);
	}

	public void LeaveWithTeddy() {
		audioSources[1].clip = announcements[0];
		audioSources[1].Play();
		audioSources[0].clip = announcements[3];
		audioSources[0].Play();
		movementTriggers[1].SetActive(false);
	}

	public void PlaceTeddy() {
		audioSources[1].clip = announcements[0];
		audioSources[1].Play();
		audioSources[0].clip = announcements[5];
		audioSources[0].Play();
		progressionGates[0].SetActive(false);
	}

	public void GetOut() {
		audioSources[1].clip = announcements[0];
		audioSources[1].Play();
		audioSources[0].clip = announcements[6];
		audioSources[0].Play();
	}
}

