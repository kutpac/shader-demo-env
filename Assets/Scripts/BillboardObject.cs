using UnityEngine;

  public class BillboardObject : MonoBehaviour
  {
      public Transform cam;
      public Vector3 rotationOffset = Vector3.zero;

      void LateUpdate()
      {
          if (cam == null) return;

          transform.LookAt(transform.position + (transform.position - cam.position));
          transform.Rotate(rotationOffset);
      }
  }