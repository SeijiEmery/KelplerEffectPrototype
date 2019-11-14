using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubController : MonoBehaviour
{
	public string Faction = "f";

	[SerializeField]
	private float speed = 6.0f, bulletSpeed = 2.0f, shootingCooldown = 2.0f;

	[SerializeField]
	private float detectionRadius = 5;

	[SerializeField]
	private float detectionInterval = 1;

	private void Awake()
	{
		m_selectableUnit = GetComponent<SelectableUnit>();
	}

	private void FixedUpdate()
	{
		if (Faction == "f" && m_selectableUnit.selected)
			ControlledMove();

		FindTarget();

		AutoAttack();
	}

	private void ControlledMove()
	{
		var movement = Vector3.forward * Input.GetAxis("MoveZ") + Vector3.up * Input.GetAxis("MoveY") + Vector3.right * Input.GetAxis("MoveX");
		transform.Translate(movement * speed * Time.fixedDeltaTime);
	}

	private void FindTarget()
	{
		if (m_detectionGap < detectionInterval) { m_detectionGap += Time.fixedDeltaTime; return; }
		else { m_detectionGap = 0f; }

		List<Collider> nearbyColliders = new List<Collider>(Physics.OverlapSphere(transform.position, detectionRadius));

		// Don't get a new target, if the current target is still nearby.
		if (m_currentTarget != null && nearbyColliders.Contains(m_currentTarget.gameObject.GetComponent<Collider>()))
		{
			return;
		}

		m_currentTarget = null;

		foreach (Collider collider in nearbyColliders)
		{
			SubController subController = collider.gameObject.GetComponent<SubController>();

			if (subController != null && subController != this)
			{
				if (subController.Faction != Faction)
				{
					m_currentTarget = subController;
				}
			}
		}

		if (Faction == "f")
			Debug.Log(gameObject.name + " detects " + m_currentTarget?.transform.position.ToString());
	}

	private void AutoAttack()
    {
		if (m_currentTarget != null)
		{
			// TODO: Attack.
		}
    }

	private SelectableUnit m_selectableUnit;

	private SubController m_currentTarget;

	private float m_detectionGap;
}
