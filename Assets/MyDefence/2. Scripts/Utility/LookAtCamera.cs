using UnityEngine;

namespace MyDefence
{
    public class LookAtCamera : MonoBehaviour
    {
        #region Variables
        private Camera mainCamera;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            mainCamera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            this.transform.LookAt(-mainCamera.transform.position);
        }
    }
}