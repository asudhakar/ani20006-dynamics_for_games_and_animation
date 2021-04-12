using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFire : MonoBehaviour
{
	[SerializeField] private float fireKillRate;
	[SerializeField] private float lightKillRate;
    private ParticleSystem fireSystem;
    private LightControl lightControl;
    private ParticleSystem smokeSystem;
    private List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();
	private float emissionOverTime;

	private void Awake()
	{
		lightControl = FindObjectOfType<LightControl>();
		fireSystem = GetComponent<ParticleSystem>();
	}

	private void Start()
	{
		var emission = fireSystem.emission;
		emissionOverTime = emission.rateOverTime.constant;
	}

	//private void OnParticleTrigger()
	//{
	//	emissionOverTime -= fireKillRate;
	//	var emission = fireSystem.emission;
	//	emission.rateOverTime = emissionOverTime;
	//}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 4)
		{
			emissionOverTime -= fireKillRate;
			var emission = fireSystem.emission;
			emission.rateOverTime = emissionOverTime;

			lightControl.MaxIntensity -= lightKillRate;
		}
	}
}
