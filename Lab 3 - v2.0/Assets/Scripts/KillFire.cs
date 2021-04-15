using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFire : MonoBehaviour
{
	[SerializeField] private float fireKillRate;
	[SerializeField] private float smokeIncreaseRate;
	[SerializeField] private float smokeStartLifetime;
	[SerializeField] private float flameDecreaseThreshold;
	[SerializeField] private float lightKillRate;
	[SerializeField] private ParticleSystem smokeSystem;
	[SerializeField] private ParticleSystem emberSystem;

    private ParticleSystem fireSystem;
    private LightControl lightControl;
	private float flameEmissionOverTime;
	private bool isSet;

	private void Awake()
	{
		lightControl = FindObjectOfType<LightControl>();
		fireSystem = GetComponent<ParticleSystem>();
	}

	private void Start()
	{
		var emission = fireSystem.emission;
		flameEmissionOverTime = emission.rateOverTime.constant;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 4)
		{
			flameEmissionOverTime -= fireKillRate;
			var flameEmission = fireSystem.emission;
			flameEmission.rateOverTime = flameEmissionOverTime;

			if (!isSet && flameEmissionOverTime <= flameDecreaseThreshold)
			{
				var smokeEmission = smokeSystem.emission;
				smokeEmission.rateOverTime = smokeIncreaseRate;

				var smokeMain = smokeSystem.main;
				smokeMain.startLifetime = smokeStartLifetime;

				var emberEmission = emberSystem.emission;
				emberEmission.rateOverTime = 1f;

				isSet = true;
			}

			lightControl.MaxIntensity -= lightKillRate;
		}
	}
}
