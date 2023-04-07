Shader "Learning/Unlit/Tourniquet"
{
    Properties
    {
        // NOM_VARIABLE("NOM_AFFICHE_DANS_L'INSPECTOR", Shaderlab type) = defaultValue
        _Albedo0("Texture", 2D) = "white" {}
        _ScrollingSpeed("ScrollingSpeed", float) = 1
        _NormalFactor("Normal scrolling factor", float) = 1
    }

        SubShader
    {
        Tags { "RenderType" = "Opaque" }

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert  
            #pragma fragment frag

            #include "UnityCG.cginc"
            float _ScrollingSpeed, _NormalFactor;
            sampler2D _Albedo0;
			struct vertexInput
            {
                float4 vertex : POSITION;	
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };
			
            struct v2f
            {
                float4 vertex : SV_POSITION;   
                float2 uv : TEXCOORD0;
                float3 worldSpacePos : TEXCOORD0;
            };

            v2f vert (vertexInput v)
            {
                v2f o;
                v.uv.xy += float2(_Time.x * _ScrollingSpeed, 0);
                v.vertex.xyz += v.normal * _NormalFactor * tex2Dlod(_Albedo0, v.uv).r;
	            o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                return tex2D(_Albedo0, i.uv);
            }
            
            ENDHLSL
        }
    }
}
