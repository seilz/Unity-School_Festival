#pragma strict

private var motor : CharacterMotor;
private var XSpeed = 0f;
private var ZSpeed = 0f;
private var canX = true;
private var canZ = true;
private var inputDelayX = 0;
private var inputDelayZ = 0;

// Use this for initialization
function Awake () {
	motor = GetComponent(CharacterMotor);
}

//つけたし部分
function OnGUI() {
	if(GUI.RepeatButton(Rect(50,600,50,50),"Right")) {
		XSpeed = -1.0f;
		inputDelayX = 0;
		canX = false;
	}
	if(GUI.RepeatButton(Rect(150,600,50,50),"Left")) {
		XSpeed = 1.0f;
		inputDelayX = 0;
		canX = false;
	}
	if(GUI.RepeatButton(Rect(100,550,50,50),"Front")) {
		ZSpeed = 1.0f;
		inputDelayZ = 0;
		canZ = false;
	}
	if(GUI.RepeatButton(Rect(100,650,50,50),"Back")) {
		ZSpeed = -1.0f;
		inputDelayZ = 0;
		canZ = false;
	}
}


// Update is called once per frame
function Update () {
	// Get the input vector from keyboard or analog stick
	var directionVector = new Vector3(Input.GetAxis("Horizontal") + XSpeed, 0, Input.GetAxis("Vertical") + ZSpeed);
	
	//つけたし部分
	if (directionVector != Vector3.zero) {
		// Get the length of the directon vector and then normalize it
		// Dividing by the length is cheaper than normalizing when we already have the length anyway
		var directionLength = directionVector.magnitude;
		directionVector = directionVector / directionLength;
		
		// Make sure the length is no bigger than 1
		directionLength = Mathf.Min(1, directionLength);
		
		// Make the input vector more sensitive towards the extremes and less sensitive in the middle
		// This makes it easier to control slow speeds when using analog sticks
		directionLength = directionLength * directionLength;
		
		// Multiply the normalized direction vector by the modified length
		directionVector = directionVector * directionLength;
	}
	//つけたし部分
	if(canX) {
		XSpeed = 0f;
	}
	if(canZ) {
		ZSpeed = 0f;
	}
	if(!canX) {
		inputDelayX++;
	}
	if(!canZ) {
		inputDelayZ++;
	}
	if(inputDelayX >= 0) {
		canX = true;
		inputDelayX = 0;
	}
	if(inputDelayZ >= 0) {
		canZ = true;
		inputDelayZ = 0;
	}
	
	// Apply the direction to the CharacterMotor
	motor.inputMoveDirection = transform.rotation * directionVector;
	motor.inputJump = Input.GetButton("Jump");
}

// Require a character controller to be attached to the same game object
@script RequireComponent (CharacterMotor)
@script AddComponentMenu ("Character/FPS Input Controller")
