using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountdownScript : MonoBehaviour {
	private int count = 2;
	public GameObject gameControl;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void changeText(){
		if (count < 1) {
			gameControl.GetComponent<GameController>().startGame();
			Destroy(gameObject);
			return;		
		}
		gameObject.GetComponent<Text> ().text = count.ToString ();
		count -= 1;
	}
}
