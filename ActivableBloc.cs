using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(MeshRenderer))]
public class ActivableBloc : MonoBehaviour
{
    //ce script peut avoir son collider d'activé ou non via un objet avec le scipt lever
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

    //on change l'état et on applique le matèriaux en fonction de l'état actuel
    public void changeState()
    {
        col.enabled = !col.enabled;
        if (col.enabled)
            render.material = matEnable;
        else
            render.material = matDisable;
    }
}
