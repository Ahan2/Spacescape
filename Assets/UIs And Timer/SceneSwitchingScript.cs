using UnityEngine;
using System.Collections;

public class SceneSwitchingScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void NextLevelButton(string levelName) {
		Application.LoadLevel(levelName);
	}

}
