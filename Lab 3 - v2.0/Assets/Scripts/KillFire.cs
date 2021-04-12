using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFire : MonoBehaviour
{
	[SerializeField] private float fireKillRate;
    private ParticleSystem partSystem;
    private List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();
	private float emissionOverTime;

	private void Awake()
	{
        partSystem = GetComponent<ParticleSystem>();
	}

	private void Start()
	{
		var emission = partSystem.emission;
		emissionOverTime = emission.rateOverTime.constant;
	}

	private void OnParticleTrigger()
	{
		Debug.Log("Collided");
		emissionOverTime -= fireKillRate;
		var emission = partSystem.emission;
		emission.rateOverTime = emissionOverTime;
	}
}
