using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableUnit : MonoBehaviour {

    // is this unit currently selected?
    // set by UnitSelectionManager 
    public bool selected = false;

    [SerializeField] private Color selectionColor = Color.green;
    [SerializeField] private Color hoverColor = Color.cyan;

    public GameObject materialObj;
    private Material material;
    private Color initialColor;
    private void Start()
    {
        if (materialObj == null) materialObj = gameObject;
        material = materialObj.GetComponent<MeshRenderer>().material;
        initialColor = material.color;
    }

    private void Update()
    {

    }

    public void Select(bool selected)
    {
        material.color = selected ? selectionColor : initialColor;

        this.selected = selected;
    }

    public void HandleHovering(bool hoverOn)
    {
        if (hoverOn)
            material.color = hoverColor;
        else
            material.color = selected ? selectionColor : initialColor;
    }
}
