using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(MeshRenderer))]
public class TimeBloc : MonoBehaviour
{
    public Material matEnable;
    public Material matDisable;
    public float duration = 1;

    Collider col;
    Renderer render;
    float time = 0;

    private void Start()
    {
        col = GetComponent<Collider>();
        render = GetComponent<MeshRenderer>();
        if (col.enabled)
            render.material = matEnable;
        else
            render.material = matDisable;

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= duration)
        {
            Collider[] col = Physics.OverlapCapsule(transform.position  , transform.position + Vector3.up, 0.25f);
            if (col.Length <= 1)
            {
                time = 0;
                changeState();
            }
        }
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
