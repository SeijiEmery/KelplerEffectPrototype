using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubController : MonoBehaviour
{
	public bool Friendly { get; set; }

	[SerializeField]
	private float detectionRadius;

	[SerializeField]
	private float detectionInterval;
	private void Awake()
	{
		m_selectableUnit = GetComponent<SelectableUnit>();
	}
	private void Start()
	{
		StartCoroutine(DetectSurroundingObjects());
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
			if (!subController.Friendly)
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
