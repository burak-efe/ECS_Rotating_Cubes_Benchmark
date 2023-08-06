# ECS_Rotating_Cubes_Benchmark

## very basic benchmark for observing performance difference between programming approachs in UNITY Game Engine.

## This benchmark not represent a real game, This becnhmark heavily latency bound due to accesing high amount of Gameobjects
and NOT ALU bound due to single rotating operation.

##Setup
100_000 cubes with no collider rotates in camera frustrum.

Sceneraios
OOP : A spawner spawns cubes, Cubes rotate their selfs in update().
OOP With Manager : A spawner spawns cubes, A Rotate System have referances of all cube gameobjects and roate them.
DOTS_No_ECS : A spawner spawns cubes, A Rotate System that uses Burst compiled IJobParallelForTransform rotate all cubes.
ECS :  A spawner System spawns cubes, A Rotate System that uses Burst compiled IJobEntity rotate all cube Entites.
 
Results (il2cpp, build, dev mode, profiler runs, x64, ryzen 2400g):

### OOP : total 140 ms, rotating cubes 60ms, rendering 45ms 
### OOP With Manager : total 90 ms, rotating cubes 42ms, rendering 45ms
### DOTS_No_ECS  : total 80 ms, rotating cubes 10ms, rendering 65ms
### ECS : total 5.5 ms, rotating cubes 0.02ms, rendering 5ms
