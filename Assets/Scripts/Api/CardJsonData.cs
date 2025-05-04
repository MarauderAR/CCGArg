using System.Collections.Generic;

[System.Serializable]
public class CardJsonData
{
    public int id { get; set; }
    public string nombre { get; set; }
    public string descripcion { get; set; }
    public int costo { get; set; }
    public int influencia { get; set; }
    public int resistencia { get; set; }
}

[System.Serializable]
public class ApiResponse
{
    public List<CardJsonData> data { get; set; }
}