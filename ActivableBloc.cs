using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(MeshRenderer))]
public class ActivableBloc : MonoBehaviour
{
    public Material matEnable;
    public Material matDisable;

    Collider col;
    Renderer render;

    private void Start()
    {
        col = GetComponent<Collider>();
        render = GetComponent<MeshRenderer>();
        if (col.enabled)
            render.material = matEnable;
        else
            render.material = matDisable;

    }

    public void changeState()
    {
        col.enabled = !col.enabled;
        if (col.enabled)
            render.material = matEnable;
        else
            render.material = matDisable;
    }
}
