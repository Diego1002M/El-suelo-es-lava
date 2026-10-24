using System.Collections;
using UnityEngine;

namespace FloorIsLava
{
    /// <summary>
    /// Objeto/cojín que flota temporalmente en la lava antes de destruirse.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class FloatingObject : MonoBehaviour
    {
        [Header("Tiempos")]
        [SerializeField] private float burnDelay = 3.5f;
        [SerializeField] private float sinkSpeed = 1.0f;

        private bool isBurning = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name.Contains("Lava") && !isBurning)
            {
                StartCoroutine(BurnAndSinkRoutine());
            }
        }

        private IEnumerator BurnAndSinkRoutine()
        {
            isBurning = true;

            // Esperar el tiempo que flota de manera segura
            yield return new WaitForSeconds(burnDelay);

            // Hundirse
            float sinkTime = 1.5f;
            float elapsed = 0f;
            while (elapsed < sinkTime)
            {
                transform.position += Vector3.down * (sinkSpeed * Time.deltaTime);
                elapsed += Time.deltaTime;
                yield return null;
            }

            Destroy(gameObject);
        }
    }
}
