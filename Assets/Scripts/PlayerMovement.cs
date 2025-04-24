using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float xRange = 8f;
    [SerializeField] float yRange = 4.5f;

    [SerializeField] float controlRollFactor = 20f;
    [SerializeField] float rotationSpeed = 10f;

    [SerializeField] float controlPitchFactor = 18f;
    [SerializeField] float pitchSpeed = 10f;
    Vector2 movement;
    void Start()
    {
        
    }

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }
    void ProcessRotation()
    {
        float roll = -controlRollFactor * movement.x;
        float pitch = -controlPitchFactor * movement.y;
        Quaternion targetRotation = Quaternion.Euler(pitch,
                                                0f,
                                                roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation,
                                                targetRotation,
                                                pitchSpeed * Time.deltaTime);
    }
    void ProcessTranslation()
    {
        float xOffset = movement.x * rotationSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = movement.y * rotationSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos,
                                             clampedYPos,
                                             0f);
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
}
