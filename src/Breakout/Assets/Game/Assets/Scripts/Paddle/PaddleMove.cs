using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMove : MonoBehaviour
{
	public Camera cam;

	public BorderCanvas border;
    // Start is called before the first frame update
    void Start()
    {
        border = BorderCanvas.Instance;
    }

    // Update is called once per frame
    void Update()
    {
	    if (cam == null || border.Width <= 0 || border.Height <= 0) return;

        if (!(transform is Transform t && t.localPosition is Vector3 pos)) return;

        var posX = Mathf.Clamp(Input.mousePosition.x - (border.Width / 2), -border.Width, border.Width);

        Debug.Log(posX);

        t.localPosition = new Vector3(posX, pos.y, pos.z);
    }
}
