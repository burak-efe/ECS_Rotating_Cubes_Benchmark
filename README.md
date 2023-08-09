# ECS Rotating Cubes Benchmark

## Very basic benchmark for observing performance difference between programming approach in UNITY Game Engine.

## This benchmark not represent a real game, This benchmark heavily latency bound due to accessing high amount of GameObjects, and NOT ALU bound due to single rotating operation.

## Setup
100_000 cubes with no collider rotates in camera frustum.<br>

## Scenarios <br>
OOP : A spawner spawns cubes, Cubes rotate their self's in update(). <br>
OOP With Manager : A spawner spawns cubes, A Rotator GameObject have references of all cube GameObjects and rotate them. <br>
DOTS_No_ECS : A spawner spawns cubes, A Rotate System that uses Burst compiled IJobParallelForTransform rotate all cubes. <br>
ECS :  A spawner System spawns cubes, A Rotate System that uses Burst compiled IJobEntity rotate all cube Entites. <br>
 
## Results and observations (il2cpp, build, dev mode, profiler runs, x64, Ryzen 2400g): <br>

### OOP : total 140 ms, rotating cubes 60ms, rendering 45ms  <br>
Standard approach when developing game when using unity <br>
### OOP With Manager : total 90 ms, rotating cubes 42ms, rendering 45ms <br>
Since c# calls from c++ side are costly, packing processing in update function will result performance benefits. [See](https://xoofx.com/blog/2018/04/06/porting-unity-to-coreclr/#how-unity-is-currently-running-your.net-code)
### DOTS_No_ECS  : total 80 ms, rotating cubes 10ms, rendering 65ms <br>
like I said in the beginning this scenario not ALU bound and main hotpath is accessing high amount of objects, so job system parallelization and burst optimizations doesn't give much;
Also rendering system take more because looks like its need to update itself after transform jobs.
### ECS : total 5.5 ms, rotating cubes 0.02ms, rendering 5ms <br>
from unplayable on pc to VR ready :D since we use Dots transform component, the data we want to access is sequential in memory.
