using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontoroler : MonoBehaviour {
#region public variables
    public static float OffSetX;
#endregion
#region private variables
#endregion
#region public method
#endregion
#region private method
    private void FixedUpdate()
    {
        if (birdcontoroler.birdobject != null)
        {
            if (birdcontoroler.birdobject.FlagLife)
            {
                MoveingCamera();
            }
        }
    }
    private void MoveingCamera()
    {
        Vector3 temp = transform.position;
        temp.x = birdcontoroler.birdobject.GivePosionToCamera()+OffSetX;
        transform.position = temp;
    }
#endregion
}
