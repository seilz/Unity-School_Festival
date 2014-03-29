using UnityEngine;
using System.Collections;

public class Texture_Control : MonoBehaviour {
	bool show = false;
	int showIndex;

	// Use this for initialization
	void Start () {
		guiTexture.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(show) {
			ShowTexture();
			showIndex++;
		}
		if(showIndex >= 30) {
			HideTexture();
		}
	}


	public void ShowTexture() {
		if(Time.frameCount % 10 <= 5) {
			guiTexture.enabled = true;
		}
		else {
			guiTexture.enabled = false;
		}
		show = true;
	}
	public void HideTexture() {
		guiTexture.enabled = false;
		show = false;
		print("UNCOllISION");
		showIndex = 0;
	}
}
