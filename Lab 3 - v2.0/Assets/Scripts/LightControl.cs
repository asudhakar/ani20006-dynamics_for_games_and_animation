using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
	[SerializeField] private Light campfireLight;
	[SerializeField] private float endIntensity = 100f;
	[SerializeField] private float intensityGap = 30f;
	[SerializeField] private float lerpDuration;
	//TODO: Make max and min intensity to randomly assign
	private Animator animator;
	private float currentLerpTime;
	private float maxIntensity;
	private bool increaseIntensity;

	private bool flicker;
	private float timeElapsed;
	private float flickerDuration = 0f;
	private float intensity = 0f;
	private float currentIntensity = 0f;
	private float minIntensity { get => campfireLight.intensity - intensityGap < 0 ? 0 : campfireLight.intensity - intensityGap; }
	public float MaxIntensity { get => maxIntensity; set => maxIntensity = value; }

	private void Awake()
	{
		animator = campfireLight.GetComponent<Animator>();
	}

	private void Start()
	{
		campfireLight.intensity = 0f;
		TurnLightsOff();
	}

	private void Update()
	{
		if (increaseIntensity)
		{
			if (currentLerpTime < lerpDuration)
			{
				MaxIntensity = Mathf.Lerp(0, endIntensity, currentLerpTime / lerpDuration);
				campfireLight.intensity = MaxIntensity;
				currentLerpTime += Time.deltaTime;
			}
			else
			{
				//animator.enabled = true;
				increaseIntensity = false;
				currentLerpTime = 0f;
			}
		}
		Flicker();
	}

	private void Flicker()
	{
		if (timeElapsed < flickerDuration)
		{
			campfireLight.intensity = Mathf.Lerp(currentIntensity, intensity, timeElapsed / flickerDuration);
			timeElapsed += Time.deltaTime;
		}
		else
		{
			flickerDuration = Random.Range(0.1f, 0.2f);
			intensity = Random.Range(minIntensity, MaxIntensity);
			currentIntensity = campfireLight.intensity;
			timeElapsed = 0f;
		}
	}

	public void TurnLightsOn()
	{
		campfireLight.gameObject.SetActive(true);
		increaseIntensity = true;
	}

	public void TurnLightsOff()
	{
		campfireLight.gameObject.SetActive(false);
	}
}
