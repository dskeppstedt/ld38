using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour {
	
	void OnCollisionEnter2D (Collision2D col){
		Bullet bullet = GetComponent<Bullet> ();

		if (bullet.bounce && col.collider.tag == "Room") {
			// get the point of contact
			ContactPoint2D contact = col.contacts[0];

			// reflect our old velocity off the contact point's normal vector
			Vector2 reflectedVelocity = Vector2.Reflect(bullet.GetOldVelocity(), contact.normal);        

			// assign the reflected velocity back to the rigidbody
			GetComponent<Rigidbody2D>().velocity = reflectedVelocity;
			// rotate the object by the same ammount we changed its velocity
			Quaternion rotation = Quaternion.FromToRotation(bullet.GetOldVelocity(), reflectedVelocity);
			transform.rotation = rotation * transform.rotation;
		}else{
			this.gameObject.SetActive (false);
		}

	}
}