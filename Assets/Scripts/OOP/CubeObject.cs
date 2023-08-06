using Unity.Mathematics;
using UnityEngine;

namespace RotatingCubes.OOP
{
    public class CubeObject : MonoBehaviour
    {
        private void Update()
        {
            transform.rotation *= quaternion.RotateY(10 * Time.deltaTime);
        }
    }
}