 # Shader Demo Env
 ​A small stylized environment demo, built as a deep dive into custom toon shading and procedural nature art in Unity.
 Every piece of foliage, shader here was hand-built. Grass and trees are modeled in Blender. 
 The whole scene runs on custom shaders featuring:
 **Try on itch.io :** https://kutpac.itch.io/nature-shader-demo
 
  - **Custom grass shader** — toon-banded lighting, Fresnel rim glow, per-clump color variation driven by world-space noise, and wind sway with per-instance phase offsets so fields of grass don't sway in
  unison.
  - **Custom tree shaders** — a canopy built from billboard leaf-card clusters scattered across a rounded base mesh, using a "borrowed normal" technique (baked via Blender Geometry Nodes into vertex color) so
  the flat cards shade as one continuous volume. A separate trunk shader with independently tunable toon banding, decoupled from the scene's real light direction.
  - **Custom water shader** for the shoreline.
  - **GPU-instanced terrain scattering** — grass and trees painted across a sculpted terrain using Unity's Detail Mesh / Tree systems.
  - **Hand-modeled assets** — grass blades and tree geometry modeled, sculpted, and UV'd in Blender, then exported and shaded in Unity Shader Graph.

## Tech stack
- Unity (Universal Render Pipeline)
- Shader Graph
- Cinemachine 3.x
- Unity Input System
- Blender (asset authoring: grass, tree trunk/canopy, geometry nodes scattering)
