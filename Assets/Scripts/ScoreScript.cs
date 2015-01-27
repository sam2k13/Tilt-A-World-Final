using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
	public GameObject marble;
	private int score;
	public Text scoreBoard;
	private int velocity;
	private bool isAlive = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isAlive) {
						score = (int)(marble.gameObject.transform.position.z + 5.8f);
						velocity = (int)marble.gameObject.rigidbody.velocity.z;
						scoreBoard.text = score.ToString () + "m";
				}
	}
	public void deactivateScoring(){
		isAlive = false;

	}
	public string getHighScore(){

		GameData.control.Load();
		if (score > GameData.control.highScore) {
			GameData.control.highScore = score;
			GameData.control.Save();
		}
		Debug.Log (GameData.control.highScore.ToString () + "m");
		return GameData.control.highScore.ToString() + "m";
	}
	public string getScore(){
		return score.ToString () + " m";
	}

}
