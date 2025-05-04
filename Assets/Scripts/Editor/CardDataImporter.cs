using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

public class CardDataImporter : EditorWindow
{
    private string apiUrl = "https://api.politicscards.com/cards";  // Ajusta esto a tu URL real
    private string outputPath = "Assets/ScriptableObjects/Cards";
    private CardCollection cardCollection;

    [MenuItem("Tools/Card Data Importer")]
    public static void ShowWindow()
    {
        GetWindow<CardDataImporter>("Card Data Importer");
    }

    private void OnGUI()
    {
        GUILayout.Label("Card Data Importer", EditorStyles.boldLabel);

        apiUrl = EditorGUILayout.TextField("API URL", apiUrl);
        outputPath = EditorGUILayout.TextField("Output Path", outputPath);

        if (GUILayout.Button("Import Cards"))
        {
            ImportCardsAsync();
        }

        if (GUILayout.Button("Create Collection"))
        {
            CreateCardCollection();
        }
    }

    private async void ImportCardsAsync()
    {
        try
        {
            string jsonData = await FetchDataFromApi();
            if (string.IsNullOrEmpty(jsonData))
            {
                Debug.LogError("No se pudo obtener datos de la API");
                return;
            }

            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonData);
            ProcessCards(apiResponse.data);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error durante la importación: {e.Message}");
        }
    }

    private async Task<string> FetchDataFromApi()
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetStringAsync(apiUrl);
            return response;
        }
    }

    private void ProcessCards(List<CardJsonData> cards)
    {
        if (!Directory.Exists(outputPath))
        {
            Directory.CreateDirectory(outputPath);
        }

        foreach (var cardData in cards)
        {
            string assetPath = $"{outputPath}/Card_{cardData.id}.asset";
            
            ScriptableCard card = AssetDatabase.LoadAssetAtPath<ScriptableCard>(assetPath);
            
            if (card == null)
            {
                card = CreateInstance<ScriptableCard>();
                AssetDatabase.CreateAsset(card, assetPath);
            }

            UpdateCardData(card, cardData);
            EditorUtility.SetDirty(card);
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    private void UpdateCardData(ScriptableCard card, CardJsonData data)
    {
        card.NombreCarta = data.nombre;
        card.Descripcion = data.descripcion;
        card.CostoPoderPolitico = data.costo;
        card.Influencia = data.influencia;
        card.Resistencia = data.resistencia;
        // La ilustración se debe asignar manualmente por ahora
    }

    private void CreateCardCollection()
    {
        string collectionPath = $"{outputPath}/CardCollection.asset";
        
        cardCollection = AssetDatabase.LoadAssetAtPath<CardCollection>(collectionPath);
        
        if (cardCollection == null)
        {
            cardCollection = CreateInstance<CardCollection>();
            AssetDatabase.CreateAsset(cardCollection, collectionPath);
        }

        cardCollection.CardsInCollection = new List<ScriptableCard>();
        var guids = AssetDatabase.FindAssets("t:ScriptableCard", new[] { outputPath });
        
        foreach (var guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            var card = AssetDatabase.LoadAssetAtPath<ScriptableCard>(path);
            if (card != null && !cardCollection.CardsInCollection.Contains(card))
            {
                cardCollection.CardsInCollection.Add(card);
            }
        }

        EditorUtility.SetDirty(cardCollection);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}