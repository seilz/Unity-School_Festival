using UnityEngine;
using System.Collections;

public class Aim: MonoBehaviour
{
	//Public Variable
	public Material[] materials;
	public GameObject[] textObjects;
	public GameObject[] textureObjects;

	//Private Variable
	GameObject air;
	Color aimedColor = new Color(1f,0.1f,0.1f,0.5f);
	int index = 0;
	bool shot = false;
	bool inAim = false;

	private void Start() {
		collider.isTrigger = true;
		air = transform.parent.gameObject;
	}
	
	private void Update() {
		if(shot) {
			ShowShot();
		}
	}
 
	private void OnTriggerEnter(Collider other)	{
		if(other.gameObject.tag == "Aim") {
			ShowAimed();
		}
	}

	private void OnTriggerStay(Collider other) {
		air = transform.parent.gameObject;
		if(other.gameObject.tag == "Aim") {
			if(Input.GetKey(KeyCode.Space)) {
				ShowShot();
			}
		}
		if(other.gameObject.tag == "Player") {
			if(shot) {
				if(!inAim){
					ShowWarning();
					inAim = true;
				}
			}
		}
	}

	private void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == "Aim") {
			HideAimed();
		}
		inAim = false;
	}
	
	private void ShowAimed() {
		index = 0;
		air.renderer.material.color = aimedColor;
		collider.renderer.material = materials[index];
	}
	private void HideAimed() {
		index = 1;
		air.renderer.material.color = Color.clear;
		collider.renderer.material = materials[index];
	}
	private void ShowShot() {
		int shotCount = 0;
		shot = true;
		if(Time.frameCount % 20 <= 10) {
			air.renderer.material.color = aimedColor;
		}
		else {
			air.renderer.material.color = Color.clear;
		}
		shotCount ++;
		if(shotCount >= 300) {
			shot = false;
			air.renderer.material.color = Color.clear;
		}
	}

	private void ShowWarning() {
		Text_Control text1 = textObjects[1].GetComponent<Text_Control>();
		text1.ShowText();
		Text_Control text = textObjects[0].GetComponent<Text_Control>();
		text.ShowText();
		Texture_Control texture = textureObjects[0].GetComponent<Texture_Control>();
		texture.ShowTexture();
		print("COLLISION");
	}

}
