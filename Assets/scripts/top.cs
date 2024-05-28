using UnityEngine;
using UnityEngine.SceneManagement;

public class TopScript : MonoBehaviour
{
    public float moveSpeed = 10f; // Topun hareket hızı
    private Rigidbody rb;
    public Transform cameraTransform; // Kamera hedefi
    public Vector3 offset; // Kamera ile top arasındaki mesafe
    public Transform startLocation; // Başlangıç konumu

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Topun başlangıç konumunu ayarla
        if (startLocation != null)
        {
            transform.position = startLocation.position;
        }
    }

    void FixedUpdate()
    {
        // Hareket yönünü al
        float xHorizontal = Input.GetAxis("Horizontal");
        float zVertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(xHorizontal, 0.0f, zVertical);

        // Rigidbody üzerinde hareketi uygula
        rb.AddForce(moveDirection * moveSpeed);

        // Açısal hızı sıfırla (topun kendi etrafında dönmesini engelle)
        rb.angularVelocity = Vector3.zero;
    }

    void LateUpdate()
    {
        // Kamerayı hedefe takip ettir
        if (cameraTransform != null)
        {
            cameraTransform.position = transform.position + offset;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Eğer top belirlenen küpe temas ederse sahneyi değiştir
        if (other.gameObject.CompareTag("GoalCube"))
        {
            SceneManager.LoadScene("Memory");
        }
    }
}

