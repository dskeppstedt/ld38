using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToward : MonoBehaviour {

	public GameObject target;

	void Update () {

		Vector2 goal = new Vector2(target.transform.position.x,target.transform.position.y);
		LookAt2D (this.transform,goal);
	}

	//source: https://forum.unity3d.com/threads/2d-look-at-object-disappears.390105/
	// Answer by Rafael-at-JAGS
	public void LookAt2D(Transform transform, Vector2 target){
		Vector2 current = transform.position;
		var direction = target - current;
		var angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}


}
