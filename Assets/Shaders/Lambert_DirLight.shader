Shader "Learning/Lit/Lambert_DirLight"
{
	Properties
	{
		//RAJOUTER LA LUMIERE
	}

	SubShader
	{
		Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalPipeline" }
		Pass
		{
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			// Récupérez les data depuis le script LightData, attaché sur votre Directional Light
			float3 _WorldSpaceLightDir;
			float4 _LightColor;

			struct vertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float3 worldSpaceNormal : TEXCOORD0;
				// normal en world space
			};

			v2f vert(vertexInput v)
			{
				v2f o;

				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.worldSpaceNormal = normalize(mul(unity_ObjectToWorld, float4(v.normal,0)).xyz);
				// To do
				
				return o;
			}

			float4 frag(v2f i) : SV_Target
			{


				// To do => NdotL 

				// N & L dans le même espace et normalisés
				// L => direction reçue depuis le script C#. Forward de la DirLight
				// A inverser car côté shader, le vecteur de la lumière part depuis le fragment

				// dot retourne des valeurs entre -1 et 1, => clamp à utiliser
				i.worldSpaceNormal = normalize(i.worldSpaceNormal);
				float NdotL = clamp(dot(i.worldSpaceNormal, -_WorldSpaceLightDir), 0.05, 1);

				return NdotL;
			}
			
            ENDHLSL
        }
    }
}
