using System.Collections;
using System.Collections.Generic;
using System.IO;

public class DataItem
{
    //public static float maxItemValue { get; set; } = float.MaxValue;
    public static float minItemValue { get; set; } = float.MaxValue;
    public static void ClearStaticValues()
    {
        //maxItemValue = float.MaxValue;
        minItemValue = float.MaxValue;
    }

    public DataItem(string name, float value, string imagePath, string flagPath, string info)
    {
        Name = name;
        Value = value;
        ImagePath = imagePath;
        FlagPath = flagPath;
        Info = info;

        if (minItemValue > value)
            minItemValue = value;
    }

    public string Name { get; private set; }
    public float Value { get; private set; }
    public string ImagePath { get; private set; }
    public string FlagPath { get; private set; }
    public string Info { get; private set; }

    public override string ToString()
    {
        string result = "";
        result = Name + ", " + Value + ", " + Info + ", " + ImagePath;
        return result;
    }
}

public sealed class DataReader
{
    public List<DataItem> Data { get; private set; }

    private DataReader()
    {
        Data = new List<DataItem>();
    }

    public void ReadFile(string path, char separetor)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new System.ArgumentException($"'{nameof(path)}' cannot be null or whitespace.", nameof(path));
        }
        DataItem.ClearStaticValues();

        List<DataItem> data = new List<DataItem>();
        // Read a text file line by line.  
        string[] lines = File.ReadAllLines(path);
        for (int i = 1; i < lines.Length; i++)
        {
            string[] fields = lines[i].Split(separetor);

            DataItem di = new(
                fields[0], float.Parse(fields[1].Replace(",", "").Replace("\"", "")), fields[2], fields[3], fields[4]
                );
            data.Add(di);
        }
        this.Data = data;


    }

    private static DataReader instance = null;
    public static DataReader Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DataReader();
            }
            return instance;
        }
    }


}


