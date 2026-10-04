#  Cube Explorer – Terreno y movimiento de un cubo en Unity

**Asignatura:** ISWZ3411 – Desarrollo de Videojuegos
**Autor:** Darling Ortiz
**Versión de Unity:** Unity 6.6 (6000.6.4f1) – Universal Render Pipeline (URP)

##  Descripción

Escena 3D creada en Unity en la que el jugador controla un cubo que explora un
**valle rodeado de montañas nevadas**, diseñado con las herramientas de terreno de Unity.
El objetivo es recorrer el valle y recolectar los **5 cubos de energía** amarillos
que flotan y giran en distintos puntos del mapa. Al recolectarlos todos aparece un
mensaje de victoria.

**Video de demostración:** (https://youtu.be/UVoXe2PaeQM)


##  Características

- **Terreno personalizado:** montañas alrededor de un valle central, esculpidas con
  *Raise or Lower Terrain* y suavizadas con *Smooth Height*.
- **Texturas con Terrain Layers:** pasto en el valle, roca en las montañas, nieve en las
  cumbres y un camino de barro.
- **12 cubos en la escena:**
  - 1 cubo jugador (`player`)
  - 6 construcciones: `casa`, `casa2`, `torre`, `muro`, `puente` y `roca`, con materiales rojo y azul
  - 5 cubos de energía coleccionables con material amarillo
- **Jugador cubo** con física (Rigidbody): movimiento relativo a la cámara, sprint, salto
  y reaparición automática si cae del mapa.
- **Cámara en tercera persona** que sigue al jugador, con rotación y zoom.
- **Cubos coleccionables** que giran, flotan y desaparecen al tocarlos.
- **HUD en pantalla** con contador de cubos (`0 / 5`), mensaje de victoria y controles.

##  Controles

| Tecla | Acción |
|-------|--------|
| W A S D / Flechas | Mover el cubo |
| Shift izquierdo | Correr |
| Espacio | Saltar |
| Clic derecho + mouse / Q, E | Girar la cámara |
| Rueda del mouse | Acercar / alejar |

## Cómo ejecutar el proyecto

1. Clonar el repositorio o descargarlo como ZIP (botón **Code → Download ZIP**):
   ```bash
   git clone https://github.com/[tu-usuario]/CubeExplorer.git
   ```
2. Abrir **Unity Hub** → **Añadir / Add** → **Add project from disk** y seleccionar la carpeta del proyecto.
3. Abrir el proyecto con **Unity 6.6 (6000.6.4f1)** o una versión compatible de Unity 6.
   La primera vez tarda unos minutos en importar.
4. En la ventana **Project**, abrir `Assets/Scenes/SampleScene.unity`.
5. Presionar **Play** ▶️ y hacer clic dentro de la vista *Game*.

> Si aparece un error con `Input`, ir a **Edit → Project Settings → Player → Other Settings →
> Active Input Handling** y seleccionar **Both**.

## Cómo navegar la escena

- El jugador aparece en el centro del valle.
- Los cubos de energía están repartidos alrededor de las construcciones; algunos flotan
  un poco más alto y hay que **saltar** para alcanzarlos.
- El contador de la esquina superior izquierda indica cuántos faltan.

##  Estructura

```
Assets/
├── Scenes/
│   └── SampleScene.unity        Escena principal
├── Scripts/
│   ├── PlayerCubeMovement.cs    Movimiento, sprint, salto y reaparición del jugador
│   ├── CameraFollow.cs          Cámara en tercera persona
│   ├── Rotator.cs               Rotación y flotación de cubos
│   ├── Collectible.cs           Lógica de cubos coleccionables y contador
│   └── HUD.cs                   Contador, mensaje de victoria y controles en pantalla
├── Materials/                   Materiales rojo, azul y energía
└── TerrainSampleAssets/         Capas y texturas usadas en el terreno
```

## Assets utilizados

- [Terrain Sample Asset Pack](https://assetstore.unity.com) – Unity Technologies (gratuito, Unity Asset Store).
  Solo se conservaron las capas de pasto, barro, roca y nieve.
