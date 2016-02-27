using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeyboardControl : MonoBehaviour {

	public bool trackingOn = true;
	static public bool sinusoidMode = false;
	public Text debugText;

	// Use this for initialization
	void Start () {
		updateText();
	}
	
	// Update is called once per frame
	void Update () {

		// Turn tracking on or off
		if (Input.GetKeyDown (KeyCode.T)) {
			trackingOn = !trackingOn;
			OVRManager.instance.usePositionTracking = trackingOn;
			updateText();

		}

		// Change mode
		if (Input.GetKeyDown (KeyCode.P)) {
			sinusoidMode = !sinusoidMode;
			updateText();
		}

		// Change frequency
		if (Input.GetKeyDown (KeyCode.O) && sinusoidMode) {
			OVRCameraRig.frequency = 1/(1/OVRCameraRig.frequency + 5);
		} else if (Input.GetKeyDown (KeyCode.L) && sinusoidMode) {
			OVRCameraRig.frequency = 1/(1/OVRCameraRig.frequency - 5);
		}


	}

	void updateText(){
		debugText.text = "Tracking: " + trackingOn + "\n" + "SinusoidMode: " + sinusoidMode;
	}
	
}
