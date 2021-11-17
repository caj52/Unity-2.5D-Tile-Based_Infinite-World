Shader "Unlit/CameraPixelizer"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque""Queue"="Geometry" }
        Pass
        {
            //TESTED. THIS IS CORRECT
            Stencil
            {
                Ref 1
                Comp Equal
            }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _CameraDepthTexture;
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float clarity = 8;
                float pixelSize = 1;
                float2 uvs = i.uv;
                float depth = tex2D(_CameraDepthTexture, uvs).r;
                float2 multiplier = float2(80*clarity,25*clarity);
                
                UNITY_APPLY_FOG(i.fogCoord, col);
                depth /=200;
                depth = Linear01Depth(depth);
                pixelSize = floor(pixelSize*depth*10)/10;
                
                uvs = (floor(uvs*multiplier*pixelSize)/pixelSize)/multiplier;
                fixed4 col = tex2D(_MainTex, uvs);
                return col;
            }
            ENDCG
        }
        Pass
        {
            Stencil
            {
                Ref 0
                Comp Equal
            }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uvs = i.uv;
                UNITY_APPLY_FOG(i.fogCoord, col);
                fixed4 col = tex2D(_MainTex, uvs);
                return col;
            }
            ENDCG
        }
    }
    
}
