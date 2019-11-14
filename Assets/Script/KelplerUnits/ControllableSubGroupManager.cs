using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllableSubGroupManager : MonoBehaviour
{
	public void Attack(List<SelectableUnit> selectedUnits)
	{
		List<SubController> attackers = new List<SubController>();
		List<GameObject> targets = new List<GameObject>();

		foreach (SelectableUnit unit in selectedUnits)
		{
			SubController subController = unit.GetComponent<SubController>();

			if (subController?.Faction == "f")
			{
				attackers.Add(subController);
			}
			else
			{
				targets.Add(unit.gameObject);
			}
		}

		if (attackers.Count == 0)
		{
			Debug.Log("You need to select some friendly subs to initiate an attack!");
			return;
		}

		if (targets.Count == 0)
		{
			Debug.Log("You need to select some non-friendly targets to attack!");
			return;
		}

		for (int i = 0; i < attackers.Count; i++)
		{
			attackers[i].ControlledAttack(targets[i % targets.Count]);
		}
	}
}
