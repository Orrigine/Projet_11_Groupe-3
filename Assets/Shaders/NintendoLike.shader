Shader "Learning/Unlit/NintendoLike"
{
    Properties
    {
        // NOM_VARIABLE("NOM_AFFICHE_DANS_L'INSPECTOR", Shaderlab type) = defaultValue
        _Color0("Main Color", Color) = (0.1,0.5,0.3)
         _Color1("Main Color", Color) = (0.1,0.5,0.3)
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


            float4 _Color0, _Color1;
			struct vertexInput
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
			
            struct v2f
            {
                float4 vertex : SV_POSITION;   
                float3 worldSpacePos : TEXCOORD0;
                float3 worldSpaceNormal : TEXCOORD1;
            };

            v2f vert (vertexInput v)
            {
                v2f o;
	            o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
                o.worldSpacePos = mul(unity_ObjectToWorld, v.vertex).xyz;
                o.worldSpaceNormal = mul(unity_ObjectToWorld, float3(v.normal)).xyz;
                o.worldSpaceNormal = normalize(o.worldSpaceNormal);
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                float3 fragmentToCamera = _WorldSpaceCameraPos - i.worldSpacePos;
                fragmentToCamera = normalize(fragmentToCamera);

                i.worldSpaceNormal = normalize(i.worldSpaceNormal);

                float NdotV = dot(i.worldSpaceNormal, fragmentToCamera);

                //rim = pow(rim, _Exp);
                return NdotV; 
            }
            
            ENDHLSL
        }
    }
}
