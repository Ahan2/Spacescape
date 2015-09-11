using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeStringFetcher : MonoBehaviour {

	public GameObject TimerObject;
	TimerScript ts;
	Text displayTime;

	// Use this for initialization
	void Start () {
		ts = TimerObject.GetComponent<TimerScript>();
		displayTime = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		displayTime.text = ts.theText;
	}
}
