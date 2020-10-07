using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockGen : MonoBehaviour
{
    public RectTransform thisRect;

	private void Awake()
	{
        TryGetComponent(out thisRect);
	}

	// Start is called before the first frame update
	void Start()
    {
        RegenerateBlocks();
    }

    public void RegenerateBlocks()
	{
		var rect = thisRect.rect;
		var w = rect.width / 25;
		var h = ((rect.height - 50) / 2) / 5;

		for (var i = 0; i < 25; i++) // X
		{
			for (var j = 0; j < 5; j++) // Y
			{
				SpawnBlock(i, j, w, h);
			}
		}
	}

	private void SpawnBlock(int x, int y, float w, float h)
	{
		var obj = new GameObject($"Block_{x}_{y}", new[] {
				typeof(RectTransform),
				typeof(CanvasRenderer),
				typeof(Image)
			});

		if (!obj.TryGetComponent(out RectTransform rect) || !obj.TryGetComponent(out Image img)) return;

		var color = Color.HSVToRGB(Mathf.Sin(y) * Mathf.Cos(y), 1f, 1f);
		var anchor = new Vector2(0, 1);

		obj.transform.localPosition = new Vector2((w / 2) + w * x, (50 + h * y * 3) * -1);

		rect.anchorMax = anchor;
		rect.anchorMin = anchor;

		obj.transform.SetParent(transform, false);

		rect.sizeDelta = new Vector2(w, h);

		img.color = color;
	}
}
