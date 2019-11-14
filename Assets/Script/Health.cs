using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	public delegate void OnDestroyed();
	public event OnDestroyed onDestroyed;

	[SerializeField]
	private float m_fullHealth;

	private void Start()
	{
		GetComponent<MeshRenderer>().material.color = Color.red;

		m_currentHealth = m_fullHealth;

		m_initialScale = transform.localScale;
	}

	public void AddHealth(float deltaHealth)
	{
		m_currentHealth += deltaHealth;

		if (m_currentHealth == 0f)
		{
			onDestroyed.Invoke();
		}

		transform.localScale = new Vector3(m_currentHealth / m_fullHealth * m_initialScale.x, m_initialScale.y, m_initialScale.z);
	}

	private float m_currentHealth;

	private Vector3 m_initialScale;
}
