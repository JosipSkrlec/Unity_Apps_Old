using UnityEditor;
using UnityEngine;

// skripta se koristi samo za vizualizaciju za edit scene u editoru
[ExecuteInEditMode]
public class DrawGizmos : MonoBehaviour
{
#if UNITY_EDITOR
    [Header("Gizmo Usage")]
    public bool DrawText = false;
    public bool DrawLine = false;
    public bool DrawSphere = false;

    [Header("Text")]
    public string TextForGizmo = "";
    public Vector3 PositionOfGizmoText;

    [Header("Line")]
    public Vector3 PositionOfGizmoLineStartPosition;
    public Vector3 PositionOfGizmoLineEndPosition;

    [Header("Sphere")]
    public Vector3 PositionOfGizmoSphere;
    public float SphereGizmoSize = 1;


    void OnDrawGizmos()
    {
        if (DrawText == true)
        {
            Handles.Label(PositionOfGizmoText, TextForGizmo);
        }
        if (DrawLine == true)
        {
            Handles.color = Color.red;
            Handles.DrawLine(PositionOfGizmoLineStartPosition, PositionOfGizmoLineEndPosition);
        }
        if (DrawSphere == true)
        {
            //Gizmos.DrawWireSphere(PositionOfGizmoSphere, SphereGizmoSize);
            Handles.color = Color.blue;
#pragma warning disable CS0618 // Type or member is obsolete
            Handles.SphereCap(0, PositionOfGizmoSphere, Quaternion.identity, SphereGizmoSize);
#pragma warning restore CS0618 // Type or member is obsolete
        }


    }



    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.blue;
        Gizmos.color = Color.blue;
    }

    private void OnGUI()
    {
        OnDrawGizmosSelected();
        OnDrawGizmos();
    }

#endif
}
