using UnityEngine;
using System.Collections;

public class EarthRotationMenu : MonoBehaviour {
	public float rotationSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate (0, rotationSpeed * Time.deltaTime, 0);
	
	}
}
