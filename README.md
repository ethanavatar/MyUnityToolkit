# MyUnityToolkit
A collection of scripts I use across Unity projects

# Installation

This library can be installed as a [unity package](https://docs.unity3d.com/Manual/upm-ui-giturl.html) using this url:
```
https://github.com/ethanavatar/MyUnityToolkit.git
```

# Contents

 - [CameraFollow](#CameraFollow)
 - [DynamicGravity](#DynamicGravity)
 - [PlayerController2D](#PlayerController2D)
 - [FirstPersonLook](#FirstPersonLook)

This package contains the following scripts:
### [CameraFollow](Scripts/CameraFollow.cs)

Attaches to a camera object and follows a target object using SmoothDamp, with a configurable **static** Vector3 offset.

### [DynamicGravity](Scripts/DynamicGravity.cs)

Attaches to a player object and increases the gravity scale based on releasing the jump button to create a variable jump height.

### [PlayerController2D](Scripts/PlayerController2D.cs)

A 2D player Controller that can be configured to be used as side-scrolling or top-down.

### [FirstPersonLook](Scripts/FirstPersonLook.cs)

A 3D FPS-like camera script