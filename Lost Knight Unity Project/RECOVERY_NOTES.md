# Lost Knight – recovered Unity project

This project was reconstructed from the Windows build in `../LOST KNIGHT/`
using [AssetRipper](https://github.com/AssetRipper/AssetRipper) 1.3.14.

## Opening it

1. Install **Unity 2020.3.21f1** through Unity Hub. That is the version the game was built with.
2. In Unity Hub choose **Add project from disk** and select this folder.
3. The first import rebuilds `Library/` and takes a few minutes.
4. Open `Assets/Scenes/StartScreen.unity` and press Play.

The build order is already set in Build Settings: StartScreen, ControlsScreen,
Level I–IV, EndScreen.

## What was recovered

| Folder | Contents |
| --- | --- |
| `Assets/Scripts/Assembly-CSharp` | All 15 game scripts, decompiled to C#. The player controller is `comp.cs`. |
| `Assets/Scenes` | All 7 scenes |
| `Assets/Sprite`, `Assets/Texture2D` | Sprites, sprite sheets, tiles |
| `Assets/AnimationClip`, `Assets/AnimatorController` | Player and enemy animations |
| `Assets/AudioClip` | Music and sound effects |
| `Assets/MonoBehaviour` | Tile assets, TMP font asset and other ScriptableObject data |
| `Assets/Resources` | TextMeshPro settings and resources |
| `ProjectSettings` | Tags, layers, input axes (including `Crouch`), physics 2D, quality and so on |

## Known differences from the original project

- **Comments are lost.** Code comments and some formatting could not be recovered.
  The logic, field names and `[SerializeField]` values are intact.
- **Packages.** The build shipped TextMeshPro and uGUI as compiled DLLs. These were
  replaced with the real Package Manager packages (`com.unity.textmeshpro` 3.0.6 and
  `com.unity.ugui` 1.0.0). Every scene, animation and asset reference was remapped from
  the DLL classes to the package scripts. Eleven more package DLLs in the build
  (Newtonsoft.Json, 2D Animation/IK/SpriteShape/PixelPerfect, Timeline, Mathematics and
  others) were not used by anything in the game, so they were removed. Add those
  packages through Package Manager if you need them. `com.unity.2d.sprite` and
  `com.unity.2d.tilemap` were added for the Sprite Editor and Tile Palette.
- **TextMeshPro shaders** were replaced with the real TMP 3.0.6 shader sources,
  because AssetRipper only produces placeholder shaders. Their GUIDs are unchanged.
- **Import settings and folders.** Asset import settings (compression, filter mode,
  pixels-per-unit) were reconstructed from the built data. Assets are grouped by
  type, not in your original folder layout, so you may want to reorganise them.
