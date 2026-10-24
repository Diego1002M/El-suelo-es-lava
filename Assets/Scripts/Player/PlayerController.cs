using UnityEngine;

namespace FloorIsLava
{
    /// <summary>
    /// Controlador básico de movimiento 3D para el personaje (Chipi).
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Movimiento")]
        [SerializeField] private float walkSpeed = 5.0f;
        [SerializeField] private float sprintSpeed = 8.5f;
        [SerializeField] private float jumpHeight = 2.0f;
        [SerializeField] private float gravity = -15.0f;

        [Header("Referencias")]
        [SerializeField] private Transform cameraTransform;

        private CharacterController controller;
        private Vector3 playerVelocity;
        private bool isGrounded;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            if (cameraTransform == null && Camera.main != null)
            {
                cameraTransform = Camera.main.transform;
            }
        }

        private void Update()
        {
            HandleMovement();
            HandleJumpAndGravity();
        }

        private void HandleMovement()
        {
            isGrounded = controller.isGrounded;
            if (isGrounded && playerVelocity.y < 0)
            {
                playerVelocity.y = -2f; // Mantener pegado al suelo
            }

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                // Mover en la dirección a la que apunta la cámara
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                float speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;
                controller.Move(moveDir.normalized * (speed * Time.deltaTime));

                // Rotar personaje hacia la dirección de movimiento
                transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            }
        }

        private void HandleJumpAndGravity()
        {
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            playerVelocity.y += gravity * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }

        public void TeleportTo(Vector3 position)
        {
            controller.enabled = false;
            transform.position = position;
            playerVelocity = Vector3.zero;
            controller.enabled = true;
        }
    }
}
