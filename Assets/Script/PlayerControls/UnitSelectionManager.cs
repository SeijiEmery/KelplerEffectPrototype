using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages unit selection.
// KeyboardController + VRController should use this to send movement + targeting
// commands to all selected unit(s).
// A unit is selectable iff it has a SelectableUnit component.
public class UnitSelectionManager : MonoBehaviour
{
	[SerializeField]
	private ControllableSubGroupManager subGroupManager;

	public List<SelectableUnit> SelectedUnits { get; } = new List<SelectableUnit>();

	private List<UnitMovement> moveableSelectedUnits = new List<UnitMovement>();

	public void AddUnitToSelection(SelectableUnit unit)
	{
        unit.selected = true;
        var movement = unit.GetComponent<UnitMovement>();
        if (movement != null)
        {
            moveableSelectedUnits.Add(movement);
        }
        SelectedUnits.Add(unit);
    }

    public void RemoveUnitFromSelection(SelectableUnit unit) 
	{
        unit.selected = false;
        var movement = unit.GetComponent<UnitMovement>();
        if (movement != null)
        {
            moveableSelectedUnits.Remove(movement);
        }
        SelectedUnits.Remove(unit);
    }

    public void ClearSelection()
	{
        foreach (var unit in SelectedUnits)
        {
            unit.selected = false;    
        }
        moveableSelectedUnits.Clear();
        SelectedUnits.Clear();
    }

    public void MoveToPosition(Vector3 targetPos)
	{
        foreach (var unit in moveableSelectedUnits)
        {
            unit.SetMovementTarget(targetPos);
        }
    }
    public void TargetToPosition(Vector3 targetPos)
	{
        foreach (var unit in moveableSelectedUnits)
        {
            unit.SetFiringTarget(targetPos);
        }
    }
    public void MoveInDirection(Vector3 normalizedMoveDir)
    {
        foreach (var unit in moveableSelectedUnits)
        {
            unit.MoveInDirection(normalizedMoveDir);
        }
    }

    public void TargetInDirection(Vector3 normalizedAimDir)
    {
        foreach (var unit in moveableSelectedUnits)
        {
            unit.AimInDirection(normalizedAimDir);
        }
    }
}
