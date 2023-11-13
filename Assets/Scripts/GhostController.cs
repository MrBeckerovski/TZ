using UnityEngine;

public class GhostController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // �������� �������� ��������
    public float turnSpeed = 100.0f; // �������� �������� ��������

    private void Update()
    {
        MoveGhost();
        TurnGhost();
    }

    private void MoveGhost()
    {
        // �������� ���� � ���������� ��� �������� ������/����� (W � S)
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * verticalInput; // �������� ������/�����
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }

    private void TurnGhost()
    {
        // �������� ���� � ���������� ��� ��������� (A � D)
        float horizontalInput = Input.GetAxis("Horizontal");
        float rotationAmount = horizontalInput * turnSpeed * Time.deltaTime; // ������������ ���������� ��������
        transform.Rotate(0, rotationAmount, 0, Space.World); // ��������� �������
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���������, ������������� �� ������ � EA_Fruit_PRE
        if (other.gameObject.name == "EA_Fruit_PRE")
        {
            Destroy(other.gameObject); // ���������� EA_Fruit_PRE
        }
    }
}
