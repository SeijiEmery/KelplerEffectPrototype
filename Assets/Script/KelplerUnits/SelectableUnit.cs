using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableUnit : MonoBehaviour {

    // is this unit currently selected?
    // set by UnitSelectionManager 
    public bool selected { get; set; }

    // is this unit currently highlighted?
    // set by UnitSelectionManager
    // TODO: react to select + highlight changes by
    // changing material (or something...)
    // (or implement this in UnitSelectionManager)
    public bool highlighted { get; set; }
}
