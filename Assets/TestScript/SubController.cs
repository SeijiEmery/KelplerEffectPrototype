using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubController : MonoBehaviour
{
	public string Faction = "f";

	[SerializeField]
	private float speed = 1f, rotateSpeed = 2f, bulletSpeed = 2f, shootingCooldown = 2f;

	[SerializeField]
	private float detectionRadius = 5;

	[SerializeField]
	private float detectionInterval = 1;

	private void Awake()
	{
		m_selectableUnit = GetComponent<SelectableUnit>();
	}

	private void Start()
	{
		m_destination = transform.position;
	}

	private void FixedUpdate()
	{
		if (Faction == "f" && m_selectableUnit.selected)
			ControlledMove();

		DetectNearbyTarget();

		if (m_currentTarget != null)
		{
			transform.LookAt(m_currentTarget.transform);

			AutoAttack();
		}
		else
		{
			if (m_assignedTarget != null)
			{
				transform.LookAt(m_assignedTarget.transform);
			}
		}

		// Keep moving to the assigned target, even if there is an enemy sub nearby.
		if (m_currentTarget != m_assignedTarget)
		{
			AutoMove();
		}
	}

	private void DetectNearbyTarget()
	{
		if (m_detectionGap < detectionInterval) { m_detectionGap += Time.fixedDeltaTime; return; }
		else { m_detectionGap = 0f; }

		List<Collider> nearbyColliders = new List<Collider>(Physics.OverlapSphere(transform.position, detectionRadius));

		// Prioritize the assigned target, if it's nearby.
		if (m_assignedTarget != null && nearbyColliders.Contains(m_assignedTarget.gameObject.GetComponent<Collider>()))
		{
			m_currentTarget = m_assignedTarget;

			return;
		}

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
					m_currentTarget = subController.gameObject;
				}
			}
		}

		if (Faction == "f")
			Debug.Log(gameObject.name + " detects " + m_currentTarget?.transform.position.ToString());
	}

	private void ControlledMove()
	{
		var movement = Vector3.forward * Input.GetAxis("MoveZ") + Vector3.up * Input.GetAxis("MoveY") + Vector3.right * Input.GetAxis("MoveX");
		transform.Translate(movement * speed * Time.fixedDeltaTime);

		transform.Rotate(Vector3.up * rotateSpeed * Input.GetAxis("TurnHorizontal"), Space.Self);
	}

	private void AutoMove()
	{
		float deltaTime = Time.fixedDeltaTime;
		Vector3 deltaPos = m_destination - transform.position;
		if (deltaPos.sqrMagnitude > speed * speed * deltaTime * deltaTime)
		{
			deltaPos = deltaPos.normalized * speed * deltaTime;
		}
		transform.position += deltaPos;
	}

	public void ControlledAttack(GameObject target)
	{
		m_assignedTarget = target;

		if (Vector3.Distance(transform.position, target.transform.position) > detectionRadius)
		{
			m_destination = target.transform.position;
		}
	}

	private void AutoAttack()
	{
		if (m_currentTarget != null)
		{
			// TODO: Attack.
		}
	}

	private SelectableUnit m_selectableUnit;

	private Vector3 m_destination;

	private GameObject m_assignedTarget;

	private GameObject m_currentTarget;

	private float m_detectionGap;
}
