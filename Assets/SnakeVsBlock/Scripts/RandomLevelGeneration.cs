using UnityEngine;
using Random = System.Random;

public class RandomLevelGeneration : MonoBehaviour
{
    public GameObject[] SectorPrefab;
    public GameObject FirstSectorPrefab;
    public int MinSectors;
    public int MaxSectors;
    public float DistanceBetweenSectors;
    public Transform Finish;
    public Transform Road;
    public MainGame MainGame;


    private void Awake()
    {
        int LevelIndex = MainGame.LevelIndex;
        Random random = new Random(LevelIndex);
        int sectorCount = RandomRange(random, MinSectors, MaxSectors + 1);

        for (int i = 0; i < sectorCount; i++)
        {
            int prefabindex = RandomRange(random, 0, SectorPrefab.Length);
            GameObject firstsector = i == 0 ? FirstSectorPrefab : SectorPrefab[prefabindex];
            GameObject sector = Instantiate(firstsector, transform);
            sector.transform.localPosition = SectorPosition(i);
        }

        Finish.localPosition = SectorPosition(sectorCount);
        Road.localScale = new Vector3(-sectorCount * DistanceBetweenSectors, 0, 0);
    }

    private int RandomRange(Random random, int min, int maxExclusive)
    {
        int number = random.Next();
        int length = maxExclusive - min;
        number %= length;
        return min + number;
    }

    private float RandomRange(Random random, float min, float max)
    {
        float t = (float)random.NextDouble();
        return Mathf.Lerp(min, max, t);
    }

    private Vector3 SectorPosition(int sectorindex)
    {
        return new Vector3(-DistanceBetweenSectors * sectorindex, 1f, 0);
    }
}
