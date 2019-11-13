using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;

public class VRRaycastSelector : MonoBehaviour
{
    private UnitSelectionManager selectionMgr;
    public SteamVR_PlayArea steamVRCameraRig;
    //public SteamVR_LaserPointer[] laserPointers;
    public SteamVR_Action_Boolean additiveSelectionButton;
    public SteamVR_Action_Boolean subtractiveSelectionButton;
    public string additiveSelectionKeyboardButton = "";
    public string subtractiveSelectionKeyboardButton = "";

    void Start()
    {
        selectionMgr = GetComponent<UnitSelectionManager>();
        var laserPointers = steamVRCameraRig.GetComponentsInChildren<SteamVR_LaserPointer>();
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
            selectable.HandleHovering(true);
        }
    }
    void OnUnhighlightObject(object sender, PointerEventArgs args)
    {
        var selectable = args.target.GetComponentInParent<SelectableUnit>();
        if (selectable != null)
        {
            selectable.HandleHovering(false);
        }
    }
    void OnSelectObject(object sender, PointerEventArgs args)
    {
        bool additive = (additiveSelectionButton != null && additiveSelectionButton.GetActive(SteamVR_Input_Sources.Any))
            || (additiveSelectionKeyboardButton != "" && Input.GetButton(additiveSelectionKeyboardButton));
        bool subtractive = subtractiveSelectionButton != null && subtractiveSelectionButton.GetActive(SteamVR_Input_Sources.Any)
            || (subtractiveSelectionKeyboardButton != "" && Input.GetButton(subtractiveSelectionKeyboardButton));
        if (!additive && !subtractive)
            selectionMgr.ClearSelection();

        if (additive)
            Debug.Log("additive selection");
        if (subtractive)
            Debug.Log("subtractive selection");

        var selectable = args.target.GetComponentInParent<SelectableUnit>();
        if (selectable != null)
        {
            if (additive || !subtractive)
                selectionMgr.AddUnitToSelection(selectable);
            else
                selectionMgr.RemoveUnitFromSelection(selectable);
        }
    }
}
