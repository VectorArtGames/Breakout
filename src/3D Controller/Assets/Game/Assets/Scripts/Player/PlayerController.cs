using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera fov;
	public Rigidbody rb;

	public float Speed;
	public float Sensitivity;

	public float maxYAngle = 80f;

	private Vector2 currentRotation;

	private void Awake()
	{
		TryGetComponent(out rb);
		fov = GetComponentInChildren<Camera>();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

	private void OnEnable()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void OnDisable()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	private void Update()
	{
		var x = Input.GetAxis("Horizontal");
		var z = Input.GetAxis("Vertical");
		rb.MovePosition(rb.position + (new Vector3(x, 0, z) * Speed * Time.deltaTime));
		
		currentRotation.y -= Input.GetAxis("Mouse Y") * Sensitivity;
		currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);
		fov.transform.rotation = Quaternion.Euler(currentRotation.y, 0, 0);

		if (Input.GetButtonUp("Jump"))
			rb.velocity = new Vector3(0, 20, 0);
	}
}
