using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour
{

    [System.Serializable]
    class ParallaxedObject
    {
        public string label = "Parallaxed Object";
        public Transform transform;
        public bool xParallax = true;
        public bool yParallax = false;
    }

    [Tooltip("1 unit for every x unit(s) of camera movement laterally."), SerializeField]
    ParallaxedObject[] parallaxedObjects;
    public float maxDistance;

    Vector2 cameraPos;

    void LateUpdate()
    {
        Vector2 newCameraPos = Camera.main.transform.position;
        if (newCameraPos != cameraPos)
        {
            foreach (ParallaxedObject parallaxedObject in parallaxedObjects)
            {
                float ratio = Mathf.Clamp01(parallaxedObject.transform.position.z / maxDistance);

                Vector2 translation = Vector2.zero;

                if (parallaxedObject.xParallax)
                    translation.x += (newCameraPos.x - cameraPos.x) * ratio;

                if (parallaxedObject.yParallax)
                    translation.y += (newCameraPos.y - cameraPos.y) * ratio;

                if (translation.sqrMagnitude != 0)
                    parallaxedObject.transform.Translate(translation);
            }
            cameraPos = newCameraPos;
        }
    }
}
