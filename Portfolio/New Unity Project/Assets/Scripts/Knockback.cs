using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
	[SerializeField] private GameObject brokenObject;
	[SerializeField] private float magnitudeCol, radius, power, upwards;
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.relativeVelocity.magnitude < magnitudeCol)
			return;

		gameObject.SetActive(false);
		brokenObject.SetActive(true);
		Vector3 explosionPos = transform.position;
		Collider[] cols = Physics.OverlapSphere(explosionPos, radius);

		foreach (Collider hit in cols)
		{
			if (hit.attachedRigidbody)
				hit.attachedRigidbody.AddExplosionForce(power * collision.relativeVelocity.magnitude, explosionPos, radius, upwards);
		}
	}
}
