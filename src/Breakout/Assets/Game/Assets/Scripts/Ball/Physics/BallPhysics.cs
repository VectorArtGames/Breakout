using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallPhysics : MonoBehaviour
{
    public static UnityEvent<BallPhysics, RectTransform> OnBallMove = 
        new UnityEvent<BallPhysics, RectTransform>();

    public Vector2 velocity;
    public float gravity;
    public float speed;
    public RectTransform thisRect;

	private void Awake()
	{
        TryGetComponent(out thisRect);
	}

	void FixedUpdate()
    {
        velocity.y = Mathf.Clamp(velocity.y - speed * gravity, -100, 100);
        transform.localPosition += new Vector3(velocity.x * speed, velocity.y * speed);
        OnBallMove?.Invoke(this, thisRect);
    }


}
