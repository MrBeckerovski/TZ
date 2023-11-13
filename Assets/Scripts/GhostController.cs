using UnityEngine;

public class GhostController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Скорость движения призрака
    public float turnSpeed = 100.0f; // Скорость поворота призрака

    private void Update()
    {
        MoveGhost();
        TurnGhost();
    }

    private void MoveGhost()
    {
        // Получаем ввод с клавиатуры для движения вперед/назад (W и S)
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * verticalInput; // Движение вперед/назад
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }

    private void TurnGhost()
    {
        // Получаем ввод с клавиатуры для поворотов (A и D)
        float horizontalInput = Input.GetAxis("Horizontal");
        float rotationAmount = horizontalInput * turnSpeed * Time.deltaTime; // Рассчитываем количество поворота
        transform.Rotate(0, rotationAmount, 0, Space.World); // Применяем поворот
    }

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, соприкасается ли объект с EA_Fruit_PRE
        if (other.gameObject.name == "EA_Fruit_PRE")
        {
            Destroy(other.gameObject); // Уничтожаем EA_Fruit_PRE
        }
    }
}
