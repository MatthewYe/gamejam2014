﻿using UnityEngine;

public class Fence : MonoBehaviour
{
	public bool IsHorizontal
	{
		get
		{
			return transform.eulerAngles.z % 180 < 90;
		}
	}

	public void InstantOrthographicSpin()
	{
		transform.eulerAngles = new Vector3(0, 0, IsHorizontal ? 90 : 0);
	}

	private void Awake()
	{
		_uiItem = GetComponent<tk2dUIItem>();
	}

	private void OnEnable()
	{
		_uiItem.OnClick += HandleOnClick;
	}

	private void OnDisable()
	{
		_uiItem.OnClick -= HandleOnClick;
	}

	private void HandleOnClick()
	{
		_uiItem.enabled = false;
		Go.to(transform, 0.3f, new GoTweenConfig().localRotation(
			new Vector3(0, 0, IsHorizontal ? 90 : 0)).onComplete((tween)=>
		      {
				_uiItem.enabled = true;
			  }));
	}
	
	private tk2dUIItem _uiItem;
}
