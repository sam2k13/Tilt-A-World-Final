using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
	//public float tiltAngle;
	public GameObject menuCanvas;
	public GameObject unlockCanvas;
	public Text highScoreText;
	public Sprite [] unlockableBalls;
	public Sprite lockedBall;
	private int currentBall;
	public Image [] ballSlots;
	private bool [] activeBalls;
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		currentBall = PlayerPrefs.GetInt ("Ball");
		activeBalls = new bool[9];
		GameData.control.Load ();
		highScoreText.text = GameData.control.highScore.ToString () + " m";
		GooglePlayController.googlePlay.SignIn ();
		FindActiveBalls ();
		InitiateBalls ();
	}
	
	// Update is called once per frame
	void Update () {


	
	}
	public void loadGame(){
		Application.LoadLevel (1);


	}
	public void showLeaderboard(){
		GooglePlayController.googlePlay.SignIn ();
		GooglePlayController.googlePlay.UpdateLeaderboard (GameData.control.highScore);
		GooglePlayController.googlePlay.ShowLeaderboard ();
	}
	void FindActiveBalls(){
		int counter = 0;
		foreach(bool ball in activeBalls){
			activeBalls[counter] = false;
			counter +=1;
		}
		activeBalls [0] = true;
		if (GameData.control.highScore >= 100) {
			activeBalls[1] = true;
			if (GameData.control.highScore >= 200) {
				activeBalls[2] = true;
				if (GameData.control.highScore >= 300) {
					activeBalls[3] = true;
					if (GameData.control.highScore >= 400) {
						activeBalls[4] = true;
						if (GameData.control.highScore >= 500) {
							activeBalls[5] = true;
							if (GameData.control.highScore >= 600) {
								activeBalls[6] = true;
								if (GameData.control.highScore >= 700) {
									activeBalls[7] = true;
									if (GameData.control.highScore >= 800) {
										activeBalls[8] = true;



									}}}}}}}}
	
	}

	void InitiateBalls(){
		int counter = 0;
		foreach (bool ball in activeBalls) {
			if(ball){
				ballSlots[counter].sprite = unlockableBalls[counter];
				ballSlots[counter].color = new Color(255,255,255,.25f);
			}		
			else{
				ballSlots[counter].sprite = lockedBall;
			}
			ballSlots[currentBall].color = new Color(255,255,255,1);
			counter +=1;
		}
	}
	public void selectBall(int newBall,int previousBall){
		if (newBall != previousBall) {
			ballSlots[previousBall].color = new Color(255,255,255,.25f);
			ballSlots[newBall].color = new Color(255,255,255,255);
			PlayerPrefs.SetInt("Ball",newBall);
		}
		Debug.Log (newBall);
		currentBall = newBall;

	}
	public void button0(){
		if (activeBalls [0]) {
			selectBall(0,currentBall);
		}
	}
	public void button1(){
		if (activeBalls [1]) {
			selectBall(1,currentBall);
		}
	}
	public void button2(){
		if (activeBalls [2]) {
			selectBall(2,currentBall);
		}
	}
	public void button3(){
		if (activeBalls [3]) {
			selectBall(3,currentBall);
		}
	}
	public void button4(){
		if (activeBalls [4]) {
			selectBall(4,currentBall);
		}
	}
	public void button5(){
		if (activeBalls [5]) {
			selectBall(5,currentBall);
		}
	}
	public void button6(){
		if (activeBalls [6]) {
			selectBall(6,currentBall);
		}
	}
	public void button7(){
		if (activeBalls [7]) {
			selectBall(7,currentBall);
		}
	}
	public void button8(){
		if (activeBalls [8]) {
			selectBall(8,currentBall);
		}
	}
	public void showMenu(){
		unlockCanvas.SetActive (false);
		menuCanvas.SetActive (true);
	}
	public void showUnlock(){
		unlockCanvas.SetActive (true);
		menuCanvas.SetActive (false);
	}



}
