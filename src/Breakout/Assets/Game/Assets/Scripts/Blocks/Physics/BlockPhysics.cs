using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPhysics : MonoBehaviour
{
    private RectTransform thisRect;
    private BlockInfo info;

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out thisRect);
        TryGetComponent(out info);

        BallPhysics.OnBallMove.AddListener(BallMove);
    }

	private void BallMove(BallPhysics physics, RectTransform rect)
	{
        var ball = physics.transform.localPosition;
        var block = transform.localPosition;

		if (!(ball.y - rect.rect.height / 2 > block.y - thisRect.rect.height / 2 && ball.x + rect.rect.width / 2 > block.x - thisRect.rect.width / 2 + 1 && block.x + thisRect.rect.width / 2 + 1 > ball.x - rect.rect.width / 2)) return;

        if (physics.velocity.y < 0)
            return;

        physics.velocity.y *= -1;

        Debug.Log(transform.name);

	}
}
