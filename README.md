🎮 State Design Pattern in Unity
Ramazan YERGÜN

This project demonstrates the implementation of the State Design Pattern and a modular State Machine architecture in Unity for managing player behavior and animations.


📌 Project Purpose

This project was created to better understand and implement the State Design Pattern within Unity.

The main goal is to design a scalable and maintainable player state machine system that controls character behavior and animation transitions in a clean, modular way.


🧠 State Machine Architecture

The player controller is built using a State Machine architecture, where:

Each state (Idle, Run, Jump, Fall, etc.) is implemented as a separate class.

Every state handles its own logic and responsibilities.

The State Machine manages transitions between states.

The system is easily extendable for adding new behaviors.

This approach avoids complex conditional structures and improves maintainability.


🎮 Current Player States

GroundedState

JumpState

FallState


✨ Features

State Machine-based player controller

Modular and extendable architecture

Smooth animation transitions

Camera follow system

Clean separation of responsibilities


🚧 Work in Progress

Refining transition conditions

Adding new states (e.g., Attack)

Further optimization and refactoring


🛠 Project Information
Info	Value
Unity Version	6000.0.58f2
Render Pipeline	Built-in / URP


🚀 Installation

Clone the repository:

git clone https://github.com/Ramazanyergun/StateMachine_DP.git


Open the project in Unity Hub

Open: Assets/Scenes/SampleScene

Press Play
 

📚 What I Learned

Practical implementation of the State Design Pattern

Structuring scalable gameplay systems

Managing animation transitions with clean architecture

Writing maintainable and modular Unity code