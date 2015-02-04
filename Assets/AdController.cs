using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class AdController : MonoBehaviour {
	public static AdController adControl;
	void Awake(){
		
		if (adControl == null) {
			DontDestroyOnLoad(gameObject);	
			adControl = this;
		}
		else if(adControl != this){
			Destroy(this.gameObject);
			
		}
		
		
	}
	// Use this for initialization
	void Start () {
		if (Advertisement.isSupported) {
			Advertisement.allowPrecache = true;
			Advertisement.Initialize ("131624584");
		}
	}
	public void showAd(){
		if (Advertisement.isReady ()) {
			Advertisement.Show();
		}

	}
}
