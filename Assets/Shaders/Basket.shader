Shader "Learning/Unlit/Basket"
{
    Properties
    {
        // NOM_VARIABLE("NOM_AFFICHE_DANS_L'INSPECTOR", Shaderlab type) = defaultValue
        _Amplitude("Max Amplitude", float) = 1
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
            float _Amplitude;
			struct vertexInput
            {
                float4 vertex : POSITION;						
            };
			
            struct v2f
            {
                float4 vertex : SV_POSITION; 
                float3 worldSpacePos : TEXCOORD0;
            };

            v2f vert (vertexInput v)
            {
                v2f o;

                v.vertex.y += sin(_Time.y) * _Amplitude;
	            o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);

                o.worldSpacePos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                float value = saturate(i.worldSpacePos.y);
                return float4(value,value,value,1);
            }
            
            ENDHLSL
        }
    }
}
