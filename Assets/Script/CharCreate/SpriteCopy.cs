using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class SpriteCopy : MonoBehaviour
{

    public Object copyFrom;
    public Object copyTo;
    public void CopyPivotsAndSlices()
    {
        if (!copyFrom || !copyTo)
        {
            Debug.Log("Missing one object");
            return;
        }

        if (copyFrom.GetType() != typeof(Texture2D) || copyTo.GetType() != typeof(Texture2D))
        {
            Debug.Log("Cant convert from: " + copyFrom.GetType() + "to: " + copyTo.GetType() + ". Needs two Texture2D objects!");
            return;
        }

        string copyFromPath = AssetDatabase.GetAssetPath(copyFrom);
        TextureImporter ti1 = AssetImporter.GetAtPath(copyFromPath) as TextureImporter;
        ti1.isReadable = true;

        string copyToPath = AssetDatabase.GetAssetPath(copyTo);
        TextureImporter ti2 = AssetImporter.GetAtPath(copyToPath) as TextureImporter;
        ti2.isReadable = true;

        ti2.spriteImportMode = SpriteImportMode.Multiple;

        List<SpriteMetaData> newData = new List<SpriteMetaData>();

        for (int i = 0; i < ti1.spritesheet.Length; i++)
        {
            SpriteMetaData d = ti1.spritesheet[i];
            newData.Add(d);
        }
        ti2.isReadable = false;
        AssetDatabase.ImportAsset(copyToPath, ImportAssetOptions.ForceUpdate);
        ti2.isReadable = true;
        ti2.spritesheet = newData.ToArray();

        AssetDatabase.ImportAsset(copyToPath, ImportAssetOptions.ForceUpdate);

    }
}

