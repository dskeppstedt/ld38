using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Following))]
public class BehaviorController : MonoBehaviour {

	public float behaviorSwitchTime;
	public bool randomizeTime;
	public MobBehavior afterFollowing, afterIdle;

	private MobBehavior state;
	private Following following;
	private float behaviorTimer;
	private Dictionary<MobBehavior, MobBehavior> nextBehavior;

	// Use this for initialization
	void Start () {
		behaviorTimer = behaviorSwitchTime;
		following = GetComponent<Following> ();
		nextBehavior = new Dictionary<MobBehavior, MobBehavior> ();
		nextBehavior.Add (MobBehavior.Following, afterFollowing);
		nextBehavior.Add (MobBehavior.Idle, afterIdle);
	}
	
	// Update is called once per frame
	void Update () {
		behaviorTimer -= Time.deltaTime;
		if (behaviorTimer < 0) {
			state = nextBehavior [state];
			HandleBehaviorChange ();
			ResetTimer ();
		}
	}

	void HandleBehaviorChange(){
		switch (state) {
		case MobBehavior.Following:
			following.enabled = true;
			break;
		case MobBehavior.Idle:
			following.enabled = false;
			break;
		default:
			break;
		}
	}

	void ResetTimer(){
		if (randomizeTime) {
			behaviorTimer = Random.Range (behaviorSwitchTime - behaviorSwitchTime / 2f, behaviorSwitchTime + behaviorSwitchTime / 2f);
		} else {
			behaviorTimer = behaviorSwitchTime;
		}
	}
}
