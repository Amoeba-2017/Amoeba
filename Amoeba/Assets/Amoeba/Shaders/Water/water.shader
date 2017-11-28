// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.3853806,fgcg:0.6254027,fgcb:0.6470588,fgca:0.491,fgde:0.004,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9310,x:32719,y:32712,varname:node_9310,prsc:2|diff-8170-OUT,normal-9193-RGB,difocc-7897-OUT,voffset-5357-OUT;n:type:ShaderForge.SFN_Color,id:3924,x:32310,y:32581,ptovrint:False,ptlb:colour,ptin:_colour,varname:node_3924,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.7058823,c2:1,c3:0.9513185,c4:1;n:type:ShaderForge.SFN_Tex2d,id:9193,x:31979,y:32796,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_9193,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True|UVIN-9766-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:8572,x:32202,y:33032,varname:node_8572,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-9193-RGB;n:type:ShaderForge.SFN_Multiply,id:5357,x:32484,y:33076,varname:node_5357,prsc:2|A-8572-OUT,B-9538-OUT;n:type:ShaderForge.SFN_Slider,id:9538,x:32123,y:33298,ptovrint:False,ptlb:Offset,ptin:_Offset,varname:node_9538,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6325288,max:1;n:type:ShaderForge.SFN_TexCoord,id:5010,x:31640,y:32590,varname:node_5010,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:9766,x:31807,y:32600,varname:node_9766,prsc:2,spu:0.5,spv:0.05|UVIN-5010-UVOUT,DIST-5906-OUT;n:type:ShaderForge.SFN_Slider,id:9028,x:31181,y:33047,ptovrint:False,ptlb:Y,ptin:_Y,varname:node_9028,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-3,cur:-0.07692309,max:3;n:type:ShaderForge.SFN_Time,id:3963,x:31355,y:32784,varname:node_3963,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5906,x:31624,y:32760,varname:node_5906,prsc:2|A-3963-T,B-9028-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7897,x:32338,y:32944,ptovrint:False,ptlb:Ambient Occ.,ptin:_AmbientOcc,varname:node_7897,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Tex2d,id:3004,x:32235,y:32391,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_3004,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False|UVIN-5316-UVOUT;n:type:ShaderForge.SFN_Multiply,id:8170,x:32471,y:32500,varname:node_8170,prsc:2|A-3004-RGB,B-3924-RGB;n:type:ShaderForge.SFN_Panner,id:5316,x:32048,y:32391,varname:node_5316,prsc:2,spu:0.01,spv:0.2|UVIN-3467-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:3467,x:31850,y:32391,varname:node_3467,prsc:2,uv:0,uaff:False;proporder:3924-9193-9538-9028-7897-3004;pass:END;sub:END;*/

Shader "Custom/water" {
    Properties {
        _colour ("colour", Color) = (0.7058823,1,0.9513185,1)
        _Normal ("Normal", 2D) = "bump" {}
        _Offset ("Offset", Range(0, 1)) = 0.6325288
        _Y ("Y", Range(-3, 3)) = -0.07692309
        _AmbientOcc ("Ambient Occ.", Float ) = 0.5
        _Texture ("Texture", 2D) = "black" {}
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _colour;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float _Offset;
            uniform float _Y;
            uniform float _AmbientOcc;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 node_3963 = _Time;
                float2 node_9766 = (o.uv0+(node_3963.g*_Y)*float2(0.5,0.05));
                float3 _Normal_var = UnpackNormal(tex2Dlod(_Normal,float4(TRANSFORM_TEX(node_9766, _Normal),0.0,0)));
                v.vertex.xyz += float3((_Normal_var.rgb.rg*_Offset),0.0);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_3963 = _Time;
                float2 node_9766 = (i.uv0+(node_3963.g*_Y)*float2(0.5,0.05));
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(node_9766, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                indirectDiffuse *= _AmbientOcc; // Diffuse AO
                float4 node_8438 = _Time;
                float2 node_5316 = (i.uv0+node_8438.g*float2(0.01,0.2));
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(node_5316, _Texture));
                float3 diffuseColor = (_Texture_var.rgb*_colour.rgb);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _colour;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float _Offset;
            uniform float _Y;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 node_3963 = _Time;
                float2 node_9766 = (o.uv0+(node_3963.g*_Y)*float2(0.5,0.05));
                float3 _Normal_var = UnpackNormal(tex2Dlod(_Normal,float4(TRANSFORM_TEX(node_9766, _Normal),0.0,0)));
                v.vertex.xyz += float3((_Normal_var.rgb.rg*_Offset),0.0);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_3963 = _Time;
                float2 node_9766 = (i.uv0+(node_3963.g*_Y)*float2(0.5,0.05));
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(node_9766, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 node_5449 = _Time;
                float2 node_5316 = (i.uv0+node_5449.g*float2(0.01,0.2));
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(node_5316, _Texture));
                float3 diffuseColor = (_Texture_var.rgb*_colour.rgb);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float _Offset;
            uniform float _Y;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                float4 node_3963 = _Time;
                float2 node_9766 = (o.uv0+(node_3963.g*_Y)*float2(0.5,0.05));
                float3 _Normal_var = UnpackNormal(tex2Dlod(_Normal,float4(TRANSFORM_TEX(node_9766, _Normal),0.0,0)));
                v.vertex.xyz += float3((_Normal_var.rgb.rg*_Offset),0.0);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
