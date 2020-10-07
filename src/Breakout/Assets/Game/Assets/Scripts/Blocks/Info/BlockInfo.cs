using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInfo : MonoBehaviour
{
    private int durability;
    public int Durability
	{
        get => durability;
        set
		{
           CanKill(durability = Mathf.Clamp(value, 0, 100));
        }
	}

    public void CanKill(int _durability)
	{
        if (_durability > 0) return;
        Destroy(gameObject);
	}
}
