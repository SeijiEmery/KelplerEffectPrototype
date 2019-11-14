using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelector : MonoBehaviour
{
    private UnitSelectionManager selectionManager;

    [SerializeField]
    new private Camera camera;

    private GameObject lastHit;

    // Start is called before the first frame update
    void Start()
    {
        selectionManager = GetComponent<UnitSelectionManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ////////////////////////////
        /// Mouse input
        ////////////////////////////
        Vector3 mousePos = Input.mousePosition;
        Ray ray = camera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (lastHit != null)
        {
            UnhighlightObject(lastHit);
            lastHit = null;
        }
        if (Physics.Raycast(ray, out hit))
        {
            lastHit = hit.collider.gameObject;
            HighlightObject(lastHit);
            SelectableUnit unit = lastHit.GetComponent<SelectableUnit>();
            if (unit != null && Input.GetMouseButtonDown(0))
            {
                if (unit.selected)
                    selectionManager.RemoveUnitFromSelection(unit);
                else
                    selectionManager.AddUnitToSelection(unit);
            }
        }
    }

    public void HighlightObject(GameObject go)
    {
        var selectable = go.GetComponent<SelectableUnit>();
        if (selectable != null)
        {
            selectable.highlighted = true;
        }
    }
    void UnhighlightObject(GameObject go)
    {
        var selectable = go.GetComponentInParent<SelectableUnit>();
        if (selectable != null)
        {
            selectable.highlighted = false;
        }
    }
}
