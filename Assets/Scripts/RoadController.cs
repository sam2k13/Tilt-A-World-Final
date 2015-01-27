using UnityEngine;
using System.Collections;

public class RoadController : MonoBehaviour {
	public float maxAngle = 30;
	private bool risingRight;
	public float tiltSpeed;
	private float tempAngle =0;
	public GameObject gameControl;
	// Use this for initialization
	void Start () {
		risingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameControl.GetComponent<GameController>().isPaused == false) {
						if (risingRight) {
								transform.Rotate (new Vector3 (0, 0, Time.deltaTime * tiltSpeed));
								tempAngle += Time.deltaTime * tiltSpeed;
								//Debug.Log(transform.eulerAngles.z);
								if (tempAngle >= maxAngle) {
										//Debug.Log("switched");
										risingRight = false;
								}
						} else {
								transform.Rotate (new Vector3 (0, 0, -Time.deltaTime * tiltSpeed));	
								//Debug.Log(transform.eulerAngles.z);
								tempAngle -= Time.deltaTime * tiltSpeed;
								if (tempAngle <= -maxAngle) {
										risingRight = true;
										if (maxAngle < 90) {
												maxAngle += 10;
										}
								}


						}
				}

	
	}
}
