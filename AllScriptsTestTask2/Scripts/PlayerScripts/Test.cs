using UnityEngine;

public class Test : MonoBehaviour
{
    float boneAngle;
    float chstAngle;
    public float speedRotate;
    public Transform targetBone;
    public Transform chst;
    public Transform chestPivot;
    public Quaternion quaternion;
    public Vector3 rot;
    public Vector3 rotChstY;
    void FixedUpdate()
    {
         boneAngle += Input.GetAxis("Mouse X") * speedRotate * -Time.deltaTime;
         boneAngle = Mathf.Clamp(boneAngle, -100, 100);
         targetBone.localRotation = Quaternion.AngleAxis(boneAngle, Vector3.right);

         chstAngle += Input.GetAxis("Mouse Y") * speedRotate * -Time.deltaTime;
         chstAngle = Mathf.Clamp(chstAngle, -40, 40);
         chst.localRotation = Quaternion.AngleAxis(chstAngle, -Vector3.forward);


         rot = targetBone.localEulerAngles;
         rotChstY = chst.localEulerAngles;
         
    }
    public void LateUpdate()
    {
        chestPivot.localEulerAngles = rot;
        chst.localEulerAngles = rotChstY;
    }
}
