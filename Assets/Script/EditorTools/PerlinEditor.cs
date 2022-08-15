using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Debug = UnityEngine.Debug;
#if UNITY_EDITOR
public class PerlinEditor : EditorWindow
{ 
    private static PerlinEditor editorWindow;
   private static Texture2D PerlinImage;
   float[] perlinData = new float[8];
   private static Rect perlinRect;
   private static float[,] perlinArray;
   private static Color[] pixelsInPerlin;
   private float pixelDimensionsInImage = 200;
   private float scale = 1;
   private float coordinateX;
   private float coordinateY;
   private float frequency = 1;
   private float persistence = 1;
   private float lacunarity = 1;
   private int octaves = 1;
   
   private bool range1;
   private float range1Min;
   private float range1Max;
   private Color range1Color;
   
   private bool range2;
   private float range2Min;
   private float range2Max;
   private Color range2Color;
   
   private bool range3;
   private float range3Min;
   private float range3Max;
   private Color range3Color;
   
   private bool range4;
   private float range4Min;
   private float range4Max;
   private Color range4Color;
   
   private bool range5;
   private float range5Min;
   private float range5Max;
   private Color range5Color;

   private int space = 250;
   private float selectedEntry;
   private int rangeCount;
   private int perlinLoadoutIndex;
   private static string[] perlinLoadoutOptions;
   GUILayoutOption[] rangesRect = new GUILayoutOption[] { GUILayout.MaxWidth(84f) };
   GUILayoutOption[] rangeFieldsOptions = new GUILayoutOption[] {GUILayout.MaxWidth(35)};
   GUILayoutOption[] selectedEntryOptions = new GUILayoutOption[] {GUILayout.MinWidth(198)};
   [MenuItem("Custom Editor Tools / Perlin Editor")]
   
   public static void ShowWindow()
   {
       editorWindow = GetWindow<PerlinEditor>("Perlin Editor");
       editorWindow.maxSize = new Vector2(300, 500);
       editorWindow.minSize =new Vector2(300, 500);
       PerlinImage = new Texture2D(200, 200);
       perlinRect = new Rect(95, 80, PerlinImage.width, PerlinImage.height);
       pixelsInPerlin = new Color[200 * 200];
       perlinLoadoutOptions = new string[5] {"New Custom Loadout","Height Map", "Height Map Intensities", "Zones", "Forest Objects"};

   }
   
   private void OnGUI()
   {
       Repaint();
       AssignEntryAtMousePositionToSelectedEntry();
       
       GUILayout.BeginHorizontal();
       GUILayout.Space(95);
       
       GUILayout.BeginVertical(EditorStyles.helpBox,selectedEntryOptions);
       GUILayout.Label("Entry Selected:");
       GUILayout.Label(selectedEntry.ToString());
       GUILayout.EndVertical();
       GUILayout.EndHorizontal();
       
       
       GUILayout.BeginVertical(EditorStyles.helpBox,rangesRect);
       
       if (GUI.Button(new Rect(5, 5, 80, 20),"Add Range"))
       {
           ActivateRange();
       }
       
       if (range1)
       {
           GUILayout.BeginHorizontal();
           GUILayout.Label("Min");
           GUILayout.Label("Max");
           GUILayout.EndHorizontal();
           GUILayout.BeginHorizontal();
           range1Min = EditorGUILayout.FloatField(range1Min,rangeFieldsOptions);
           range1Max = EditorGUILayout.FloatField(range1Max,rangeFieldsOptions);
           GUILayout.EndHorizontal();
           range1Color = EditorGUILayout.ColorField(range1Color);
           range1Color.a = 1;
       }
       
       if (range2)
       {
           GUILayout.BeginHorizontal();
           GUILayout.Label("Min");
           GUILayout.Label("Max");
           GUILayout.EndHorizontal();
           GUILayout.BeginHorizontal();
           range2Min = EditorGUILayout.FloatField(range2Min,rangeFieldsOptions);
           range2Max = EditorGUILayout.FloatField(range2Max,rangeFieldsOptions);
           GUILayout.EndHorizontal();
           range2Color = EditorGUILayout.ColorField(range2Color);
           range2Color.a = 1;
       }
       
       if (range3)
       {
           GUILayout.BeginHorizontal();
           GUILayout.Label("Min");
           GUILayout.Label("Max");
           GUILayout.EndHorizontal();
           GUILayout.BeginHorizontal();
           range3Min = EditorGUILayout.FloatField(range3Min,rangeFieldsOptions);
           range3Max = EditorGUILayout.FloatField(range3Max,rangeFieldsOptions);
           GUILayout.EndHorizontal();
           range3Color = EditorGUILayout.ColorField(range3Color);
           range3Color.a = 1;
       }
       
       if (range4)
       {
           GUILayout.BeginHorizontal();
           GUILayout.Label("Min");
           GUILayout.Label("Max");
           GUILayout.EndHorizontal();
           GUILayout.BeginHorizontal();
           range4Min = EditorGUILayout.FloatField(range4Min,rangeFieldsOptions);
           range4Max = EditorGUILayout.FloatField(range4Max,rangeFieldsOptions);
           GUILayout.EndHorizontal();
           range4Color = EditorGUILayout.ColorField(range4Color);
           range4Color.a = 1;
       }
       
       if (range5)
       {
           GUILayout.BeginHorizontal();
           GUILayout.Label("Min");
           GUILayout.Label("Max");
           GUILayout.EndHorizontal();
           GUILayout.BeginHorizontal();
           range5Min = EditorGUILayout.FloatField(range5Min,rangeFieldsOptions);
           range5Max = EditorGUILayout.FloatField(range5Max,rangeFieldsOptions);
           GUILayout.EndHorizontal();
           range5Color = EditorGUILayout.ColorField(range5Color);
           range5Color.a = 1;
       }
       
       
       GUI.Box(perlinRect,PerlinImage);
       
       GUILayout.Space(space);
       GUILayout.EndVertical();
       
       perlinLoadoutIndex=EditorGUILayout.Popup("Select Perlin Loadout",perlinLoadoutIndex,perlinLoadoutOptions);
       
       GetPerlinLoadoutFromIndex();
       
       scale = EditorGUILayout.FloatField("Scale",scale);
       coordinateX = EditorGUILayout.FloatField("Coordinate X",coordinateX);
       coordinateY = EditorGUILayout.FloatField("Coordinate Y",coordinateY);
       frequency = EditorGUILayout.FloatField("Frequency",frequency);
       persistence = EditorGUILayout.FloatField("Persistence",persistence);
       lacunarity = EditorGUILayout.FloatField("Lacunarity",lacunarity);
       octaves = EditorGUILayout.IntField("Octaves",octaves);
   }
   
    void RenderPerlinImage()
    {
        perlinArray = PerlinGen.Generate(perlinData);
        for (int y = 0; y < 200; y++)
        {
            for (int x = 0; x < 200; x++)
            {
                float sample = perlinArray[x, y];
                pixelsInPerlin[x+(y*200)] = GetPerlinColorFromRange(sample);
            }
        }
        PerlinImage.SetPixels(pixelsInPerlin);
        PerlinImage.Apply();
    }

    private Color GetPerlinColorFromRange(float perlinEntry)
    {
        if (range1)
        {
            if (perlinEntry>range1Min&&perlinEntry<range1Max)
            {
                return range1Color;
            }
        }
        if (range2)
        {
            if (perlinEntry>range2Min&&perlinEntry<range2Max)
            {
                return range2Color;
            }
        }
        if (range3)
        {
            if (perlinEntry>range3Min&&perlinEntry<range3Max)
            {
                return range3Color;
            }
        }
        if (range4)
        {
            if (perlinEntry>range4Min&&perlinEntry<range4Max)
            {
                return range4Color;
            }
        }

        if (range5)
        {
            if (perlinEntry > range5Min && perlinEntry < range5Max)
            {
                return range5Color;
            }
        }
        return new Color(perlinEntry, perlinEntry, perlinEntry);
    }
    private void GetPerlinLoadoutFromIndex()
    {
        float[] localPerlinData;
        switch(perlinLoadoutIndex)
        {
            case 1:
                localPerlinData = PerlinArrays.GetHeightMapArray();
                SetPerlinVariablesFromPerlinArray(localPerlinData);
                break;
            case 2:
                localPerlinData = PerlinArrays.GetHeightIntensityArray();
                SetPerlinVariablesFromPerlinArray(localPerlinData);
                break;
            case 3:
                localPerlinData = PerlinArrays.GetZonesArray();
                SetPerlinVariablesFromPerlinArray(localPerlinData);
                break;
            case 4:
                localPerlinData = PerlinArrays.GetForestObjectArray();
                SetPerlinVariablesFromPerlinArray(localPerlinData);
                break;
        }

        perlinLoadoutIndex = 0;
    }

    private void AssignEntryAtMousePositionToSelectedEntry()
    {
        
        Vector2 mousePosition;
        if (Event.current.type==EventType.MouseDown)
        {
            mousePosition = Event.current.mousePosition;
            var perlinPosPlusWidth = perlinRect.x + perlinRect.width;
            var perlinPosPlusHeight = perlinRect.y + perlinRect.height;

            if (mousePosition.x > perlinRect.x & mousePosition.x < perlinPosPlusWidth && //if within perlinrect
                mousePosition.y > perlinRect.y & mousePosition.y < perlinPosPlusHeight)
            {
                var entryX = (int)(mousePosition.x - perlinRect.x);
                var entryY = (int)(mousePosition.y - perlinRect.y);
                
                entryY = Math.Abs(entryY - 200);
                
                selectedEntry = perlinArray[entryX,entryY];
                editorWindow.Repaint();
            }
        }
    }

    private void ActivateRange()
    {
        rangeCount++;
        switch (rangeCount)
        {
            case 1:
                range1 = true;
                space -= 50;
                break;
            case 2:
                range2 = true;
                space -= 50;
                break;
            case 3:
                range3 = true;
                space -= 50;
                break;
            case 4:
                range4 = true;
                space -= 50;
                break;
            case 5:
                range5 = true;
                space -= 50;
                break;
        }
    }
    void Update()
    {
        perlinData[0] = pixelDimensionsInImage;
        perlinData[1] = scale;
        perlinData[2] = coordinateY;
        perlinData[3] = coordinateX;
        perlinData[4] = frequency;
        perlinData[5] = lacunarity;
        perlinData[6] = persistence;
        perlinData[7] = octaves;
        
        RenderPerlinImage();
    }

    private void SetPerlinVariablesFromPerlinArray(float[] localPerlinData)
    {
        scale = localPerlinData[1];
        coordinateY = localPerlinData[2];
        coordinateX = localPerlinData[3];
        frequency = localPerlinData[4];
        lacunarity = localPerlinData[5];
        persistence = localPerlinData[6];
        octaves = (int)localPerlinData[7];
    }
    
}
#endif