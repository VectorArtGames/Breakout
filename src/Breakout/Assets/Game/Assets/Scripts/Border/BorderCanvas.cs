using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCanvas : MonoBehaviour
{
	public Camera cam;
	public RectTransform ContainerCanvas;

	public float Width;
	public float Height;

	#region Singleton

	public static BorderCanvas Instance { get; set; }

	private void Awake()
	{
		Instance = this;
		cam = Camera.main;
	}

	#endregion

	private void Start()
	{
		UpdateBorder();
	}

	public void UpdateBorder()
	{
		if (!(ContainerCanvas is RectTransform t && t.rect is Rect rect)) return;
		var aspect = cam.orthographicSize / cam.aspect;
		Width = (rect.width - 50) / aspect;
		Height = (rect.height - 50) / aspect;
	}

	public void OnRectTransformDimensionsChange()
	{
		UpdateBorder();
	}

}
