using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerT;
    public Transform cameraT;
    [SerializeField]
    //public int portal = 0;

    void Update()
    {
        // Verifica se a referência para o transform do jogador não é nula
        if (playerT != null)
        {
            // Atualiza a posição da câmera usando os limites definidos e a posição atual do jogador
            cameraT.position = new Vector3(
                Mathf.Clamp(playerT.position.x, -75.6f, -34.15f), // Limita a posição horizontal da câmera
                Mathf.Clamp(playerT.position.y, 1.2f, 57.7f), // Limita a posição vertical da câmera
                -10); // Mantém a profundidade da câmera fixa

            // Mathf.Clamp é usado para limitar a posição da câmera dentro de valores mínimos e máximos
        }
    }
}