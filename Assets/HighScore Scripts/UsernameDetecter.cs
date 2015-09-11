using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UsernameDetecter : MonoBehaviour {

	public string username;
	private Text t;

	// Use this for initialization
	void Start () {
		t = gameObject.GetComponent<Text> ();		
	}
	
	// Update is called once per frame
	void Update () {
		username = t.text;
	}
}
