using UnityEngine;

public class GrassInstancer : MonoBehaviour
{
    private const int MaxBatchSize = 1023;

    [SerializeField] private Mesh bladeMesh;
    [SerializeField] private Material grassMaterial;
    [SerializeField] private int instanceCount;
    [SerializeField] private Vector2 fieldSize;
    [SerializeField] private float minScale;
    [SerializeField] private float maxScale;

    private Matrix4x4[][] batches;

    void Start()
    {
        GenerateBatches();
    }

    void GenerateBatches()
    {
        int batchCount = Mathf.CeilToInt(instanceCount / (float)MaxBatchSize);
        batches = new Matrix4x4[batchCount][];

        int remaining = instanceCount;
        for (int b = 0; b < batchCount; b++)
        {
            int countThisBatch = Mathf.Min(MaxBatchSize, remaining);
            batches[b] = new Matrix4x4[countThisBatch];

            for (int i = 0; i < countThisBatch; i++)
            {
                Vector3 localOffset = new Vector3(
                    Random.Range(-fieldSize.x * 0.5f, fieldSize.x * 0.5f),
                    0f,
                    Random.Range(-fieldSize.y * 0.5f, fieldSize.y * 0.5f)
                );

                Vector3 position = transform.position + localOffset;
                Quaternion rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
                float scale = Random.Range(minScale, maxScale);

                batches[b][i] = Matrix4x4.TRS(position, rotation, Vector3.one * scale);
            }

            remaining -= countThisBatch;
        }
    }

    void Update()
    {
        foreach (Matrix4x4[] batch in batches)
        {
            Graphics.DrawMeshInstanced(bladeMesh, 0, grassMaterial, batch);
        }
    }
}
