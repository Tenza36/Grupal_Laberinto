/*// Importar los espacios de nombres necesarios
using System.Collections;
using System.Collections.Generic;
using UnityEditor.AssetImporters; // Este using es redundante y podría eliminarse, ya que no se utiliza
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView; // También redundante, no parece necesario

// Definir la clase del script y heredar de MonoBehaviour
public class NewBehaviourScript : MonoBehaviour
{

    // Definir variables públicas para la velocidad de movimiento y rotación
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;

    // Declarar variables para el movimiento horizontal y vertical
    public float horizontalMove;
    public float verticalMove;

    // Declarar una variable privada para el componente CharacterController
    private CharacterController player;

    // Método llamado al inicio de la ejecución
    void Start()
    {
        // Obtener el componente CharacterController del mismo objeto
        player = GetComponent<CharacterController>();
    }

    // Método llamado una vez por cada frame
    void Update()
    {
        // Obtener las entradas del teclado para el movimiento horizontal y vertical
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        // Rotar el objeto en el eje Y según la entrada horizontal
        transform.Rotate(0, horizontalMove * Time.deltaTime * velocidadRotacion, 0);

        // Calcular el avance en el espacio local
        Vector3 moveDirection = new Vector3(0, 0, verticalMove);
        moveDirection = transform.TransformDirection(moveDirection);

        // Aplicar el avance efectivo sobre el CharacterController
        player.Move(moveDirection * velocidadMovimiento * Time.deltaTime);
    }
}*/
