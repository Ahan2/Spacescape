using UnityEngine;
using System.Collections;

public class FloatingScript : MonoBehaviour 
{
	public float hoverDistance = 0.75f;
	public float hoverForce = 10.0f;
	private float currentHeight = 0.0f;
	private float hoverForceMultiplier = 0.0f;
	private Vector3 hoverForceApplied = Vector3.zero;
	public Rigidbody rigidbody;
	void Start(){
		rigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate() 
	{
		RaycastHit rayHit;
		if (Physics.Raycast(transform.position, Vector3.down, out rayHit))
		{
			currentHeight = rayHit.distance;
			if (currentHeight < (hoverDistance - Time.deltaTime))
			{
				// find percentage of currentHeight below hoverDistance
				hoverForceMultiplier = (hoverDistance - currentHeight) / hoverDistance;
				hoverForceApplied = (Vector3.up * hoverForce * hoverForceMultiplier) + (Vector3.up * 9.8f);
				rigidbody.AddForce(hoverForceApplied);         
			} else {       
				// apply anti-gravity force for half distance above hoverDistance
				if ((currentHeight - hoverDistance - Time.deltaTime) < (hoverDistance / 2))
				{
					hoverForceApplied = (Vector3.up * 9.8f) * ((hoverDistance - (currentHeight - hoverDistance)) / hoverDistance);
					rigidbody.AddForce(hoverForceApplied);
				}
			}
		}
	}
}

