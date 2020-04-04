using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// -----------
/// CISC 496 - Group P1 - Project: Eye Say
/// Description: Determine whether an object is within view
/// How to use: Takes gameobject as argument, returns a bool value
///     sends a ray out from the camera to the object
///     If any objects on layer 9 (environment) intersect with that ray
///         then the target is behind an environmetal obstacle is not considered seen
///     If object is not in front the camers it is not considered in view
///     Calculats using the "center" of the object,
///         Even if other parts of the target are visible, if the center is not
///         it will not be considered visible.
/// Written by: Sammy Chan
/// ----------
/// 

public class ViewCheck : MonoBehaviour
{

    public bool InView(GameObject target)
    {
        RaycastHit[] hit;


        Camera cam = gameObject.GetComponent<Camera>();
        int height = cam.pixelHeight;
        int width = cam.pixelWidth;
        Vector3 pos = transform.position;

        Vector3 upperLeft = cam.ScreenToWorldPoint(new Vector3(0, height, cam.nearClipPlane));
        Vector3 upperRight = cam.ScreenToWorldPoint(new Vector3(width, height, cam.nearClipPlane));
        Vector3 bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector3 bottomRight = cam.ScreenToWorldPoint(new Vector3(width, 0, cam.nearClipPlane));

        Debug.DrawRay(transform.position, target.transform.position - transform.position, Color.red);
        float distance = Vector3.Distance(pos, target.transform.position);
        hit = Physics.RaycastAll(pos, target.transform.position - transform.position, distance);
        foreach (RaycastHit gottem in hit)
        {
            //Debug.Log(gottem.collider.gameObject.name);
            if (gottem.collider.gameObject.layer == 9) //object in the way
            {
                return false;
            }
        }
        Collider targetCollider = target.GetComponent<Collider>();
        Vector3 relativePos = transform.InverseTransformPoint(target.transform.position);
        if (relativePos.z > 0)
        {
            //Debug.Log("In Front");
            ////Debug.Log("ScreenLeft:" + upperLeft.y + " ScrrenRight: " + upperRight.y);
            ////Debug.Log("object" + gottem.collider.transform.position.x);
            //Debug.Log("screen width " + width + " Sreend height: " + height);

            float targetWorldToCamXCoords = cam.WorldToScreenPoint(targetCollider.transform.position).x;
            float targetWorldToCamYCoords = cam.WorldToScreenPoint(targetCollider.transform.position).y;
            if (targetWorldToCamXCoords >= 0 && targetWorldToCamXCoords <= width)
            {
                if (targetWorldToCamYCoords >= 0 && targetWorldToCamYCoords <= height) //On screen
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            //Debug.Log("Behind");
            return false;
        }
        
    }
}
