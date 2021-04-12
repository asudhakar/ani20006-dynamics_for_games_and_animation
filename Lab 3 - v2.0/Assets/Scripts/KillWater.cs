using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillWater : MonoBehaviour
{
	[SerializeField] private float killSize = 0.0001f;
	[SerializeField] private float shrinkFactor = 0.01f;
	private bool canShrink;
	private void Update()
	{
		if (canShrink)
		{
			if (transform.localScale.x > killSize)
				transform.localScale -= transform.localScale * shrinkFactor;
			else
				gameObject.SetActive(false);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer != 10 && collision.gameObject.layer != 4)
			canShrink = true;
	}
}
