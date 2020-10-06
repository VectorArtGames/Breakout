using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PaddleMove : MonoBehaviour
{
	public Camera cam;

	public BorderCanvas border;
    public RectTransform thisRect;

	private void Awake()
	{
        TryGetComponent(out thisRect);
	}

	// Start is called before the first frame update
	void Start()
    {
        border = BorderCanvas.Instance;
        BallPhysics.OnBallMove?.AddListener(BallMove);
    }

    void FixedUpdate()
    {
	    if (cam == null || border.Width <= 0 
            || border.Height <= 0 || thisRect == null) return;

        if (!(transform is Transform t && t.localPosition is Vector3 pos && thisRect.rect is Rect rect)) return;
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(border.ContainerCanvas, Input.mousePosition, cam, out Vector2 point))
			return;

        var posX = Mathf.Lerp(t.localPosition.x, Mathf.Clamp(point.x, (-border.Width / 2) + (rect.width / 2), (border.Width / 2) - (rect.width / 2)), Time.deltaTime * 5f);


        t.localPosition = new Vector3(posX, pos.y, pos.z);
    }

    private void BallMove(BallPhysics physics, RectTransform rect)
	{
        var p = transform.localPosition;
        var ball = physics.transform.localPosition;
        if (p.x > ball.x && ball.x < p.x + rect.rect.width)
		{
            Debug.Log("Yes");
		}
	}
}
