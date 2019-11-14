using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
	[SerializeField]
	private Health m_health;

	private void Awake()
	{
		m_health.onDestroyed += HandleOnDestroyed;
	}

	private void HandleOnDestroyed()
	{
		Destroy(gameObject);
	}
}
