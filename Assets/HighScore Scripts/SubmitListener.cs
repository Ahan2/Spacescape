using UnityEngine;
using System.Collections;

public class SubmitListener : MonoBehaviour {

	public GameObject hs;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetHighscoreActive()
	{
		hs.SetActive(true);
	}
}
