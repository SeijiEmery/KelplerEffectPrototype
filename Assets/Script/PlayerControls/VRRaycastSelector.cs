using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;

public class VRRaycastSelector : MonoBehaviour
{
    private UnitSelectionManager selectionMgr;
    public SteamVR_LaserPointer[] laserPointers;
    public List<SelectableUnit> highlighted;

    void Start()
    {
        selectionMgr = GetComponent<UnitSelectionManager>();
        if (laserPointers != null)
        {
            foreach (var laserPointer in laserPointers)
            {
                laserPointer.PointerIn += OnHighlightObject;
                laserPointer.PointerOut += OnUnhighlightObject;
                laserPointer.PointerClick += OnSelectObject;
            }
        }
    }
    public void OnHighlightObject(object sender, PointerEventArgs args)
    {
        var selectable = args.target.GetComponentInParent<SelectableUnit>();
        if (selectable != null)
        {
            selectable.highlighted = true;
        }
    }
    void OnUnhighlightObject(object sender, PointerEventArgs args)
    {
        var selectable = args.target.GetComponentInParent<SelectableUnit>();
        if (selectable != null)
        {
            selectable.highlighted = false;
        }
    }
    void OnSelectObject(object sender, PointerEventArgs args)
    {
        selectionMgr.ClearSelection();
        var selectable = args.target.GetComponentInParent<SelectableUnit>();
        if (selectable != null)
        {
            selectionMgr.AddUnitToSelection(selectable);
        }
    }
}
