using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
	private Animator animator;
	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	public void TurnOffAnimator()
	{
		animator.enabled = false;
	}
}
