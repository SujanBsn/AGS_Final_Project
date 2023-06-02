using UnityEngine;
using System.IO;
using UnityEditor;

public class AudioSpectrumAnalyzer : MonoBehaviour
{
    // Audio clips to analyze and compare
    public AudioClip audioClip1;
    public AudioClip audioClip2;

    // Parameters for graph generation
    public int sampleSize = 512;
    public int graphWidth = 512;
    public int graphHeight = 256;
    public float amplitudeMultiplier = 10f;

    // Folder name for saving graph files
    public string folderName = "Plots";

    // Game objects to assign the generated graphs as sprites
    public GameObject graphObject1;
    public GameObject graphObject2;

    // UI text element to display the similarity percentage
    public UnityEngine.UI.Text similarityText;

    // Variables for storing the generated graph textures
    public Texture2D graphTexture1;
    public Texture2D graphTexture2;

    public void Awake()
    {
        // Empty out the Plots folder before generating the graphs
        EmptyPlotsFolder();

        // Create the graph textures with specified dimensions and format
        graphTexture1 = new Texture2D(graphWidth, graphHeight, TextureFormat.RGBA32, false);
        graphTexture1.wrapMode = TextureWrapMode.Clamp;

        graphTexture2 = new Texture2D(graphWidth, graphHeight, TextureFormat.RGBA32, false);
        graphTexture2.wrapMode = TextureWrapMode.Clamp;

        // Analyze the audio spectrum and generate graphs for the two audio clips
        AnalyzeAudioSpectrum(audioClip1, "SpectrumGraph1.png", graphObject1);
        AnalyzeAudioSpectrum(audioClip2, "SpectrumGraph2.png", graphObject2);

        // Compare the generated graphs and display the similarity percentage
        CompareGraphs("SpectrumGraph1.png", "SpectrumGraph2.png");
    }

    void EmptyPlotsFolder()
    {
        // Construct the folder path relative to the Assets folder
        string folderPath = Path.Combine("Assets", folderName);

        if (Directory.Exists(folderPath))
        {
            // Delete the folder if it already exists
            Directory.Delete(folderPath, true);
        }

        // Create a new directory for the plots
        Directory.CreateDirectory(folderPath);
    }

    public void AnalyzeAudioSpectrum(AudioClip clip, string fileName, GameObject graphObject)
    {
        // Initialize an array to store the audio spectrum data
        float[] spectrumData = new float[sampleSize];

        // Calculate the number of samples per step based on the graph width
        int totalSamples = clip.samples;
        int samplesPerStep = totalSamples / graphWidth;

        // Create an array to hold the colors of the graph pixels
        Color[] graphPixels = new Color[graphWidth * graphHeight];

        for (int i = 0; i < graphWidth; i++)
        {
            int startIndex = i * samplesPerStep;
            clip.GetData(spectrumData, startIndex);

            // Calculate the average amplitude for each step
            float averageAmplitude = 0f;
            for (int j = 0; j < sampleSize; j++)
            {
                averageAmplitude += Mathf.Abs(spectrumData[j]);
            }
            averageAmplitude /= sampleSize;

            // Calculate the height of the graph based on the average amplitude
            float height = averageAmplitude * graphHeight * amplitudeMultiplier;

            // Assign the appropriate color (white or black) to each pixel based on the height
            for (int j = 0; j < graphHeight; j++)
            {
                if (j < height)
                {
                    int pixelIndex = GetPixelIndex(i, j);
                    graphPixels[pixelIndex] = Color.white;
                }
                else
                {
                    int pixelIndex = GetPixelIndex(i, j);
                    graphPixels[pixelIndex] = Color.black;
                }
            }
        }

        // Get the corresponding graph texture based on the file name
        Texture2D graphTexture = new Texture2D(graphWidth, graphHeight, TextureFormat.RGBA32, false);
        graphTexture.wrapMode = TextureWrapMode.Clamp;

        // Set the pixels of the graph texture and apply the changes
        graphTexture.SetPixels(graphPixels);
        graphTexture.Apply();

        // Encode the graph texture to PNG format
        byte[] pngBytes = graphTexture.EncodeToPNG();

        // Construct the file path to save the graph image
        string folderPath = Path.Combine(Application.dataPath, folderName);
        string filePath = Path.Combine(folderPath, fileName);

        // Write the PNG bytes to a file
        File.WriteAllBytes(filePath, pngBytes);

        // Refresh the Asset Database to make Unity aware of the new file
        AssetDatabase.Refresh();

        // Load the saved PNG file as a sprite
        Sprite sprite = LoadSpriteFromFilePath(filePath);

        // Assign the sprite to the game object's SpriteRenderer component
        SpriteRenderer spriteRenderer = graphObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = sprite;
        }
    }


    int GetPixelIndex(int x, int y)
    {
        return x + y * graphWidth;
    }

    Sprite LoadSpriteFromFilePath(string filePath)
    {
        // Read the bytes of the file
        byte[] bytes = File.ReadAllBytes(filePath);

        // Create a new texture and load the image bytes into it
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(bytes);

        // Create a sprite using the loaded texture
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
    }

    public void CompareGraphs(string filePath1, string filePath2)
    {
        // Construct the file paths for the two graph images
        string path1 = Path.Combine(Application.dataPath, folderName, filePath1);
        string path2 = Path.Combine(Application.dataPath, folderName, filePath2);

        // Calculate the similarity percentage between the two graphs
        float similarityPercentage = CalculateSimilarity(path1, path2) * 100f;

        // Log the similarity percentage
        Debug.Log("Graph similarity: " + similarityPercentage.ToString("F2") + "%");

        // Update the similarity text on the UI
        if (similarityText != null)
        {
            similarityText.text = "Similarity: " + similarityPercentage.ToString("F2") + "%";
        }
    }

    public float CalculateSimilarity(string filePath1, string filePath2)
    {
        // Load the two graph images as textures
        Texture2D texture1 = LoadTextureFromFile(filePath1);
        Texture2D texture2 = LoadTextureFromFile(filePath2);

        // Check if the textures have the same dimensions
        if (texture1.width != texture2.width || texture1.height != texture2.height)
        {
            Debug.LogError("Graph images have different dimensions!");
            return 0f;
        }

        // Get the pixels of the two textures
        Color[] pixels1 = texture1.GetPixels();
        Color[] pixels2 = texture2.GetPixels();

        // Count the number of matching pixels
        int matchingPixels = 0;
        int totalPixels = pixels1.Length;

        for (int i = 0; i < totalPixels; i++)
        {
            if (pixels1[i] == pixels2[i])
            {
                matchingPixels++;
            }
        }

        // Calculate the similarity percentage
        float similarityPercentage = (float)matchingPixels / totalPixels;
        return similarityPercentage;
    }

    Texture2D LoadTextureFromFile(string filePath)
    {
        // Read the bytes of the file
        byte[] bytes = File.ReadAllBytes(filePath);

        // Create a new texture and load the image bytes into it
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(bytes);

        return texture;
    }
}
