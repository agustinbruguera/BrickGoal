using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 touchPosition;
    private Camera mainCamera;

    public InputActionAsset inputActions; // Referencia al asset de Input Actions

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;

        var moveAction = inputActions.FindAction("Move");
        moveAction.performed += context => UpdateMoveInput(context.ReadValue<float>());
        moveAction.canceled += context => moveInput = Vector2.zero;
    }

    void UpdateMoveInput(float value)
    {
        moveInput.x = value;
    }

    void Update()
    {
        // Manejar entrada táctil
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            MovePaddleToPosition(touchPosition);
        }
        // Manejar entrada del mouse
        else if (Mouse.current != null && Mouse.current.leftButton.isPressed)
        {
            touchPosition = Mouse.current.position.ReadValue();
            MovePaddleToPosition(touchPosition);
        }
    }

    void MovePaddleToPosition(Vector2 screenPosition)
    {
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, 0));
        moveInput.x = worldPosition.x - transform.position.x;
    }

    void FixedUpdate()
    {
        Vector2 newPosition = rb.position + new Vector2(moveInput.x, 0) * speed * Time.fixedDeltaTime;
        rb.position = newPosition;
    }

    void OnEnable()
    {
        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Disable();
    }
}
