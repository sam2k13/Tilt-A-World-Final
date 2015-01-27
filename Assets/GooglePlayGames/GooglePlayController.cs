using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GooglePlayController : MonoBehaviour {
	public string leaderboardID;
	public static GooglePlayController googlePlay;

	void Awake(){

		if (googlePlay == null) {
			DontDestroyOnLoad(gameObject);	
			googlePlay = this;
		}
		else if(googlePlay != this){
			Destroy(this.gameObject);

		}
	
	
	}

	public void SignIn(){
		PlayGamesPlatform.Activate ();
		Social.localUser.Authenticate((bool success) => {

		});
	}
	public void ShowLeaderboard(){
		PlayGamesPlatform.Instance.ShowLeaderboardUI(leaderboardID);
	}
	public void UpdateLeaderboard(long score){
		Social.ReportScore(score, leaderboardID, (bool success) => {
		});
	}
}
