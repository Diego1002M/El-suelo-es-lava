using UnityEngine;

namespace FloorIsLava
{
    /// <summary>
    /// Maneja la subida progresiva de la lava y el reinicio al caer.
    /// </summary>
    public class LavaHazard : MonoBehaviour
    {
        [Header("Ajustes de Lava")]
        [SerializeField] private float riseSpeed = 0.25f;
        [SerializeField] private float maxHeight = 12.0f;
        [SerializeField] private bool canRise = true;

        [Header("Punto de Reaparición")]
        [SerializeField] private Transform currentCheckpoint;

        private void Update()
        {
            if (canRise && transform.position.y < maxHeight)
            {
                transform.position += Vector3.up * (riseSpeed * Time.deltaTime);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("¡El jugador cayó a la lava!");

                PlayerController player = other.GetComponent<PlayerController>();
                if (player != null && currentCheckpoint != null)
                {
                    player.TeleportTo(currentCheckpoint.position);
                }

                if (GameManager.Instance != null)
                {
                    GameManager.Instance.LoseLife();
                }
            }
        }

        public void SetCheckpoint(Transform newCheckpoint)
        {
            currentCheckpoint = newCheckpoint;
        }

        public void StopLava()
        {
            canRise = false;
        }
    }
}
