using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole_Force : MonoBehaviour {
	public string activeTag;

	void OnTriggerStay(Collider other){
		Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

		Vector3 direction = transform.position - other.gameObject.transform.position;
		direction.Normalize();

		if(other.gameObject.tag == activeTag){
			rb.velocity *= 0.9f;

			rb.AddForce(direction * rb.mass * 20.0f);
		}
	}
}
