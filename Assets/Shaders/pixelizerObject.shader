Shader "Custom/pixelizerObject"
{
	Properties 
	{
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_pixelizationLevel ("Pixelization Level", Int) = 1
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
		#pragma surface surf Standard fullforwardshadows
		#pragma target 3.0
		sampler2D _MainTex;
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