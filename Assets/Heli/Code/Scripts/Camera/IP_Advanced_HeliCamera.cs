using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    public class IP_Advanced_HeliCamera : IP_Base_HeliCamera, IP_IHeli_Camera
    {

        #region Variables
        [Header("Advanced Camera properties")]
        public float height = 2f;
        public float minGroundHeight = 4f;
        public float minDistance = 4f;
        public float maxDistance = 8f;
        public float catchUpModifier = 5f;
        public float rotationSpeed = 5f;
        public float minVelocityForOrient = 5f;

        private float finalAngle;
        private Vector3 wantedDir;
        private float finalHeight;
        #endregion

        #region Built-in
        void Start()
        {
            updateEvent.AddListener(UpdateCamera);
        }

        private void OnDisable()
        {
            updateEvent.RemoveListener(UpdateCamera);
        }
        #endregion


        #region Interface Methods
        public void UpdateCamera()
        {
            // Get the flat direction from the helicopter to the camera
            Vector3 dirToTarget = transform.position - rb.position;
            dirToTarget.y = 0f;
            Vector3 normalizedDir = dirToTarget.normalized;
            wantedDir = normalizedDir;
            //Debug.DrawRay(rb.position, wantedDir, Color.green);



            // find angle between our Dir vector and our flat forward
            float angleToFwd = Vector3.SignedAngle(normalizedDir, targetFlatFwd, Vector3.up);
            //Debug.Log(angleToFwd);
            float wantedAngle = 0f;
            if(rb.velocity.magnitude > minVelocityForOrient)
            {
                wantedAngle = angleToFwd * Time.fixedDeltaTime;
            }
            finalAngle = Mathf.Lerp(finalAngle, wantedAngle, Time.fixedDeltaTime * rotationSpeed);
            wantedDir = Quaternion.AngleAxis(finalAngle, Vector3.up) * wantedDir;



            // re-position the camera based off of the min and max distance
            wantedPos = rb.position + (wantedDir * dirToTarget.magnitude);
            float curMagnitude = dirToTarget.magnitude;
            if(curMagnitude < minDistance)
            {
                float delta = minDistance - curMagnitude;
                wantedPos += wantedDir * delta * Time.fixedDeltaTime * catchUpModifier;
            }
            else if(curMagnitude > maxDistance)
            {
                float delta = curMagnitude - maxDistance;
                wantedPos -= wantedDir * delta * Time.fixedDeltaTime * catchUpModifier;
            }

            // Take into account the height from the ground
            float wantedHeight = height;
            RaycastHit hit;
            Ray groundRay = new Ray(transform.position, Vector3.down);
            if (Physics.Raycast(groundRay, out hit, 100f))
            {
                if(hit.transform.tag == "Ground" && hit.distance < minGroundHeight)
                {
                    wantedHeight += minGroundHeight - hit.distance;
                }
            }
            finalHeight = Mathf.Lerp(finalHeight, wantedHeight, Time.fixedDeltaTime);

            // Apply final Transformations
            transform.position = wantedPos + (Vector3.up * finalHeight);
            transform.LookAt(lookAtTarget);
        }
        #endregion

    }
}