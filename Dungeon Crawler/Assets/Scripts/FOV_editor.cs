using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FOV))]
public class FOV_editor : Editor
{
    void OnSceneGUI()
    {
        FOV fOV= (FOV)target;

        Handles.color = Color.white;
        Handles.DrawWireArc(fOV.transform.position, Vector3.up, Vector3.forward,360,fOV.Radius);

        Vector3 ViewAngle1 = DirectionFromangle(fOV.transform.eulerAngles.y,-fOV.View_Angle /2);
        Vector3 ViewAngle2 = DirectionFromangle(fOV.transform.eulerAngles.y, fOV.View_Angle /2);

        Handles.color = Color.red;
        Handles.DrawLine(fOV.transform.position, fOV.transform.position + ViewAngle1 * fOV.Radius);
        Handles.DrawLine(fOV.transform.position, fOV.transform.position + ViewAngle2 * fOV.Radius);

        if(fOV.Can_See_Player)
        {
            Handles.color = Color.green;
            Handles.DrawLine(fOV.transform.position, fOV.PlayerRef.transform.position);
        }
    }

    private Vector3 DirectionFromangle(float eaulerY,float angleInDeg)
    {
        angleInDeg += eaulerY;
        return new Vector3(Mathf.Sin(angleInDeg*Mathf.Deg2Rad),0, Mathf.Cos(angleInDeg*Mathf.Deg2Rad));
    }
}
