using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallPhysics : MonoBehaviour
{
    public static UnityEvent<BallPhysics, RectTransform> OnBallMove = 
        new UnityEvent<BallPhysics, RectTransform>();

    [Header("Physics")]
    public Vector2 velocity;
    public float gravity;


    private const float defaultSpeed = 5;
    private float speed = defaultSpeed;

    [Header("Information"), Space(5.0f)]
    [Tooltip("Minimum Speed of Ball"), Range(0, 100)]
    public float minSpeed;

    [Tooltip("Maximum Speed of Ball"), Range(0, 100)]
    public float maxSpeed;

    public float Speed
    {
	    get => speed;
	    set => speed = Mathf.Clamp(value, minSpeed, maxSpeed);
    }

    private RectTransform thisRect;

	private void Awake()
	{
        TryGetComponent(out thisRect);
	}

	void FixedUpdate()
    {
        velocity.y = Mathf.Clamp(velocity.y - Speed * gravity, -100, 100);
        transform.localPosition += new Vector3(velocity.x * Speed, velocity.y * Speed);
        OnBallMove?.Invoke(this, thisRect);
    }


}
