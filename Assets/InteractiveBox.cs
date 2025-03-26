using UnityEngine;

public class InteractiveBox : MonoBehaviour
{
    [SerializeField] private InteractiveBox next; // Ссылка на следующий объект
    private Renderer objRenderer;
    private LineRenderer lineRenderer;

    private void Start()
    {
        objRenderer = GetComponent<Renderer>();

        // Получаем или добавляем компонент LineRenderer
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>(); // Добавляем, если его нет
        }

        // Настройки LineRenderer для отображения линии
        lineRenderer.startWidth = 0.01f; 
        lineRenderer.endWidth = 0.01f;   
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.red; 
        lineRenderer.endColor = Color.black;   
        lineRenderer.positionCount = 2;      
    }

    public void AddNext(InteractiveBox box)
    {
        next = box; // Устанавливаем связь
    }

    private void Update()
    {
        if (next != null)
        {
            // Обновляем позиции для LineRenderer
            lineRenderer.SetPosition(0, transform.position);        // Начальная точка
            lineRenderer.SetPosition(1, next.transform.position);  // Конечная точка

            // Испускаем луч
            Vector3 direction = next.transform.position - transform.position;
            RaycastHit hit;

            if (Physics.Raycast(transform.position, direction, out hit))
            {
                // Если луч попал в препятствие, наносим урон
                ObstacleItem obstacle = hit.collider.GetComponent<ObstacleItem>();
                if (obstacle != null)
                {
                    obstacle.GetDamage(Time.deltaTime); // Плавное уничтожение
                }
            }
        }
    }
}
