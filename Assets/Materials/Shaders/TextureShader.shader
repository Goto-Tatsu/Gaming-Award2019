Shader "Custom/TextureShader"
{
	Properties
	{
		_MyTexture("Select Texture",2D) = "White"{} //【1】
	}
	SubShader
	{
		Tags { "RenderType" = "Opaque" }
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MyTexture; //【2】

		struct Input { //【3】
			float2 uv_MyTexture; //【3】
		}; //【3】

		void surf(Input IN, inout SurfaceOutput o) {
			o.Albedo = tex2D(_MyTexture,IN.uv_MyTexture).rgb; //【4】
		}
		ENDCG
	}
		FallBack "Diffuse"
}