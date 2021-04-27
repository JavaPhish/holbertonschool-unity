using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour {

	public AudioMixer mix;

	public void SetBGMLevel(float value)
	{
		mix.SetFloat("BGM", Mathf.Log10(value) * 20.0f);
	}

	public void SetSFXLevel(float value)
	{
		mix.SetFloat("SFX", Mathf.Log10(value) * 20.0f);
	}
}
