using UnityEngine;
using System.Collections;

public class Text_Control : MonoBehaviour {
	bool show = false;

	// Use this for initialization
	void Start() {
		guiText.enabled = false;
	}
	
	// Update is called once per frame
	void Update() {
	}
	
	public void ShowText() {
		guiText.enabled = true;
		show = true;
	}

	public void HideText() {
		guiText.enabled = false;
		show = false;
	}
}
