using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RotatingCubes.OOP_Manager
{
    public class OOP_Manager_Rotator : MonoBehaviour
    {
        [SerializeField] private int _cubeCount = 100_000;
        [SerializeField] private GameObject _cubePrefab;
       // private JobHandle _jobHandle;
        private Transform[] _transforms;
        
        private void Start()
        {
            SpawnCubes();
        }
        private void SpawnCubes()
        {
            var spacing = 20.0f;
            _transforms = new Transform[_cubeCount];
            
            for (var cubeIndex = 0; cubeIndex < _cubeCount; cubeIndex++)
            {
                var position = new Vector3(Random.Range(-spacing, spacing), Random.Range(-spacing, spacing), Random.Range(-spacing, spacing));
                var cube = Instantiate(_cubePrefab, position, Quaternion.identity);
                _transforms[cubeIndex] = (cube.transform);
            }
        }
 
        private void Update()
        {
            RotateCubes();
        }
        
        private void RotateCubes()
        {
            for (int i = 0; i < _transforms.Length; i++)
            {
                _transforms[i].rotation *= quaternion.RotateY(10 * Time.deltaTime);
            }
        }
    }
}