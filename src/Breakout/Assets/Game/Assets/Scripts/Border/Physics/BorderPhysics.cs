using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderPhysics : MonoBehaviour
{
	public BorderSide side;
    #region Singleton

    private RectTransform thisRect;

	private void Awake()
	{
		TryGetComponent(out thisRect);
	}

    #endregion

    // Start is called before the first frame update
    void Start()
    {
	    var localPosition = transform.localPosition;
	    side = localPosition.x.Equals(0) ? BorderSide.Top : localPosition.x > 0 ? BorderSide.Right : BorderSide.Left;

        BallPhysics.OnBallMove.AddListener(BallMove);
    }

    private void BallMove(BallPhysics physics, RectTransform rect)
    {
	    var ball = physics.transform.localPosition;
	    var border = transform.localPosition;
	    switch (side)
	    {
		    case BorderSide.Left when !(ball.x - rect.rect.width / 2 <= border.x + thisRect.rect.width):
			    return;
		    case BorderSide.Left:
			    Debug.Log(transform.localPosition);

			    physics.velocity.x *= -1;
			    physics.Speed *= 1.05f;
			    break;
		    case BorderSide.Right when !(ball.x + rect.rect.width / 2 >= border.x - thisRect.rect.width):
			    return;
		    case BorderSide.Right:
			    Debug.Log(transform.localPosition);

			    physics.velocity.x *= -1;
			    physics.Speed *= 1.05f;
			    break;
		    case BorderSide.Top when !(ball.y - rect.rect.height / 2 >= border.y - thisRect.rect.height):
			    return;
		    case BorderSide.Top:
			    Debug.Log(transform.localPosition);

			    physics.velocity.y *= -1;
			    physics.Speed *= 1.05f;
			    break;
	    }
    }

    public enum BorderSide
    {
        Left,
        Right,
        Top
    }
}
