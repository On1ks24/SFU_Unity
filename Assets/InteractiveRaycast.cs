using UnityEngine;

public class InteractiveRaycast : MonoBehaviour
{
    public GameObject prefab; // Префаб кубика с InteractiveBox
    public InteractiveBox selectedBox; // Текущий выбранный InteractiveBox

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Левый клик
        {
            HandleLeftClick();
        }

        if (Input.GetMouseButtonDown(1)) // Правый клик
        {
            HandleRightClick();
        }
    }

    // Обрабатываем левый клик
    private void HandleLeftClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("InteractivePlane")) // Клик по поверхности с тегом InteractivePlane
            {
                // Создаём экземпляр prefab в точке попадания луча
                Vector3 spawnPosition = hit.point + hit.normal * 0.5f; // Смещаем немного по нормали
                Instantiate(prefab, spawnPosition, Quaternion.LookRotation(hit.normal)); // Ориентируем объект по нормали
            }
            else if (hit.collider.GetComponent<InteractiveBox>() != null) // Клик по объекту с компонентом InteractiveBox
            {
                InteractiveBox clickedBox = hit.collider.GetComponent<InteractiveBox>();

                if (selectedBox == null) // Если нет выбранного объекта, сохраняем этот
                {
                    selectedBox = clickedBox;
                }
                else // Если объект уже выбран, добавляем его в next
                {
                    selectedBox.AddNext(clickedBox);
                    selectedBox = null; // Сбрасываем выбранный объект
                }
            }
        }
    }

    // Обрабатываем правый клик
    private void HandleRightClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            InteractiveBox clickedBox = hit.collider.GetComponent<InteractiveBox>();
            if (clickedBox != null)
            {
                Destroy(clickedBox.gameObject); // Удаляем объект с компонентом InteractiveBox
            }
        }
    }
}
