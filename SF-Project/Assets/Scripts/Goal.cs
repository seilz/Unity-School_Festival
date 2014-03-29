using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
	public int point = 0;
	public GameObject WallGenerator;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player") {
			point++;
			WallGenerate goal = WallGenerator.GetComponent<WallGenerate>();
			print("create!");
			goal.CreateGoal();
		}
	}
}