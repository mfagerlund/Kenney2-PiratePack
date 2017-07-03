using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSortingLayer : MonoBehaviour
{
    public Renderer changeRenderer;
    public string sortingLayerName;
    void Start () {
        if(changeRenderer!=null && sortingLayerName!=null)
            changeRenderer.sortingLayerName = sortingLayerName;
    }
}
