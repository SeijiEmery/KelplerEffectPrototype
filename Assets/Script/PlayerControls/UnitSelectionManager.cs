using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages unit selection.
// KeyboardController + VRController should use this to send movement + targeting
// commands to all selected unit(s).
// A unit is selectable iff it has a SelectableUnit component.
public class SelectionManager : MonoBehaviour
{
    // TODO: implement selection
    void AddUnitToSelection(SelectableUnit unit) { }
    void RemoveUnitFromSelection(SelectableUnit unit) { }
    void ClearSelection(SelectableUnit unit) { }

    // TODO: should forward these commands to all selected unit(s)
    void MoveToPosition(Vector3 targetPos) { }
    void SetTargetingPosition(Vector3 targetPos) { }
    void SetMovementDirection(Vector3 normalizedMoveDir) { }
}
