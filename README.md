# ObstacleDodgingGame
A time-based obstacle course built in Unity using C#. The player controls a cube and must cross three zones (Gare, Chantier, Forêt) as fast as possible while avoiding moving obstacles. Each zone is times, penalties are applied on collision, and high scores are recorded with player names. 

## Gameplay Overview
- Control a cube using keyboard movement
- Cross 3 zones in order:
  - Gare
  - Chantier
  - Foret
- Each zone has moving obstacles
- Collisions cause teleportation and time penalty
- Final screen displays:
  - Individual zone times
  - Total time
  - Best times with player names

## Project Structure
This project is split into multiple C# scripts, each handling a specific responsibility:
### DeplacementCube.cs
Handles:
- Player movement (keyboard input)
- Timer system
- UI updates (TextMeshPro)
- Penalties on collision
- Zone detection
- High scores comparison
- Game start / end logic
- Teleport cheat (N key)

### gareBouger.cs
**Train obtstacle movement**
- Moves horizontally between limits
- Speed is randomized at start
- Automatically changes direction at boundaries

### poutreBouger.cs
**Rotating beam obstacle**
- Random rotation axis
- Random rotation speed
- Continuous rotation using transform.Rotate()

### troncsTranslation.cs
**Vertical log movement**
- Moves logs up and down
- Speed changes depending on height
- Direction reverses at limits

## Technologies Used
- Unity
- C#
- TextMeshPro
- Unity UI
- Physics & Colliders
- Randomization

## Learning Objectives
- Modular game architecture
- Player movement and physics
- Timers and formatting
- UI management with TextMeshPro
- Collision handling
- Game state control
- Obstacle animation through code

## Possible Improvements
- Add sound effects
- Add difficulty levels
- Controller support

## License
This project is intended for educational purposes and is free to use and modify.
