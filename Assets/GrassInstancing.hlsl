#ifndef GRASS_INSTANCING_INCLUDED
#define GRASS_INSTANCING_INCLUDED

#ifdef UNITY_PROCEDURAL_INSTANCING_ENABLED
StructuredBuffer<float4x4> _InstanceData;
#endif

void ConfigureProcedural()
{
    #ifdef UNITY_PROCEDURAL_INSTANCING_ENABLED
        float4x4 instanceMatrix = _InstanceData[unity_InstanceID];
        unity_ObjectToWorld = instanceMatrix;
        unity_WorldToObject = unity_ObjectToWorld;
        unity_WorldToObject._14_24_34 *= -1;
        unity_WorldToObject._11_22_33 = 1.0f / unity_WorldToObject._11_22_33;
    #endif
}

void SetupGrassInstancing_float(float3 In, out float3 Out)
{
    Out = In;
}

#endif
