using UnityEngine;
using System.Collections;

public class TimerScript : MonoBehaviour {

	private float seconds;
	private float minutes;
	public float TimeInSeconds;
	public GameObject myUI;
	public string theText;
	public GameObject UI2;

	// Use this for initialization
	void Start () {
		seconds = 0.0f;
		minutes = 0.0f;
		theText = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(myUI.activeSelf == false && UI2.activeSelf == false)
		{
			seconds += Time.deltaTime;
			TimeInSeconds += Time.deltaTime;
		}
		if(seconds >= 60) {
			minutes++;
			seconds -= 60;
		}

		theText = minutes + " m, " + (int)seconds + " s.";
	}
}
