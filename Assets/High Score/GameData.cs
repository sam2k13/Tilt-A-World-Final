using UnityEngine;
using System;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameData : MonoBehaviour {
	public static GameData control;
	public int highScore;
	
	
	// Use this for initialization
	void Start () {
		
	}
	void Awake(){
		if(control == null){
			DontDestroyOnLoad(gameObject);
			control = this;
		}
		else if(control != this){
			
			Destroy(this.gameObject);
		}
		
	}
	public void Save(){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/myPlayerInfo.dat");
		
		PlayerData  data = new PlayerData();
		data.highScore = highScore;
		
		
		bf.Serialize(file,data);
		file.Close();
	}
	public void Load(){
		if(File.Exists(Application.persistentDataPath + "/myPlayerInfo.dat")){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/myPlayerInfo.dat",FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			highScore = data.highScore;
			file.Close();
		}
		
		
		
	}
	
}


[Serializable]
class PlayerData{
	public int highScore;
	
}
