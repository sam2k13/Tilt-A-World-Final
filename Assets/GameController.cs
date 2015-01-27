using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject marble;
	public GameObject scoreController;
	public GameObject gameOverCanvas;
	public GameObject gameCanvas;
	public Text scoreText;
	public Text highScoreText;
	public float endGame = -25.5f;
	public Material [] ballMaterials;
	public bool isPaused = true;
	public Image pauseButton;
	public Sprite [] pauseImages;
	public GameObject pauseButtonObject;
	// Use this for initialization
	void Start () {
		pauseButtonObject.SetActive (false);
		Time.timeScale = 1;
		marble.GetComponent<MeshRenderer> ().material = ballMaterials [PlayerPrefs.GetInt ("Ball")];

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (isPaused);
		if (marble.transform.position.y < endGame) {
			Time.timeScale = 0;
			gameCanvas.SetActive(false);
			gameOverCanvas.SetActive(true);
			scoreText.text = "Score: " + scoreController.GetComponent<ScoreScript>().getScore();
			highScoreText.text = "High Score: " + scoreController.GetComponent<ScoreScript>().getHighScore();
				
		} 

	}
	public void loadMenu(){
		Time.timeScale = 1;
		Application.LoadLevel (0);
	}
	public void playAgain(){

		Application.LoadLevel (1);
	}
	public void rateMe(){
		return;

	}
	public void showLeaderboard(){
		GooglePlayController.googlePlay.SignIn ();
		GooglePlayController.googlePlay.UpdateLeaderboard (GameData.control.highScore);
		GooglePlayController.googlePlay.ShowLeaderboard ();
	}
	public void StopScoring(){
		scoreController.GetComponent<ScoreScript>().deactivateScoring();

	}
	public void pause(){
		if (isPaused) {
			isPaused = false;
			Time.timeScale = 1;
			pauseButton.sprite = pauseImages[0];
				} 
		else {
			isPaused = true;
			pauseButton.sprite = pauseImages[1];
			Time.timeScale = 0;
		}

	}
	public void startGame(){
		pauseButtonObject.SetActive (true);
		isPaused = false;
	}

}
