# 3D Game Console Museum (Unity VR)

## Overview

Created in 2023, the 3D Game Console Museum is a virtual reality experience that showcases the history of 3D game consoles. Each room in the museum represents a different generation of consoles, featuring detailed information about their features, impact, and success. This project made extensive use of Unity's Virtual Reality (VR) capabilities, incorporating technologies such as occlusion culling, baked lighting, and Level of Detail (LOD) to enhance performance and immersion. Careful measures were also taken to minimize memory fragmentation, ensuring smooth performance throughout the experience.

<img src="https://github.com/user-attachments/assets/02740635-3dc6-4651-a7cb-8be4dc15ae2f" width="60%">

## Development & Features

Developed in Unity with Virtual Reality (VR) support. Accomplishments included:

- Optimized for performance using occlusion culling to improve rendering efficiency and baked lighting to enhance visual quality.
- Implemented LOD (Level of Detail) models for console pedestals, reducing resource usage while maintaining visual fidelity at various distances.
- Focused on memory optimization, using techniques to prevent memory fragmentation for smoother gameplay.
- Integrated menus tailored for the VR experience, allowing players to interact with interfaces intuitively in a 3D environment.
- Designed a unique cursor system using a blue cylinder, enabling players to walk around the museum and interact with consoles.
- Developed interactive pop-up billboard GUIs that appear when the player approaches a console, providing detailed information about each console's features and historical significance.

## Real-World Applications

This project allowed me to gain valuable experience in VR development using Unity, while focusing on performance optimization, UI/UX design in VR, and integrating dynamic interactions. It also helped me further hone my skills in handling 3D assets, including LOD models, and understanding how to efficiently manage resources in large-scale virtual environments.

## More screenshots showcasing the museum & features

<img src="https://github.com/user-attachments/assets/d2dfeb07-5d52-4cb3-82a9-9ad456b6d167" width="60%">

*Audio settings menu to be used in VR.*

<img src="https://github.com/user-attachments/assets/28e4eb48-19c2-4382-aad4-9b05bdebc5d3" width="60%">

*Blue cylinder is used as a cursor to allow the player to walk around.*

<img src="https://github.com/user-attachments/assets/679d048e-735a-4ef4-b6b9-4fb716fe7ebd" width="60%">

*Upon approaching a console, a billboard GUI appears along with information about the console.*

<img src="https://github.com/user-attachments/assets/80d38dd2-4688-441e-ae69-f3ee73f8b9b0" width="60%">

*Different LOD models for the console pedestals.*

## Installation

There are two approaches to installation. Downloading the build or downloading the source.

### Download Build

To download the latest build for the game, download it from the [releases page](https://github.com/yousefalshaikh17/3d-game-console-museum/releases/tag/latest). Windows 64 & Linux 64 are the only supported platforms at the moment. These releases are generated through GitHub actions workflows, but are manually reviewed before publication.

### Installing from source

1. Clone or fork the repository. Clone command:
```
git clone https://github.com/yousefalshaikh17/x-marks-the-spot.git
```
2. Open Unity Hub and load the project. **It is recommended to use Unity 6000.1.3f1.**
3. Unity will load all essential assets. Afterwards, you are able to modify the project or make a build yourself.

## Controls

There are two ways to control the player:
- Using a Google VR headset (Recommended)
- Holding down alt to simulate VR movement (Editor Only)

## Challenges & Learnings

This project was fairly straightforward. One of the main challenges was configuring Level-of-Detail (LOD) models to balance between performance and fidelity. This was resolved through thoroughly inspecting each model and balancing the triangle count. Another challenge was making sure that memory fragmentation is prevented. This taught me to properly make use of debuggers to track down performance issues.

