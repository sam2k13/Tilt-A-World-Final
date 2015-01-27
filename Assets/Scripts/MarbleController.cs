using UnityEngine;
using System.Collections;

public class MarbleController : MonoBehaviour {
	public float maxSpeed;
	public float initialSpeed;
	private float currentSpeed;
	public float sideForce;
	public GameObject gameControl;
	private float myXaccel;
	// Use this for initialization
	void Start () {

		currentSpeed = initialSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (gameControl.GetComponent<GameController>().isPaused);
		if (gameControl.GetComponent<GameController>().isPaused == false) {
			Debug.Log ("This still happened");
						if (currentSpeed < maxSpeed) {
								//currentSpeed += .1f * Time.deltaTime;		
								rigidbody.AddForce (new Vector3 (0, 0, currentSpeed));
						} 
						Vector3 acceler = Input.acceleration;
						acceler.Normalize();
						myXaccel = Mathf.Lerp(myXaccel, acceler.x, sideForce * Time.deltaTime);
						//Debug.Log (myXaccel);
						rigidbody.AddForce (new Vector3 (myXaccel * sideForce, 0, 0));
						if (Input.touchCount >= 1) {
								Touch touch = Input.touches [0];
								if (Camera.main.ScreenToViewportPoint (touch.position).y <= .75) {
										//changeShape(0);
										//setOutlineColor(mainShape,squareColor);
			
										if (Camera.main.ScreenToViewportPoint (touch.position).x <= .5) {
												//changeShape(1);
												//setOutlineColor(mainShape,trapezoidColor);
												// make player trapezoid
												rigidbody.AddForce (new Vector3 (-sideForce, 0, 0));
												//Debug.Log ("Add left force");
										} else {
												rigidbody.AddForce (new Vector3 (sideForce, 0, 0));	
												//changeShape(2);
												//setOutlineColor(mainShape,circleColor);
												//Debug.Log ("Add right force");
												//make player circle
										}	
								}
						}
						if (Input.GetKey (KeyCode.LeftArrow)) {
								rigidbody.AddForce (new Vector3 (-sideForce, 0, 0));
			
						}
						if (Input.GetKey (KeyCode.RightArrow)) {
								rigidbody.AddForce (new Vector3 (sideForce, 0, 0));		
			
						}
				}
	}
	void OnTriggerEnter(Collider col){
		gameControl.GetComponent<GameController> ().StopScoring ();
	}
}
