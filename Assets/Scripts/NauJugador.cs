using UnityEngine;
using UnityEngine.InputSystem;

public class NauJugador : MonoBehaviour
{
    float vel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vel = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        MovimentJugador();
        ControlLimitsPantalla();
    }

    void ControlLimitsPantalla()
    {
        Vector3 posicioActual = transform.position;
        posicioActual.x = Mathf.Clamp(
            posicioActual.x,
            ValorsGlobals.LimitEsquerraX,
            ValorsGlobals.LimitDretaX
        );

        posicioActual.y = Mathf.Clamp(
            posicioActual.y,
            ValorsGlobals.LimitInferiorY,
            ValorsGlobals.LimitSuperiorY
        );

        transform.position = posicioActual;
    }
    void MovimentJugador()
    {
        //Mirem si el jugador fer moviment horitzontal. Decidim fer servir les tecles "a" i "d".
        float movimentHoritzontal = Keyboard.current.aKey.isPressed ? -1f :
        Keyboard.current.dKey.isPressed ? 1f:
        0f;
        /*
            Només 3 possibles valors per movimentHoritzontal:
            -1 (esquerra), 1 (dreta) o 0 (no moviment horitzontal).
        */

        float movimentVertical = Keyboard.current.sKey.isPressed ? -1f :
        Keyboard.current.wKey.isPressed ? 1f:
        0f;

        // Vector3: té tres components o números: el x, el y i el z. L'ordre és (x, y, z).
        Vector3 vectorDesplacament = new Vector3(movimentHoritzontal, movimentVertical, 0);

        // Per assegurar-nos que la direcció no afecta la velocitat, normalitzem el vectorDesplacament.
        vectorDesplacament = vectorDesplacament.normalized;

        //Movem l'objecte segons: 1) la direcció (vectorDesplacament) i 2) la velocitat (vel).
        Vector3 nouDesplacament = new Vector3(
            vel * vectorDesplacament.x * Time.deltaTime,
            vel * vectorDesplacament.y * Time.deltaTime,
            0f
        );

        // transform.position: és la posició de l'objecte que té assignat aquest script.
        transform.position += nouDesplacament;
    }
}
