using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableUnit : MonoBehaviour {

    // is this unit currently selected?
    // set by UnitSelectionManager 
    public bool selected = false;

    // is this unit currently highlighted?
    // set by UnitSelectionManager
    public bool highlighted = false;

    public Color selectionColor = Color.green;
    public Color highlightColor = Color.cyan;

    private Material material;
    private Color initialColor;
    protected void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        initialColor = material.color;
    }

    // very inefficient, but whatever, this is a prototype
    protected void Update()
    {
        material.color = selected ? selectionColor : highlighted ? highlightColor : initialColor;
    }
}
