using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject marble;
	private Vector3 offset;
	public GameObject github;
	// Use this for initialization
	void Start () {
		offset = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = marble.transform.position + offset;
	}
}
