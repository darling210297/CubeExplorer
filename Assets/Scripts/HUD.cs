using UnityEngine;


public class HUD : MonoBehaviour
{
    void OnGUI()
    {
       
        GUIStyle big = new GUIStyle(GUI.skin.label) { fontSize = 26, fontStyle = FontStyle.Bold };
        GUIStyle small = new GUIStyle(GUI.skin.label) { fontSize = 16 };

        DrawText(new Rect(20, 20, 700, 40),
            $"Cubos de energía: {Collectible.Collected} / {Collectible.Total}", big);

        if (Collectible.Total > 0 && Collectible.Collected >= Collectible.Total)
        {
            DrawText(new Rect(Screen.width / 2 - 220, Screen.height / 2 - 60, 600, 50),
                "¡Recolectaste todos los cubos!", big);
        }

        DrawText(new Rect(20, Screen.height - 40, 1000, 30),
            "WASD: mover | Shift: correr | Espacio: saltar | Clic der./Q/E: girar cámara | Rueda: zoom", small);
    }

   
    void DrawText(Rect r, string text, GUIStyle style)
    {
        style.normal.textColor = Color.black;
        GUI.Label(new Rect(r.x + 2, r.y + 2, r.width, r.height), text, style);
        style.normal.textColor = Color.white;
        GUI.Label(r, text, style);
    }
}