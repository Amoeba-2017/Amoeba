// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.3853806,fgcg:0.6254027,fgcb:0.6470588,fgca:0.491,fgde:0.004,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9310,x:32719,y:32712,varname:node_9310,prsc:2|diff-8170-OUT,difocc-7897-OUT,voffset-5357-OUT;n:type:ShaderForge.SFN_Color,id:3924,x:32496,y:32564,ptovrint:False,ptlb:colour,ptin:_colour,varname:node_3924,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.7058823,c2:1,c3:0.9513185,c4:1;n:type:ShaderForge.SFN_Tex2d,id:9193,x:31977,y:32813,ptovrint:False,ptlb:node_9193,ptin:_node_9193,varname:node_9193,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:304fd128e064b8f41847e8b7a809cb4d,ntxv:2,isnm:False|UVIN-9766-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:8572,x:32363,y:32901,varname:node_8572,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-9193-RGB;n:type:ShaderForge.SFN_Multiply,id:5357,x:32508,y:33071,varname:node_5357,prsc:2|A-8572-OUT,B-9538-OUT;n:type:ShaderForge.SFN_Slider,id:9538,x:32131,y:33141,ptovrint:False,ptlb:node_9538,ptin:_node_9538,varname:node_9538,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6325288,max:1;n:type:ShaderForge.SFN_TexCoord,id:5010,x:31640,y:32590,varname:node_5010,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:9766,x:31807,y:32600,varname:node_9766,prsc:2,spu:1,spv:0|UVIN-5010-UVOUT,DIST-5906-OUT;n:type:ShaderForge.SFN_Slider,id:9028,x:31181,y:33047,ptovrint:False,ptlb:Y,ptin:_Y,varname:node_9028,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-3,cur:-0.07692309,max:3;n:type:ShaderForge.SFN_Time,id:3963,x:31355,y:32784,varname:node_3963,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5906,x:31624,y:32760,varname:node_5906,prsc:2|A-3963-T,B-9028-OUT;n:type:ShaderForge.SFN_Panner,id:1850,x:31737,y:32242,varname:node_1850,prsc:2,spu:1,spv:0|UVIN-8833-UVOUT,DIST-5981-OUT;n:type:ShaderForge.SFN_TexCoord,id:8833,x:31570,y:32232,varname:node_8833,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:5981,x:31554,y:32402,varname:node_5981,prsc:2|A-1007-T,B-2917-OUT;n:type:ShaderForge.SFN_Time,id:1007,x:31285,y:32426,varname:node_1007,prsc:2;n:type:ShaderForge.SFN_Slider,id:2917,x:31111,y:32689,ptovrint:False,ptlb:Y_copy,ptin:_Y_copy,varname:_Y_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-3,cur:-0.02878349,max:3;n:type:ShaderForge.SFN_Tex2d,id:1475,x:31949,y:32385,ptovrint:False,ptlb:node_9193_copy,ptin:_node_9193_copy,varname:_node_9193_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:304fd128e064b8f41847e8b7a809cb4d,ntxv:2,isnm:False|UVIN-1850-UVOUT;n:type:ShaderForge.SFN_ValueProperty,id:7897,x:32330,y:32768,ptovrint:False,ptlb:node_7897,ptin:_node_7897,varname:node_7897,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Tex2d,id:3004,x:32414,y:32348,ptovrint:False,ptlb:node_3004,ptin:_node_3004,varname:node_3004,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:304fd128e064b8f41847e8b7a809cb4d,ntxv:2,isnm:False|UVIN-4729-OUT;n:type:ShaderForge.SFN_Multiply,id:8170,x:32669,y:32442,varname:node_8170,prsc:2|A-3004-RGB,B-3924-RGB;n:type:ShaderForge.SFN_Panner,id:5316,x:31444,y:31916,varname:node_5316,prsc:2,spu:1,spv:0;n:type:ShaderForge.SFN_TexCoord,id:3467,x:32117,y:31906,varname:node_3467,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:3689,x:32127,y:32134,varname:node_3689,prsc:2|A-2108-TSL,B-9452-OUT;n:type:ShaderForge.SFN_Slider,id:1674,x:31075,y:31939,ptovrint:False,ptlb:node_1674,ptin:_node_1674,varname:node_1674,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-3,cur:0.5246144,max:3;n:type:ShaderForge.SFN_Time,id:2108,x:31793,y:31865,varname:node_2108,prsc:2;n:type:ShaderForge.SFN_Add,id:4729,x:32308,y:32094,varname:node_4729,prsc:2|A-3467-UVOUT,B-3689-OUT;n:type:ShaderForge.SFN_Append,id:9452,x:31833,y:32069,varname:node_9452,prsc:2|A-6407-OUT,B-923-OUT;n:type:ShaderForge.SFN_ValueProperty,id:923,x:31544,y:32119,ptovrint:False,ptlb:node_923,ptin:_node_923,varname:node_923,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.3;n:type:ShaderForge.SFN_ValueProperty,id:6407,x:31566,y:32030,ptovrint:False,ptlb:node_6407,ptin:_node_6407,varname:node_6407,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;proporder:3924-9193-9538-9028-2917-1475-7897-3004-1674-6407-923;pass:END;sub:END;*/

Shader "Custom/water" {
    Properties {
        _colour ("colour", Color) = (0.7058823,1,0.9513185,1)
        _node_9193 ("node_9193", 2D) = "black" {}
        _node_9538 ("node_9538", Range(0, 1)) = 0.6325288
        _Y ("Y", Range(-3, 3)) = -0.07692309
        _Y_copy ("Y_copy", Range(-3, 3)) = -0.02878349
        _node_9193_copy ("node_9193_copy", 2D) = "black" {}
        _node_7897 ("node_7897", Float ) = 0.5
        _node_3004 ("node_3004", 2D) = "black" {}
        _node_1674 ("node_1674", Range(-3, 3)) = 0.5246144
        _node_6407 ("node_6407", Float ) = 1
        _node_923 ("node_923", Float ) = 0.3
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
            uniform sampler2D _node_9193; uniform float4 _node_9193_ST;
            uniform float _node_9538;
            uniform float _Y;
            uniform float _node_7897;
            uniform sampler2D _node_3004; uniform float4 _node_3004_ST;
            uniform float _node_923;
            uniform float _node_6407;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_3963 = _Time;
                float2 node_9766 = (o.uv0+(node_3963.g*_Y)*float2(1,0));
                float4 _node_9193_var = tex2Dlod(_node_9193,float4(TRANSFORM_TEX(node_9766, _node_9193),0.0,0));
                v.vertex.xyz += float3((_node_9193_var.rgb.rg*_node_9538),0.0);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
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
                indirectDiffuse *= _node_7897; // Diffuse AO
                float4 node_2108 = _Time;
                float2 node_4729 = (i.uv0+(node_2108.r*float2(_node_6407,_node_923)));
                float4 _node_3004_var = tex2D(_node_3004,TRANSFORM_TEX(node_4729, _node_3004));
                float3 diffuseColor = (_node_3004_var.rgb*_colour.rgb);
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
            uniform sampler2D _node_9193; uniform float4 _node_9193_ST;
            uniform float _node_9538;
            uniform float _Y;
            uniform sampler2D _node_3004; uniform float4 _node_3004_ST;
            uniform float _node_923;
            uniform float _node_6407;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_3963 = _Time;
                float2 node_9766 = (o.uv0+(node_3963.g*_Y)*float2(1,0));
                float4 _node_9193_var = tex2Dlod(_node_9193,float4(TRANSFORM_TEX(node_9766, _node_9193),0.0,0));
                v.vertex.xyz += float3((_node_9193_var.rgb.rg*_node_9538),0.0);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 node_2108 = _Time;
                float2 node_4729 = (i.uv0+(node_2108.r*float2(_node_6407,_node_923)));
                float4 _node_3004_var = tex2D(_node_3004,TRANSFORM_TEX(node_4729, _node_3004));
                float3 diffuseColor = (_node_3004_var.rgb*_colour.rgb);
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
            uniform sampler2D _node_9193; uniform float4 _node_9193_ST;
            uniform float _node_9538;
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
                float2 node_9766 = (o.uv0+(node_3963.g*_Y)*float2(1,0));
                float4 _node_9193_var = tex2Dlod(_node_9193,float4(TRANSFORM_TEX(node_9766, _node_9193),0.0,0));
                v.vertex.xyz += float3((_node_9193_var.rgb.rg*_node_9538),0.0);
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
