using UnityEngine;
using UnityEngine.SceneManagement;

namespace FloorIsLava
{
    /// <summary>
    /// Administrador del estado de la partida: vidas, tiempo y condición de victoria.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [Header("Estado de Partida")]
        [SerializeField] private int maxLives = 3;
        [SerializeField] private float levelTime = 120f; // 2 minutos

        private int currentLives;
        private float timeRemaining;
        private bool isGameOver = false;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);

            currentLives = maxLives;
            timeRemaining = levelTime;
        }

        private void Update()
        {
            if (isGameOver) return;

            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                TriggerGameOver("¡Se acabó el tiempo! La habitación quedó sumergida.");
            }
        }

        public void LoseLife()
        {
            if (isGameOver) return;

            currentLives--;
            Debug.Log($"Vidas restantes: {currentLives}/{maxLives}");

            if (currentLives <= 0)
            {
                TriggerGameOver("¡Te quedaste sin vidas!");
            }
        }

        public void WinLevel()
        {
            if (isGameOver) return;
            isGameOver = true;
            Debug.Log("¡NIVEL COMPLETADO! Has escapado por la ventilación.");
        }

        private void TriggerGameOver(string reason)
        {
            isGameOver = true;
            Debug.Log($"GAME OVER: {reason}");
            // En la entrega final aquí se carga la pantalla de reinicio
        }
    }
}
