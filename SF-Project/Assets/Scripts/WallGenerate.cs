using UnityEngine;
using System.Collections;

public class WallGenerate : MonoBehaviour {
	public GameObject wallPrefab;
	public GameObject goalPrefab;
	int wallY = 10;
	int quantity = 4;
	bool putGoal = false;
	int [] index = new int[4];
	Vector3[,] coordinate = new Vector3[4,4];
	Vector3[] wallPosition = new Vector3[4];
	
	// Use this for initialization
	void Start () {
		//壁の位置(Vector3)をマス単位(行列)に変換
		coordinate[0,0] = new Vector3(5,wallY,5);
		coordinate[0,1] = new Vector3(5,wallY,25);
		coordinate[0,2] = new Vector3(5,wallY,45);
		coordinate[0,3] = new Vector3(5,wallY,65);
		coordinate[1,0] = new Vector3(25,wallY,5);
		coordinate[1,1] = new Vector3(25,wallY,25);
		coordinate[1,2] = new Vector3(25,wallY,45);
		coordinate[1,3] = new Vector3(25,wallY,65);
		coordinate[2,0] = new Vector3(45,wallY,5);
		coordinate[2,1] = new Vector3(45,wallY,25);
		coordinate[2,2] = new Vector3(45,wallY,45);
		coordinate[2,3] = new Vector3(45,wallY,65);
		coordinate[3,0] = new Vector3(65,wallY,5);
		coordinate[3,1] = new Vector3(65,wallY,25);
		coordinate[3,2] = new Vector3(65,wallY,45);
		coordinate[3,3] = new Vector3(65,wallY,65);
		
		for(int i = 0;i < 3;i++) {
			index[i] = Random.Range(0,quantity);
		}
		switch(index[0]) {
			case 0:
				wallPosition[0] = coordinate[1,0];
				wallPosition[1] = coordinate[0,3];
				wallPosition[2] = coordinate[2,3];
				wallPosition[3] = coordinate[2,2];
				break;
			case 1:
				wallPosition[0] = coordinate[1,1];
				wallPosition[1] = coordinate[1,2];
				wallPosition[2] = coordinate[2,1];
				wallPosition[3] = coordinate[2,2];
				break;
			case 2:
				wallPosition[0] = coordinate[1,2];
				wallPosition[1] = coordinate[2,1];
				break;
			case 3:
				wallPosition[0] = coordinate[3,2];
				wallPosition[1] = coordinate[2,1];
				wallPosition[2] = coordinate[1,2];
				break;
		}
		for(int i = 0;i < quantity;i++) {
			if(wallPosition[i] != Vector3.zero) {
				Instantiate(wallPrefab,wallPosition[i],Quaternion.identity);
			}
		}

		for(int i = 0;i < quantity;i++) {
			print(wallPosition[i]);
		}

		CreateGoal();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void CreateGoal() {
		bool [] wall = new bool[quantity];
		putGoal = false;
		while(!putGoal) {
			index[1] = Random.Range(0,quantity);
			index[2] = Random.Range(0,quantity);
			for(int i = 0;i < quantity;i++) {
				print(i);
				if(coordinate[index[1],index[2]] == wallPosition[i]) {
					wall[i] = false;
				}
				else {
					wall[i] = true;
				}
			}
			if(wall[0] && wall[1] && wall[2] && wall[3]) {
				coordinate[index[1],index[2]].y = 5;
				index[3] = Random.Range(0,3);
				switch(index[3]) {
					case 0:
						coordinate[index[1],index[2]] += new Vector3(5,0,5);
						break;
					case 1:
						coordinate[index[1],index[2]] += new Vector3(5,0,-5);
						break;
					case 2:
						coordinate[index[1],index[2]] += new Vector3(-5,0,5);
						break;
					case 3:
						coordinate[index[1],index[2]] += new Vector3(-5,0,-5);
						break;
				}
				Instantiate(goalPrefab,coordinate[index[1],index[2]],Quaternion.identity);
				putGoal = true;
			}
			else {
				putGoal = false;
			}
			for(int i = 0;i < quantity;i++) {
				
			}
		}
	}
}