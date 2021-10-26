using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTrigger : MonoBehaviour {
  
  	public bool triggerOnceEnter = true;
  	bool triggeredEnter = false;
  	public bool triggerOnceExit = true;
  	bool triggeredExit = false;

	public Progression progressOnEnter = Progression.none;
	public Progression progressOnExit = Progression.none;
	public int progressionIndex;


  	public virtual void OnTriggerEnter () {
  		if(triggerOnceEnter && triggeredEnter) {
  			if (progressOnEnter != Progression.none) {
  				ProgressionManager.instance.TriggerProgress(progressOnEnter, progressionIndex);
  				triggeredEnter = true;
  				Debug.Log("Triggering " + progressOnEnter);
  			}
  		} else {
  			if (progressOnEnter != Progression.none) {
  				ProgressionManager.instance.TriggerProgress(progressOnEnter, progressionIndex);
  				Debug.Log("Triggering " + progressOnEnter);
  			}
  		}
	}

	public virtual void OnTriggerExit () {
		if (triggerOnceExit && !triggeredExit) {
			if (progressOnExit != Progression.none) {
				ProgressionManager.instance.TriggerProgress(progressOnExit, progressionIndex);
				triggeredExit = true;
				Debug.Log("Triggering " + progressOnExit);
			}
			
		} else {
			if (progressOnExit != Progression.none) {
				ProgressionManager.instance.TriggerProgress(progressOnExit, progressionIndex);
				Debug.Log("Triggering " + progressOnExit);
			}
		}
	}
}
