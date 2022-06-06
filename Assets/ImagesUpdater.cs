using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public static class ImageUpdater
{

    private static byte[] LoadPNG(string filePath)
    {
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            return fileData;
        }
        return null;
    }

    private static Texture2D ToTexture2D(Texture texture)
    {
        return Texture2D.CreateExternalTexture(
            texture.width,
            texture.height,
            TextureFormat.RGB24,
            false, false,
            texture.GetNativeTexturePtr());
    }

    public static void UpdateTexture(string imagePath, RawImage ri)
    {
        Texture txtr = ri.texture;
        Texture2D t2d = ToTexture2D(txtr);

        t2d.LoadImage(LoadPNG(imagePath));

        ri.texture = t2d;
    }


}