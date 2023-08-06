using UnityEngine;

namespace RotatingCubes.OOP
{
    public class OOP_Rotator : MonoBehaviour
    {
        [SerializeField] private int _cubeCount = 100_000;
        [SerializeField] private GameObject _cubePrefab;

        private void Start()
        {
            SpawnCubes();
        }
        private void SpawnCubes()
        {
            var spacing = 20.0f;
            
            for (var cubeIndex = 0; cubeIndex < _cubeCount; cubeIndex++)
            {
                var position = new Vector3(Random.Range(-spacing, spacing), Random.Range(-spacing, spacing), Random.Range(-spacing, spacing));
                var cube = Instantiate(_cubePrefab, position, Quaternion.identity);
                cube.AddComponent<CubeObject>();
            }
        }
    }
}