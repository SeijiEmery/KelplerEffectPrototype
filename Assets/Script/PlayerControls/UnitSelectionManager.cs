using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages unit selection.
// KeyboardController + VRController should use this to send movement + targeting
// commands to all selected unit(s).
// A unit is selectable iff it has a SelectableUnit component.
public class UnitSelectionManager : MonoBehaviour
{
    private List<UnitMovement> moveableSelectedUnits = new List<UnitMovement>();
    private List<SelectableUnit> selectedUnits = new List<SelectableUnit>();

    public void AddUnitToSelection(SelectableUnit unit) {
        unit.Select(true);
        var movement = unit.GetComponent<UnitMovement>();
        if (movement != null)
        {
            moveableSelectedUnits.Add(movement);
        }
        selectedUnits.Add(unit);
    }
    public void RemoveUnitFromSelection(SelectableUnit unit) {
        unit.Select(false);
        var movement = unit.GetComponent<UnitMovement>();
        if (movement != null)
        {
            moveableSelectedUnits.Remove(movement);
        }
        selectedUnits.Remove(unit);
    }
    public void ClearSelection() {
        foreach (var unit in selectedUnits)
        {
            unit.Select(false);   
        }
        moveableSelectedUnits.Clear();
        selectedUnits.Clear();
    }

    public void MoveToPosition(Vector3 targetPos) {
        foreach (var unit in moveableSelectedUnits)
        {
            unit.SetMovementTarget(targetPos);
        }
    }
    public void TargetToPosition(Vector3 targetPos) {
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
