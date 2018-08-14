using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject ObstaclePrefab;
    public GameObject BackgroundPrefab;
    public GameObject ItemPrefab;

    [Header("Playerdata")]
    public GameObject Player;

    private float maxY = 0;
    private float yOffset = 15;
    private float maxYBackground = 0f;

    void Start()
    {

    }

    void Update()
    {

        if (Player.transform.position.y + yOffset >= maxY)
        {
            generateObstacles();
        }

        if(Player.transform.position.y + yOffset >= maxYBackground)
        {
            generateBackground();
        }

    }

    private void generateBackground()
    {
        GameObject newInstance = Instantiate(BackgroundPrefab);
        newInstance.transform.SetPositionAndRotation(new Vector3(newInstance.transform.position.x, maxYBackground, newInstance.transform.position.z), newInstance.transform.rotation);
        maxYBackground += 100;
    }

    private void generateObstacles()
    {
        maxY += 100;

        float lastY = Player.transform.position.y + 15;

        do
        {
            spawnObstacle(lastY);
            if(UnityEngine.Random.Range(0, 100) > 50)
            {
                spawnItem(lastY);
            }
            lastY += 20;
        } while (lastY <= maxY);
    }

    private void spawnItem(float lastY)
    {
        GameObject newInstance = Instantiate(ItemPrefab);
        newInstance.transform.SetPositionAndRotation(new Vector3(Player.transform.position.x, lastY + 10, Player.transform.position.z), Quaternion.Euler(new Vector3(-90 , 0 , 0)));
        string col = getRandomColor();
        newInstance.tag = col;
        newInstance.GetComponent<Renderer>().material.color = interpreteColor(col);
    }

    private string getRandomColor()
    {
        return "";
    }

    private Color interpreteColor(string col)
    {
        return new Color();
    }

    private void spawnObstacle(float lastY)
    {
        GameObject newInstance = Instantiate(ObstaclePrefab);
        newInstance.transform.SetPositionAndRotation(new Vector3(0, lastY, 0), Quaternion.Euler(new Vector3(90, 0, 0)));
        ObstacleController oc = newInstance.GetComponent(typeof(ObstacleController)) as ObstacleController;
        oc.rotationSpeed = getNewRotationSpeed();
    }

    private float getNewRotationSpeed()
    {
        {

            float dir = Random.Range(0, 101);

            if (dir > 50)
            {
                return Random.Range(40, 80);
            }
            else
            {
                return Random.Range(-80, -40);
            }
        }


    }
}
