 
using UnityEngine;
using System.Collections;

public class Movement3D : MonoBehaviour
{


	private bool punchReady = true;
	public bool punchOccuring = false;

	private float invisibilityDelay;
	private float invisibilityPeriod;

    public float Speed = 5.0f;
    public float sprintSpeed = 10.0f;
	public float TurnSpeed = 10f;   // A smoothing value for turning the player.
	public GameObject myCamera;
	public float h;

    private Vector3 movement;
	public bool invisible;
	private Animation anim;
	private float speed;
	private bool sprinting;
	private float turnSpeed;

	public GameObject backpack;
	public GameObject fullMax;

	private SkinnedMeshRenderer r1;
	private SkinnedMeshRenderer r2;

	private PlayerDeath pd;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
		r1 = backpack.GetComponent<SkinnedMeshRenderer>();
		r2 = fullMax.GetComponent<SkinnedMeshRenderer>();
		invisibilityDelay = 0;
		invisibilityPeriod = 3;
		pd = gameObject.GetComponent <PlayerDeath> ();
	}

    void Update()
    {
        if(!pd.dead)
		{
			RunUpdate();
		}
	}

	void RunUpdate() {
		invisibilityDelay -= Time.deltaTime;
		
		//Check Invisibility
		if(Input.GetKey(KeyCode.Space) && !punchOccuring && (invisibilityDelay <= 0 || invisible) && invisibilityPeriod >= 0) 
		{
			anim.Stop();
			anim.Play("idle");
			invisible = true;
			gameObject.isStatic = true;
			r1.enabled = false;
			r2.enabled = false;
			invisibilityDelay = 5.0f;
			invisibilityPeriod -= Time.deltaTime;
		} 
		else {
			invisibilityPeriod = 3.0f;
			invisible = false;
			gameObject.isStatic = false;
			r1.enabled = true;
			r2.enabled = true;
		}
		
		
		
		//Check sprinting
		if (Input.GetKey(KeyCode.LeftShift))
		{
			sprinting = true;
		}
		else
		{
			sprinting = false;
		}
		
		
		
		
		
		//Input arrow keys
		h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");
		
		
		
		
		
		//Animation Controls
		
		if(Input.GetKey(KeyCode.A) && punchReady && !invisible) {
			punchOccuring = true;
			anim.Play ("punch");
			
		}
		else if ((Mathf.Abs(h) > 0 || Mathf.Abs(v) > 0) && !invisible)
		{
			punchOccuring = false;
			if (Input.GetKeyDown(KeyCode.LeftShift))
			{
				//anim.Stop();
				anim.Play("run");
			}
			else
			{
				if (sprinting)
				{
					anim.Play("run");
				}
				else
				{
					anim.Play("walk");
				}
			}
		}
		else
		{
			punchOccuring = false;
			anim.Stop();
			anim.Play("idle");
			
		}
		
		
		
		//Sprint speed control
		if (sprinting)
		{
			speed = sprintSpeed;
		}
		else
		{
			speed = Speed;
		}
		turnSpeed = TurnSpeed;
		
		
		
		
		
		//Forward Motion
		movement = new Vector3(0.0f, 0.0f, v);
		movement = movement * speed;
		if(!invisible && !punchOccuring) {
			transform.Translate(movement * Time.deltaTime);  //Normal motion
		}
		
		
		
		//Player rotation 
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.Rotate(0, -turnSpeed * Time.deltaTime * turnSpeed, 0);
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.Rotate(0, turnSpeed * Time.deltaTime * turnSpeed, 0);
		}
	}

}
