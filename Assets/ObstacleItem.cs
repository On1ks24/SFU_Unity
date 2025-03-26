using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    public float currentValue = 1f; // "Здоровье" препятствия (от 0 до 1)
    public UnityEvent onDestroyObstacle;


    private Renderer objRenderer;

    private void Start()
    {
        objRenderer = GetComponent<Renderer>();
        UpdateColor();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Если нажали пробел
        {
            GetDamage(0.2f); // Наносим урон 20%
        }
    }
    public void GetDamage(float value)
    {
        currentValue -= value;
        currentValue = Mathf.Clamp01(currentValue); // Ограничиваем от 0 до 1
        UpdateColor();

        if (currentValue <= 0)
        {
            onDestroyObstacle.Invoke(); // Вызов события
            Destroy(gameObject); // Удаление объекта
        }
    }

    private void UpdateColor()
    {
        Color newColor = Color.Lerp(Color.red, Color.white, currentValue);
        objRenderer.material.color = newColor;

        Debug.Log("Меняем цвет: " + newColor); // Проверка
    }

    // Метод для нанесения урона другим объектам, можно вызывать из внешних скриптов
    public void ApplyDamage(float damage)
    {
        GetDamage(damage);
    }
}
