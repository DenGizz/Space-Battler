# About Repository

This repository is an example of the implementation of a simple mobile game built using Unity.

## About the Game

A sandbox game where two teams of spaceships fight against each other. The game offers a dynamic and engaging experience with various spaceship modules and upgrades available to players. It is designed to be easy to pick up and play, making it perfect for casual gamers.

The project is under development, with continuous updates and improvements being made to enhance gameplay and user experience.

## Technical Implementation

The game is built using the Unity engine, ensuring high performance and cross-platform compatibility. It leverages the Service-Oriented Architecture (SOA) for better modularity and scalability. Dependency injection is handled using Zenject.

Key features of the technical implementation include:

- **Service-Oriented Architecture (SOA):** Ensures that the game components are loosely coupled and can be developed, tested, and maintained independently.
- **Zenject:** Used for dependency injection.
- **Unity:** The primary game engine used for development.

### Entity Structure

In our game, each entity, such as a spaceship, consists of the following components:

1. **Model (Entity Data):** The model holds all the data related to the entity. For instance, `SpaceShipData` contains properties like health, speed, and weapon types.

2. **Controller (MonoBehaviour):** The controller is a script that inherits from `MonoBehaviour` and manages the entity's logic and behavior. For example, a `SpaceShipController` script would handle the movement, shooting, and interactions of the spaceship.

3. **Event Handlers (MonoBehaviour):** Other `MonoBehaviour` scripts are responsible for handling specific events triggered by the model. These scripts react to changes in the model and execute actions such as playing sounds, displaying visual effects (VFX), and applying damage. Examples include:
   - **PpayAudioBehaviour:** Plays sound effects when certain actions occur, like firing a weapon or taking damage.
   - **PlayVFXBehaviour:** Displays visual effects such as explosions or engine trails.
   - **DealDamageOnCollideBehaviour:** Processes projectile collide events and updates the spaceship's health.
   - **TeamFightAiBehaviour:** Controls the actions of spaceships during combat, taking into account their command prenature..

This structure ensures a clear separation of concerns, making the codebase more modular, maintainable, and scalable.

## Upcoming Tasks

- **Add Story Mode:** Develop a narrative-driven story mode to provide players with a richer and more immersive experience.
- **Implement Google Authorization:** Enable users to sign in with their Google accounts for a seamless and secure login experience.
- **Add Game Currency and Spaceship Module Store:** Introduce an in-game currency system and a store where players can purchase and upgrade spaceship modules.
- **Implement Advertising Service:** Integrate an advertising service to monetize the game while ensuring a non-intrusive experience for players.
- **Redesign UI:** Improve the user interface to enhance usability and aesthetic appeal.

## License

This repository is licensed under the Creative Commons Attribution-NoDerivatives 4.0 International Public License. You are permitted to view and examine the code for personal or educational purposes only. Any other use, including commercial use, modification, distribution, or incorporation into other projects, is strictly prohibited. See the [LICENSE](./LICENSE) file for more details.
