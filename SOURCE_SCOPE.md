# Source scope and provenance

## Included

- `Assets/Scripts/**/*.cs`: authored gameplay, physics/merge orchestration, progression, persistence abstractions, tutorial, presentation, localization, effects, and platform adapter code.
- `ProjectSettings/ProjectVersion.txt`: original Unity editor version.
- `Packages/manifest.json`: original package dependency declaration; inspected before publication and no credential-like value was found.

The files under `Assets/Scripts/Yandex/**` and `Assets/Scripts/Languge/LangugeChangerYandex.cs` are the project's authored integration layer. The actual Yandex SDK is not included.

## Deliberately excluded

- `Assets/Yandex/**`: vendor SDK/plugin code.
- `Assets/TextMesh Pro/**`: vendor package content.
- `Assets/CameraScaler/**`: provenance not established for this portfolio snapshot.
- Scenes, prefabs, sprites, materials, sounds, videos, StreamingAssets, and other content assets.
- Unity-generated `.meta`, `.csproj`, `.sln`, `Library`, `Temp`, `Logs`, `obj`, and build output.
- Original Git metadata and history.

## Limitations

- This is a code-reading snapshot, not a standalone playable Unity checkout.
- Behaviour depends on serialized scene references and prefabs that are intentionally omitted.
- No automated test suite is included.
- Several public identifiers retain prototype-era spelling and naming.
- `Loss` retains a coroutine handle after cancellation until another flow replaces it, making repeated cancellation semantics less explicit than they should be.
- `TryToRemoveBalls` refuses a removal that would leave zero balls; this may be an intentional game rule but is not documented in code.
- Platform integrations cannot run without their omitted SDK and platform configuration.
- The snapshot demonstrates a cohesive gameplay/event flow, not production hardening, deterministic physics, or save migration.

