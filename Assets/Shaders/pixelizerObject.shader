Shader "Custom/pixelizerObject"
{
	Properties 
	{
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" "Queue" = "Geometry-1"}

		Stencil 
		{
			Ref 1
			Comp Always
			Pass Replace
		}
		CGPROGRAM
		#pragma vertex vert
		#pragma surface surf Standard fullforwardshadows
		#pragma target 3.0
		
		sampler2D _MainTex;
		//float4 _MainTex_ST;
		
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
		v2f vert (appdata v)
		{
			v2f o;
			o.vertex = UnityObjectToClipPos(v.vertex);
			//o.vertex.z *= 1000;
			/*
			o.uv = TRANSFORM_TEX(v.uv, _MainTex);
			*/
			UNITY_TRANSFER_FOG(o,o.vertex);
			return o;
		}
		
		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf (Input IN, inout SurfaceOutputStandard o) {
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
		}
		ENDCG
	}
	FallBack "Diffuse"
}