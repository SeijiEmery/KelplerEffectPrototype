using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages unit selection.
// KeyboardController + VRController should use this to send movement + targeting
// commands to all selected unit(s).
// A unit is selectable iff it has a SelectableUnit component.
public class UnitSelectionManager : MonoBehaviour
{
    // TODO: implement selection
    public void AddUnitToSelection(SelectableUnit unit) { }
    public void RemoveUnitFromSelection(SelectableUnit unit) { }
    public void ClearSelection() { }

    // TODO: should forward these commands to all selected unit(s)
    public void MoveToPosition(Vector3 targetPos) { }
    public void SetTargetingPosition(Vector3 targetPos) { }
    public void SetMovementDirection(Vector3 normalizedMoveDir) { }
}
