using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RotatingCubes
{
    public class SceneLoader : MonoBehaviour
    {

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SceneManager.LoadScene(0, LoadSceneMode.Single);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SceneManager.LoadScene(1, LoadSceneMode.Single);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SceneManager.LoadScene(2, LoadSceneMode.Single);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                SceneManager.LoadScene(3, LoadSceneMode.Single);
            }
        }
    }
}
