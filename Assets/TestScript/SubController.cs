using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubController : MonoBehaviour
{
	public bool Friendly;

	[SerializeField]
	private float speed = 6.0f, bulletSpeed = 2.0f, shootingCooldown = 2.0f;

	[SerializeField]
	private float detectionRadius = 3;

	[SerializeField]
	private float detectionInterval = 1;

	private void Awake()
	{
		m_selectableUnit = GetComponent<SelectableUnit>();
	}

	private void Start()
	{
		StartCoroutine(DetectSurroundingObjects());
	}

	private void FixedUpdate()
	{
		if (Friendly && m_selectableUnit.selected)
			ControlledMove();
	}

	private void ControlledMove()
	{
		var movement = Vector3.forward * Input.GetAxis("MoveZ") + Vector3.up * Input.GetAxis("MoveY") + Vector3.right * Input.GetAxis("MoveX");
		transform.Translate(movement * speed * Time.fixedDeltaTime);
	}

	private IEnumerator DetectSurroundingObjects()
	{
		while (true)
		{
			Debug.Log("detect");

			Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, detectionRadius);

			foreach (Collider collider in nearbyColliders)
			{
				SubController subController = collider.gameObject.GetComponent<SubController>();

				if (subController != null)
				{
					m_nearbySubs.Add(subController);
				}
			}



			yield return new WaitForSeconds(detectionInterval);
		}
	}

	private void SetTarget()
	{
		foreach (SubController subController in m_nearbySubs)
		{
			if (!Friendly)
			{
				m_currentTarget = subController;
			}
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

	private List<SubController> m_nearbySubs = new List<SubController>();

	private SubController m_currentTarget;
}
