using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class rotacionarCamera : MonoBehaviour
    {
        public float rotationSpeed = 2.0f; // Velocidade de rota��o da c�mera

        void Update()
        {
            // Obt�m as entradas do mouse para controlar a rota��o
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // Aplica a rota��o horizontal � c�mera (em torno do eixo vertical)
            Vector3 aux_X = Vector3.up;
            aux_X.z = 0;
            transform.Rotate(aux_X * mouseX * rotationSpeed);

            // Aplica a rota��o vertical � c�mera (em torno do eixo horizontal)
            Vector3 aux_Y = Vector3.left;
            aux_X.z = 0;
            transform.Rotate(aux_Y * mouseY * rotationSpeed);

            // Limita a rota��o vertical para evitar que a c�mera gire completamente
            Vector3 currentRotation = transform.eulerAngles;
            currentRotation.z = 0;
            //  currentRotation.x = Mathf.Clamp(currentRotation.x, -90f, 90f);
            transform.eulerAngles = currentRotation;
        }
    }
