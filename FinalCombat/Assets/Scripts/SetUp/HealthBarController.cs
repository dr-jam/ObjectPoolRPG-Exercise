﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
	//the actual ratio of full the bar should be after the animation ends
	[SerializeField] private float Value = 0f;
	[SerializeField] private AnimationCurve ValueTransitionCurve;
	[SerializeField] private float ValueTransitionTime = 0.75f;
	private float TransitionStartTime = 0.0f;
	private float RatioAtStart = 0.0f;
	private float CurrentRatio = 0.0f;

	[SerializeField] private GameObject ValueSurface;
	[SerializeField] private GameObject TransitionSurface;


	void Start()
	{
		this.ValueSurface.transform.localScale.Set(0.01f, 1f, 1f);
		this.TransitionSurface.transform.localScale.Set(0.01f, 1f, 1f);
	}

	public void ChangeValue(float targetRatio)
	{
		targetRatio = Mathf.Clamp(targetRatio, 0.0f, 1.0f);
		this.TransitionStartTime = Time.time;
		this.RatioAtStart = this.CurrentRatio;
		this.Value = targetRatio;

		if (this.Value > this.RatioAtStart)
		{
			SetLocalScaleX(this.ValueSurface, this.CurrentRatio);
			SetLocalScaleX(this.TransitionSurface, this.Value);
		}
		else
		{
			SetLocalScaleX(this.ValueSurface, this.Value);
			SetLocalScaleX(this.TransitionSurface, this.CurrentRatio);
		}
	}


	void Update()
	{
		if ((Time.time - this.TransitionStartTime) < this.ValueTransitionTime)
		{
			if (this.Value > this.RatioAtStart)
			{
				//bar fills
				//transition bar is behind and longer than value bar
				//value bar grows to match transition bar   
				var growRange = this.Value - this.RatioAtStart;
				var ratioOfTimeDone = (Time.time - this.TransitionStartTime + 0.00001f) / this.ValueTransitionTime;
				var ratioOfTransition = growRange * this.ValueTransitionCurve.Evaluate(ratioOfTimeDone);
				SetLocalScaleX(this.ValueSurface, this.RatioAtStart + ratioOfTransition);
				this.CurrentRatio = this.RatioAtStart + ratioOfTransition;
			}
			else
			{
				//bar empties
				//transition bar is behind and longer than value bar
				//transition bar shrinks to match value bar 
				//this.ValueSurface.transform.localScale = 0.01f;   
				var growRange = this.RatioAtStart - this.Value;
				var ratioOfTimeDone = ((Time.time - this.TransitionStartTime) / this.ValueTransitionTime);
				var ratioOfTransition = growRange * this.ValueTransitionCurve.Evaluate(ratioOfTimeDone);
				SetLocalScaleX(this.TransitionSurface, this.RatioAtStart - ratioOfTransition);
				this.CurrentRatio = this.RatioAtStart - ratioOfTransition;
			}
		}
	}

	static private void SetLocalScaleX(GameObject go, float value)
	{
		var localScale = go.transform.localScale;
		localScale.x = value;
		go.transform.localScale = localScale;
	}
}
