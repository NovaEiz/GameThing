using System;
using UnityEngine;

namespace Nighday {

[ExecuteInEditMode]
public class QuadOnFullScreen : MonoBehaviour {
    
    [Header(" - Settable fields")]
    [SerializeField] private Camera _camera;
    [SerializeField] private float _distance = 10;

    private void Change() {
        var cam  = _camera;
        var camTr = cam.transform;
        var ray1 = cam.ViewportPointToRay(new Vector3(0, 0));
        var ray2 = cam.ViewportPointToRay(new Vector3(1, 0));
        var ray3 = cam.ViewportPointToRay(new Vector3(1, 1));
        var ray4 = cam.ViewportPointToRay(new Vector3(0, 1));
        
        var p1 = ray1.origin + ray1.direction * _distance;
        var p2 = ray2.origin + ray2.direction * _distance;
        var p3 = ray3.origin + ray3.direction * _distance;
        var p4 = ray4.origin + ray4.direction * _distance;


        var scaleX = Mathf.Abs(p1.x - p3.x);
        var scaleY = Mathf.Abs(p1.y - p3.y);

        transform.position   = (p1 + p3) / 2;
        transform.localScale = new Vector3(scaleX, scaleY, 1);
        //transform.position = camTr.position + camTr.rotation * Vector3.forward * _distance;
        transform.rotation = Quaternion.LookRotation(camTr.rotation * Vector3.forward);
    }


    private void Update() {
        Change();
    }
    
    private void Awake() {
        Change();
    }
    
#if UNITY_EDITOR

    private void OnValidate() {
        Change();
    }
#endif

}

}