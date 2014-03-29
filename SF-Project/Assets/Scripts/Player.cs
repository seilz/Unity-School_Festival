using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
private bool falled = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(falled) {
			print("FALLED!");
			falled = false;
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == "Finish") {
			falled = true;
		}
	}
}
