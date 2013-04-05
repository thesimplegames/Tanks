using UnityEngine;
using System.Collections;

public class Achievments : MonoBehaviour {
	
	public enum AchievmentType{KillTank,FoundPowerUp};
	
	public static int killedTanks=0;
	public static int foundedPowerUps=0;
	
	public static bool first1Kill=false;
	public static bool first10Kill=false;
	public static bool first100Kill=false;
	public static bool first1PowerUp=false;
	public static bool first10PowerUp=false;
	public static bool first100PowerUp=false;
	
	public static void AddAchievmentProgress(AchievmentType type){
		switch (type){
		case AchievmentType.KillTank:
			killedTanks++;
			if (killedTanks>=1) first1Kill=true;
			if (killedTanks>=10) first10Kill=true;
			if (killedTanks>=100) first100Kill=true;
			break;
		case AchievmentType.FoundPowerUp:
			foundedPowerUps++;
			if (foundedPowerUps>=1) first1PowerUp=true;
			if (foundedPowerUps>=10) first10PowerUp=true;
			if (foundedPowerUps>=100) first100PowerUp=true;
			break;
		}
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	Debug.Log(first1Kill);
	}
}
