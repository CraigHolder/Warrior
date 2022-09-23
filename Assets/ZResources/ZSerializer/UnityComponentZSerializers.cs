
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
namespace ZSerializer {

[System.Serializable]
public sealed class NavMeshAgentZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Vector3 destination;
    public System.Single stoppingDistance;
    public UnityEngine.Vector3 velocity;
    public UnityEngine.Vector3 nextPosition;
    public System.Single baseOffset;
    public System.Boolean autoTraverseOffMeshLink;
    public System.Boolean autoBraking;
    public System.Boolean autoRepath;
    public System.Boolean isStopped;
    public System.Int32 agentTypeID;
    public System.Int32 areaMask;
    public System.Single speed;
    public System.Single angularSpeed;
    public System.Single acceleration;
    public System.Boolean updatePosition;
    public System.Boolean updateRotation;
    public System.Boolean updateUpAxis;
    public System.Single radius;
    public System.Single height;
    public UnityEngine.AI.ObstacleAvoidanceType obstacleAvoidanceType;
    public System.Int32 avoidancePriority;
    public System.Boolean enabled;
    public UnityEngine.HideFlags hideFlags;
    public NavMeshAgentZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.AI.NavMeshAgent;
        destination = instance.destination;
        stoppingDistance = instance.stoppingDistance;
        velocity = instance.velocity;
        nextPosition = instance.nextPosition;
        baseOffset = instance.baseOffset;
        autoTraverseOffMeshLink = instance.autoTraverseOffMeshLink;
        autoBraking = instance.autoBraking;
        autoRepath = instance.autoRepath;
        isStopped = instance.isStopped;
        agentTypeID = instance.agentTypeID;
        areaMask = instance.areaMask;
        speed = instance.speed;
        angularSpeed = instance.angularSpeed;
        acceleration = instance.acceleration;
        updatePosition = instance.updatePosition;
        updateRotation = instance.updateRotation;
        updateUpAxis = instance.updateUpAxis;
        radius = instance.radius;
        height = instance.height;
        obstacleAvoidanceType = instance.obstacleAvoidanceType;
        avoidancePriority = instance.avoidancePriority;
        enabled = instance.enabled;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.AI.NavMeshAgent))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.AI.NavMeshAgent)component;
        instance.destination = destination;
        instance.stoppingDistance = stoppingDistance;
        instance.velocity = velocity;
        instance.nextPosition = nextPosition;
        instance.baseOffset = baseOffset;
        instance.autoTraverseOffMeshLink = autoTraverseOffMeshLink;
        instance.autoBraking = autoBraking;
        instance.autoRepath = autoRepath;
        instance.isStopped = isStopped;
        instance.agentTypeID = agentTypeID;
        instance.areaMask = areaMask;
        instance.speed = speed;
        instance.angularSpeed = angularSpeed;
        instance.acceleration = acceleration;
        instance.updatePosition = updatePosition;
        instance.updateRotation = updateRotation;
        instance.updateUpAxis = updateUpAxis;
        instance.radius = radius;
        instance.height = height;
        instance.obstacleAvoidanceType = obstacleAvoidanceType;
        instance.avoidancePriority = avoidancePriority;
        instance.enabled = enabled;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.AI.NavMeshAgent))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class AudioSourceZSerializer : ZSerializer.Internal.ZSerializer {
    public System.Single volume;
    public System.Single pitch;
    public System.Single time;
    public System.Int32 timeSamples;
    public UnityEngine.AudioClip clip;
    public UnityEngine.Audio.AudioMixerGroup outputAudioMixerGroup;
    public UnityEngine.GamepadSpeakerOutputType gamepadSpeakerOutputType;
    public System.Boolean loop;
    public System.Boolean ignoreListenerVolume;
    public System.Boolean playOnAwake;
    public System.Boolean ignoreListenerPause;
    public UnityEngine.AudioVelocityUpdateMode velocityUpdateMode;
    public System.Single panStereo;
    public System.Single spatialBlend;
    public System.Boolean spatialize;
    public System.Boolean spatializePostEffects;
    public System.Single reverbZoneMix;
    public System.Boolean bypassEffects;
    public System.Boolean bypassListenerEffects;
    public System.Boolean bypassReverbZones;
    public System.Single dopplerLevel;
    public System.Single spread;
    public System.Int32 priority;
    public System.Boolean mute;
    public System.Single minDistance;
    public System.Single maxDistance;
    public UnityEngine.AudioRolloffMode rolloffMode;
    public System.Boolean enabled;
    public UnityEngine.HideFlags hideFlags;
    public AudioSourceZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.AudioSource;
        volume = instance.volume;
        pitch = instance.pitch;
        time = instance.time;
        timeSamples = instance.timeSamples;
        clip = instance.clip;
        outputAudioMixerGroup = instance.outputAudioMixerGroup;
        gamepadSpeakerOutputType = instance.gamepadSpeakerOutputType;
        loop = instance.loop;
        ignoreListenerVolume = instance.ignoreListenerVolume;
        playOnAwake = instance.playOnAwake;
        ignoreListenerPause = instance.ignoreListenerPause;
        velocityUpdateMode = instance.velocityUpdateMode;
        panStereo = instance.panStereo;
        spatialBlend = instance.spatialBlend;
        spatialize = instance.spatialize;
        spatializePostEffects = instance.spatializePostEffects;
        reverbZoneMix = instance.reverbZoneMix;
        bypassEffects = instance.bypassEffects;
        bypassListenerEffects = instance.bypassListenerEffects;
        bypassReverbZones = instance.bypassReverbZones;
        dopplerLevel = instance.dopplerLevel;
        spread = instance.spread;
        priority = instance.priority;
        mute = instance.mute;
        minDistance = instance.minDistance;
        maxDistance = instance.maxDistance;
        rolloffMode = instance.rolloffMode;
        enabled = instance.enabled;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.AudioSource))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.AudioSource)component;
        instance.volume = volume;
        instance.pitch = pitch;
        instance.time = time;
        instance.timeSamples = timeSamples;
        instance.clip = clip;
        instance.outputAudioMixerGroup = outputAudioMixerGroup;
        instance.gamepadSpeakerOutputType = gamepadSpeakerOutputType;
        instance.loop = loop;
        instance.ignoreListenerVolume = ignoreListenerVolume;
        instance.playOnAwake = playOnAwake;
        instance.ignoreListenerPause = ignoreListenerPause;
        instance.velocityUpdateMode = velocityUpdateMode;
        instance.panStereo = panStereo;
        instance.spatialBlend = spatialBlend;
        instance.spatialize = spatialize;
        instance.spatializePostEffects = spatializePostEffects;
        instance.reverbZoneMix = reverbZoneMix;
        instance.bypassEffects = bypassEffects;
        instance.bypassListenerEffects = bypassListenerEffects;
        instance.bypassReverbZones = bypassReverbZones;
        instance.dopplerLevel = dopplerLevel;
        instance.spread = spread;
        instance.priority = priority;
        instance.mute = mute;
        instance.minDistance = minDistance;
        instance.maxDistance = maxDistance;
        instance.rolloffMode = rolloffMode;
        instance.enabled = enabled;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.AudioSource))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class AudioReverbFilterZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.AudioReverbPreset reverbPreset;
    public System.Single dryLevel;
    public System.Single room;
    public System.Single roomHF;
    public System.Single decayTime;
    public System.Single decayHFRatio;
    public System.Single reflectionsLevel;
    public System.Single reflectionsDelay;
    public System.Single reverbLevel;
    public System.Single reverbDelay;
    public System.Single diffusion;
    public System.Single density;
    public System.Single hfReference;
    public System.Single roomLF;
    public System.Single lfReference;
    public System.Boolean enabled;
    public UnityEngine.HideFlags hideFlags;
    public AudioReverbFilterZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.AudioReverbFilter;
        reverbPreset = instance.reverbPreset;
        dryLevel = instance.dryLevel;
        room = instance.room;
        roomHF = instance.roomHF;
        decayTime = instance.decayTime;
        decayHFRatio = instance.decayHFRatio;
        reflectionsLevel = instance.reflectionsLevel;
        reflectionsDelay = instance.reflectionsDelay;
        reverbLevel = instance.reverbLevel;
        reverbDelay = instance.reverbDelay;
        diffusion = instance.diffusion;
        density = instance.density;
        hfReference = instance.hfReference;
        roomLF = instance.roomLF;
        lfReference = instance.lfReference;
        enabled = instance.enabled;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.AudioReverbFilter))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.AudioReverbFilter)component;
        instance.reverbPreset = reverbPreset;
        instance.dryLevel = dryLevel;
        instance.room = room;
        instance.roomHF = roomHF;
        instance.decayTime = decayTime;
        instance.decayHFRatio = decayHFRatio;
        instance.reflectionsLevel = reflectionsLevel;
        instance.reflectionsDelay = reflectionsDelay;
        instance.reverbLevel = reverbLevel;
        instance.reverbDelay = reverbDelay;
        instance.diffusion = diffusion;
        instance.density = density;
        instance.hfReference = hfReference;
        instance.roomLF = roomLF;
        instance.lfReference = lfReference;
        instance.enabled = enabled;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.AudioReverbFilter))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class AudioListenerZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.AudioVelocityUpdateMode velocityUpdateMode;
    public System.Boolean enabled;
    public UnityEngine.HideFlags hideFlags;
    public AudioListenerZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.AudioListener;
        velocityUpdateMode = instance.velocityUpdateMode;
        enabled = instance.enabled;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.AudioListener))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.AudioListener)component;
        instance.velocityUpdateMode = velocityUpdateMode;
        instance.enabled = enabled;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.AudioListener))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class CameraZSerializer : ZSerializer.Internal.ZSerializer {
    public System.Single nearClipPlane;
    public System.Single farClipPlane;
    public System.Single fieldOfView;
    public UnityEngine.RenderingPath renderingPath;
    public System.Boolean allowHDR;
    public System.Boolean allowMSAA;
    public System.Boolean allowDynamicResolution;
    public System.Boolean forceIntoRenderTexture;
    public System.Single orthographicSize;
    public System.Boolean orthographic;
    public UnityEngine.Rendering.OpaqueSortMode opaqueSortMode;
    public UnityEngine.TransparencySortMode transparencySortMode;
    public UnityEngine.Vector3 transparencySortAxis;
    public System.Single depth;
    public System.Single aspect;
    public System.Int32 cullingMask;
    public System.Int32 eventMask;
    public System.Boolean layerCullSpherical;
    public UnityEngine.CameraType cameraType;
    public System.UInt64 overrideSceneCullingMask;
    public System.Single[] layerCullDistances;
    public System.Boolean useOcclusionCulling;
    public UnityEngine.Matrix4x4 cullingMatrix;
    public UnityEngine.Color backgroundColor;
    public UnityEngine.CameraClearFlags clearFlags;
    public UnityEngine.DepthTextureMode depthTextureMode;
    public System.Boolean clearStencilAfterLightingPass;
    public System.Boolean usePhysicalProperties;
    public UnityEngine.Vector2 sensorSize;
    public UnityEngine.Vector2 lensShift;
    public System.Single focalLength;
    public UnityEngine.Camera.GateFitMode gateFit;
    public UnityEngine.Rect rect;
    public UnityEngine.Rect pixelRect;
    public UnityEngine.RenderTexture targetTexture;
    public System.Int32 targetDisplay;
    public UnityEngine.Matrix4x4 worldToCameraMatrix;
    public UnityEngine.Matrix4x4 projectionMatrix;
    public UnityEngine.Matrix4x4 nonJitteredProjectionMatrix;
    public System.Boolean useJitteredProjectionMatrixForTransparentRendering;
    public UnityEngine.SceneManagement.Scene scene;
    public System.Single stereoSeparation;
    public System.Single stereoConvergence;
    public UnityEngine.StereoTargetEyeMask stereoTargetEye;
    public System.Boolean enabled;
    public UnityEngine.HideFlags hideFlags;
    public CameraZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.Camera;
        nearClipPlane = instance.nearClipPlane;
        farClipPlane = instance.farClipPlane;
        fieldOfView = instance.fieldOfView;
        renderingPath = instance.renderingPath;
        allowHDR = instance.allowHDR;
        allowMSAA = instance.allowMSAA;
        allowDynamicResolution = instance.allowDynamicResolution;
        forceIntoRenderTexture = instance.forceIntoRenderTexture;
        orthographicSize = instance.orthographicSize;
        orthographic = instance.orthographic;
        opaqueSortMode = instance.opaqueSortMode;
        transparencySortMode = instance.transparencySortMode;
        transparencySortAxis = instance.transparencySortAxis;
        depth = instance.depth;
        aspect = instance.aspect;
        cullingMask = instance.cullingMask;
        eventMask = instance.eventMask;
        layerCullSpherical = instance.layerCullSpherical;
        cameraType = instance.cameraType;
        overrideSceneCullingMask = instance.overrideSceneCullingMask;
        layerCullDistances = instance.layerCullDistances;
        useOcclusionCulling = instance.useOcclusionCulling;
        cullingMatrix = instance.cullingMatrix;
        backgroundColor = instance.backgroundColor;
        clearFlags = instance.clearFlags;
        depthTextureMode = instance.depthTextureMode;
        clearStencilAfterLightingPass = instance.clearStencilAfterLightingPass;
        usePhysicalProperties = instance.usePhysicalProperties;
        sensorSize = instance.sensorSize;
        lensShift = instance.lensShift;
        focalLength = instance.focalLength;
        gateFit = instance.gateFit;
        rect = instance.rect;
        pixelRect = instance.pixelRect;
        targetTexture = instance.targetTexture;
        targetDisplay = instance.targetDisplay;
        worldToCameraMatrix = instance.worldToCameraMatrix;
        projectionMatrix = instance.projectionMatrix;
        nonJitteredProjectionMatrix = instance.nonJitteredProjectionMatrix;
        useJitteredProjectionMatrixForTransparentRendering = instance.useJitteredProjectionMatrixForTransparentRendering;
        scene = instance.scene;
        stereoSeparation = instance.stereoSeparation;
        stereoConvergence = instance.stereoConvergence;
        stereoTargetEye = instance.stereoTargetEye;
        enabled = instance.enabled;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.Camera))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.Camera)component;
        instance.nearClipPlane = nearClipPlane;
        instance.farClipPlane = farClipPlane;
        instance.fieldOfView = fieldOfView;
        instance.renderingPath = renderingPath;
        instance.allowHDR = allowHDR;
        instance.allowMSAA = allowMSAA;
        instance.allowDynamicResolution = allowDynamicResolution;
        instance.forceIntoRenderTexture = forceIntoRenderTexture;
        instance.orthographicSize = orthographicSize;
        instance.orthographic = orthographic;
        instance.opaqueSortMode = opaqueSortMode;
        instance.transparencySortMode = transparencySortMode;
        instance.transparencySortAxis = transparencySortAxis;
        instance.depth = depth;
        instance.aspect = aspect;
        instance.cullingMask = cullingMask;
        instance.eventMask = eventMask;
        instance.layerCullSpherical = layerCullSpherical;
        instance.cameraType = cameraType;
        instance.overrideSceneCullingMask = overrideSceneCullingMask;
        instance.layerCullDistances = layerCullDistances;
        instance.useOcclusionCulling = useOcclusionCulling;
        instance.cullingMatrix = cullingMatrix;
        instance.backgroundColor = backgroundColor;
        instance.clearFlags = clearFlags;
        instance.depthTextureMode = depthTextureMode;
        instance.clearStencilAfterLightingPass = clearStencilAfterLightingPass;
        instance.usePhysicalProperties = usePhysicalProperties;
        instance.sensorSize = sensorSize;
        instance.lensShift = lensShift;
        instance.focalLength = focalLength;
        instance.gateFit = gateFit;
        instance.rect = rect;
        instance.pixelRect = pixelRect;
        instance.targetTexture = targetTexture;
        instance.targetDisplay = targetDisplay;
        instance.worldToCameraMatrix = worldToCameraMatrix;
        instance.projectionMatrix = projectionMatrix;
        instance.nonJitteredProjectionMatrix = nonJitteredProjectionMatrix;
        instance.useJitteredProjectionMatrixForTransparentRendering = useJitteredProjectionMatrixForTransparentRendering;
        instance.scene = scene;
        instance.stereoSeparation = stereoSeparation;
        instance.stereoConvergence = stereoConvergence;
        instance.stereoTargetEye = stereoTargetEye;
        instance.enabled = enabled;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.Camera))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class LightZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.LightType type;
    public UnityEngine.LightShape shape;
    public System.Single spotAngle;
    public System.Single innerSpotAngle;
    public UnityEngine.Color color;
    public System.Single colorTemperature;
    public System.Boolean useColorTemperature;
    public System.Single intensity;
    public System.Single bounceIntensity;
    public System.Boolean useBoundingSphereOverride;
    public UnityEngine.Vector4 boundingSphereOverride;
    public System.Boolean useViewFrustumForShadowCasterCull;
    public System.Int32 shadowCustomResolution;
    public System.Single shadowBias;
    public System.Single shadowNormalBias;
    public System.Single shadowNearPlane;
    public System.Boolean useShadowMatrixOverride;
    public UnityEngine.Matrix4x4 shadowMatrixOverride;
    public System.Single range;
    public UnityEngine.Flare flare;
    public UnityEngine.LightBakingOutput bakingOutput;
    public System.Int32 cullingMask;
    public System.Int32 renderingLayerMask;
    public UnityEngine.LightShadowCasterMode lightShadowCasterMode;
    public System.Single shadowRadius;
    public System.Single shadowAngle;
    public UnityEngine.LightShadows shadows;
    public System.Single shadowStrength;
    public UnityEngine.Rendering.LightShadowResolution shadowResolution;
    public System.Single[] layerShadowCullDistances;
    public System.Single cookieSize;
    public UnityEngine.Texture cookie;
    public UnityEngine.LightRenderMode renderMode;
    public UnityEngine.Vector2 areaSize;
    public UnityEngine.LightmapBakeType lightmapBakeType;
    public System.Boolean enabled;
    public UnityEngine.HideFlags hideFlags;
    public LightZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.Light;
        type = instance.type;
        shape = instance.shape;
        spotAngle = instance.spotAngle;
        innerSpotAngle = instance.innerSpotAngle;
        color = instance.color;
        colorTemperature = instance.colorTemperature;
        useColorTemperature = instance.useColorTemperature;
        intensity = instance.intensity;
        bounceIntensity = instance.bounceIntensity;
        useBoundingSphereOverride = instance.useBoundingSphereOverride;
        boundingSphereOverride = instance.boundingSphereOverride;
        useViewFrustumForShadowCasterCull = instance.useViewFrustumForShadowCasterCull;
        shadowCustomResolution = instance.shadowCustomResolution;
        shadowBias = instance.shadowBias;
        shadowNormalBias = instance.shadowNormalBias;
        shadowNearPlane = instance.shadowNearPlane;
        useShadowMatrixOverride = instance.useShadowMatrixOverride;
        shadowMatrixOverride = instance.shadowMatrixOverride;
        range = instance.range;
        flare = instance.flare;
        bakingOutput = instance.bakingOutput;
        cullingMask = instance.cullingMask;
        renderingLayerMask = instance.renderingLayerMask;
        lightShadowCasterMode = instance.lightShadowCasterMode;
        shadowRadius = instance.shadowRadius;
        shadowAngle = instance.shadowAngle;
        shadows = instance.shadows;
        shadowStrength = instance.shadowStrength;
        shadowResolution = instance.shadowResolution;
        layerShadowCullDistances = instance.layerShadowCullDistances;
        cookieSize = instance.cookieSize;
        cookie = instance.cookie;
        renderMode = instance.renderMode;
        areaSize = instance.areaSize;
        lightmapBakeType = instance.lightmapBakeType;
        enabled = instance.enabled;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.Light))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.Light)component;
        instance.type = type;
        instance.shape = shape;
        instance.spotAngle = spotAngle;
        instance.innerSpotAngle = innerSpotAngle;
        instance.color = color;
        instance.colorTemperature = colorTemperature;
        instance.useColorTemperature = useColorTemperature;
        instance.intensity = intensity;
        instance.bounceIntensity = bounceIntensity;
        instance.useBoundingSphereOverride = useBoundingSphereOverride;
        instance.boundingSphereOverride = boundingSphereOverride;
        instance.useViewFrustumForShadowCasterCull = useViewFrustumForShadowCasterCull;
        instance.shadowCustomResolution = shadowCustomResolution;
        instance.shadowBias = shadowBias;
        instance.shadowNormalBias = shadowNormalBias;
        instance.shadowNearPlane = shadowNearPlane;
        instance.useShadowMatrixOverride = useShadowMatrixOverride;
        instance.shadowMatrixOverride = shadowMatrixOverride;
        instance.range = range;
        instance.flare = flare;
        instance.bakingOutput = bakingOutput;
        instance.cullingMask = cullingMask;
        instance.renderingLayerMask = renderingLayerMask;
        instance.lightShadowCasterMode = lightShadowCasterMode;
        instance.shadowRadius = shadowRadius;
        instance.shadowAngle = shadowAngle;
        instance.shadows = shadows;
        instance.shadowStrength = shadowStrength;
        instance.shadowResolution = shadowResolution;
        instance.layerShadowCullDistances = layerShadowCullDistances;
        instance.cookieSize = cookieSize;
        instance.cookie = cookie;
        instance.renderMode = renderMode;
        instance.areaSize = areaSize;
        instance.lightmapBakeType = lightmapBakeType;
        instance.enabled = enabled;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.Light))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class MeshFilterZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Mesh sharedMesh;
    public UnityEngine.HideFlags hideFlags;
    public MeshFilterZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.MeshFilter;
        sharedMesh = instance.sharedMesh;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.MeshFilter))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.MeshFilter)component;
        instance.sharedMesh = sharedMesh;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.MeshFilter))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class MeshRendererZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Mesh additionalVertexStreams;
    public UnityEngine.Mesh enlightenVertexStream;
    public System.Single scaleInLightmap;
    public UnityEngine.ReceiveGI receiveGI;
    public System.Boolean stitchLightmapSeams;
    public System.Boolean enabled;
    public UnityEngine.Rendering.ShadowCastingMode shadowCastingMode;
    public System.Boolean receiveShadows;
    public System.Boolean forceRenderingOff;
    public UnityEngine.MotionVectorGenerationMode motionVectorGenerationMode;
    public UnityEngine.Rendering.LightProbeUsage lightProbeUsage;
    public UnityEngine.Rendering.ReflectionProbeUsage reflectionProbeUsage;
    public System.UInt32 renderingLayerMask;
    public System.Int32 rendererPriority;
    public UnityEngine.Experimental.Rendering.RayTracingMode rayTracingMode;
    public System.String sortingLayerName;
    public System.Int32 sortingLayerID;
    public System.Int32 sortingOrder;
    public System.Boolean allowOcclusionWhenDynamic;
    public UnityEngine.GameObject lightProbeProxyVolumeOverride;
    public UnityEngine.Transform probeAnchor;
    public System.Int32 lightmapIndex;
    public System.Int32 realtimeLightmapIndex;
    public UnityEngine.Vector4 lightmapScaleOffset;
    public UnityEngine.Vector4 realtimeLightmapScaleOffset;
    public UnityEngine.Material[] sharedMaterials;
    public UnityEngine.HideFlags hideFlags;
    public MeshRendererZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.MeshRenderer;
        additionalVertexStreams = instance.additionalVertexStreams;
        enlightenVertexStream = instance.enlightenVertexStream;
        scaleInLightmap = instance.scaleInLightmap;
        receiveGI = instance.receiveGI;
        stitchLightmapSeams = instance.stitchLightmapSeams;
        enabled = instance.enabled;
        shadowCastingMode = instance.shadowCastingMode;
        receiveShadows = instance.receiveShadows;
        forceRenderingOff = instance.forceRenderingOff;
        motionVectorGenerationMode = instance.motionVectorGenerationMode;
        lightProbeUsage = instance.lightProbeUsage;
        reflectionProbeUsage = instance.reflectionProbeUsage;
        renderingLayerMask = instance.renderingLayerMask;
        rendererPriority = instance.rendererPriority;
        rayTracingMode = instance.rayTracingMode;
        sortingLayerName = instance.sortingLayerName;
        sortingLayerID = instance.sortingLayerID;
        sortingOrder = instance.sortingOrder;
        allowOcclusionWhenDynamic = instance.allowOcclusionWhenDynamic;
        lightProbeProxyVolumeOverride = instance.lightProbeProxyVolumeOverride;
        probeAnchor = instance.probeAnchor;
        lightmapIndex = instance.lightmapIndex;
        realtimeLightmapIndex = instance.realtimeLightmapIndex;
        lightmapScaleOffset = instance.lightmapScaleOffset;
        realtimeLightmapScaleOffset = instance.realtimeLightmapScaleOffset;
        sharedMaterials = instance.sharedMaterials;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.MeshRenderer))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.MeshRenderer)component;
        instance.additionalVertexStreams = additionalVertexStreams;
        instance.enlightenVertexStream = enlightenVertexStream;
        instance.scaleInLightmap = scaleInLightmap;
        instance.receiveGI = receiveGI;
        instance.stitchLightmapSeams = stitchLightmapSeams;
        instance.enabled = enabled;
        instance.shadowCastingMode = shadowCastingMode;
        instance.receiveShadows = receiveShadows;
        instance.forceRenderingOff = forceRenderingOff;
        instance.motionVectorGenerationMode = motionVectorGenerationMode;
        instance.lightProbeUsage = lightProbeUsage;
        instance.reflectionProbeUsage = reflectionProbeUsage;
        instance.renderingLayerMask = renderingLayerMask;
        instance.rendererPriority = rendererPriority;
        instance.rayTracingMode = rayTracingMode;
        instance.sortingLayerName = sortingLayerName;
        instance.sortingLayerID = sortingLayerID;
        instance.sortingOrder = sortingOrder;
        instance.allowOcclusionWhenDynamic = allowOcclusionWhenDynamic;
        instance.lightProbeProxyVolumeOverride = lightProbeProxyVolumeOverride;
        instance.probeAnchor = probeAnchor;
        instance.lightmapIndex = lightmapIndex;
        instance.realtimeLightmapIndex = realtimeLightmapIndex;
        instance.lightmapScaleOffset = lightmapScaleOffset;
        instance.realtimeLightmapScaleOffset = realtimeLightmapScaleOffset;
        instance.sharedMaterials = sharedMaterials;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.MeshRenderer))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class TransformZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Vector3 position;
    public UnityEngine.Vector3 localPosition;
    public UnityEngine.Vector3 eulerAngles;
    public UnityEngine.Vector3 localEulerAngles;
    public UnityEngine.Vector3 right;
    public UnityEngine.Vector3 up;
    public UnityEngine.Vector3 forward;
    public UnityEngine.Quaternion rotation;
    public UnityEngine.Quaternion localRotation;
    public UnityEngine.Vector3 localScale;
    public UnityEngine.Transform parent;
    public System.Boolean hasChanged;
    public System.Int32 hierarchyCapacity;
    public UnityEngine.HideFlags hideFlags;
    public TransformZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.Transform;
        position = instance.position;
        localPosition = instance.localPosition;
        eulerAngles = instance.eulerAngles;
        localEulerAngles = instance.localEulerAngles;
        right = instance.right;
        up = instance.up;
        forward = instance.forward;
        rotation = instance.rotation;
        localRotation = instance.localRotation;
        localScale = instance.localScale;
        parent = instance.parent;
        hasChanged = instance.hasChanged;
        hierarchyCapacity = instance.hierarchyCapacity;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.Transform))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.Transform)component;
        instance.position = position;
        instance.localPosition = localPosition;
        instance.eulerAngles = eulerAngles;
        instance.localEulerAngles = localEulerAngles;
        instance.right = right;
        instance.up = up;
        instance.forward = forward;
        instance.rotation = rotation;
        instance.localRotation = localRotation;
        instance.localScale = localScale;
        instance.parent = parent;
        instance.hasChanged = hasChanged;
        instance.hierarchyCapacity = hierarchyCapacity;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.Transform))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class SpriteRendererZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Sprite sprite;
    public UnityEngine.SpriteDrawMode drawMode;
    public UnityEngine.Vector2 size;
    public System.Single adaptiveModeThreshold;
    public UnityEngine.SpriteTileMode tileMode;
    public UnityEngine.Color color;
    public UnityEngine.SpriteMaskInteraction maskInteraction;
    public System.Boolean flipX;
    public System.Boolean flipY;
    public UnityEngine.SpriteSortPoint spriteSortPoint;
    public System.Boolean enabled;
    public UnityEngine.Rendering.ShadowCastingMode shadowCastingMode;
    public System.Boolean receiveShadows;
    public System.Boolean forceRenderingOff;
    public UnityEngine.MotionVectorGenerationMode motionVectorGenerationMode;
    public UnityEngine.Rendering.LightProbeUsage lightProbeUsage;
    public UnityEngine.Rendering.ReflectionProbeUsage reflectionProbeUsage;
    public System.UInt32 renderingLayerMask;
    public System.Int32 rendererPriority;
    public UnityEngine.Experimental.Rendering.RayTracingMode rayTracingMode;
    public System.String sortingLayerName;
    public System.Int32 sortingLayerID;
    public System.Int32 sortingOrder;
    public System.Boolean allowOcclusionWhenDynamic;
    public UnityEngine.GameObject lightProbeProxyVolumeOverride;
    public UnityEngine.Transform probeAnchor;
    public System.Int32 lightmapIndex;
    public System.Int32 realtimeLightmapIndex;
    public UnityEngine.Vector4 lightmapScaleOffset;
    public UnityEngine.Vector4 realtimeLightmapScaleOffset;
    public UnityEngine.Material[] sharedMaterials;
    public UnityEngine.HideFlags hideFlags;
    public SpriteRendererZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.SpriteRenderer;
        sprite = instance.sprite;
        drawMode = instance.drawMode;
        size = instance.size;
        adaptiveModeThreshold = instance.adaptiveModeThreshold;
        tileMode = instance.tileMode;
        color = instance.color;
        maskInteraction = instance.maskInteraction;
        flipX = instance.flipX;
        flipY = instance.flipY;
        spriteSortPoint = instance.spriteSortPoint;
        enabled = instance.enabled;
        shadowCastingMode = instance.shadowCastingMode;
        receiveShadows = instance.receiveShadows;
        forceRenderingOff = instance.forceRenderingOff;
        motionVectorGenerationMode = instance.motionVectorGenerationMode;
        lightProbeUsage = instance.lightProbeUsage;
        reflectionProbeUsage = instance.reflectionProbeUsage;
        renderingLayerMask = instance.renderingLayerMask;
        rendererPriority = instance.rendererPriority;
        rayTracingMode = instance.rayTracingMode;
        sortingLayerName = instance.sortingLayerName;
        sortingLayerID = instance.sortingLayerID;
        sortingOrder = instance.sortingOrder;
        allowOcclusionWhenDynamic = instance.allowOcclusionWhenDynamic;
        lightProbeProxyVolumeOverride = instance.lightProbeProxyVolumeOverride;
        probeAnchor = instance.probeAnchor;
        lightmapIndex = instance.lightmapIndex;
        realtimeLightmapIndex = instance.realtimeLightmapIndex;
        lightmapScaleOffset = instance.lightmapScaleOffset;
        realtimeLightmapScaleOffset = instance.realtimeLightmapScaleOffset;
        sharedMaterials = instance.sharedMaterials;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.SpriteRenderer))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.SpriteRenderer)component;
        instance.sprite = sprite;
        instance.drawMode = drawMode;
        instance.size = size;
        instance.adaptiveModeThreshold = adaptiveModeThreshold;
        instance.tileMode = tileMode;
        instance.color = color;
        instance.maskInteraction = maskInteraction;
        instance.flipX = flipX;
        instance.flipY = flipY;
        instance.spriteSortPoint = spriteSortPoint;
        instance.enabled = enabled;
        instance.shadowCastingMode = shadowCastingMode;
        instance.receiveShadows = receiveShadows;
        instance.forceRenderingOff = forceRenderingOff;
        instance.motionVectorGenerationMode = motionVectorGenerationMode;
        instance.lightProbeUsage = lightProbeUsage;
        instance.reflectionProbeUsage = reflectionProbeUsage;
        instance.renderingLayerMask = renderingLayerMask;
        instance.rendererPriority = rendererPriority;
        instance.rayTracingMode = rayTracingMode;
        instance.sortingLayerName = sortingLayerName;
        instance.sortingLayerID = sortingLayerID;
        instance.sortingOrder = sortingOrder;
        instance.allowOcclusionWhenDynamic = allowOcclusionWhenDynamic;
        instance.lightProbeProxyVolumeOverride = lightProbeProxyVolumeOverride;
        instance.probeAnchor = probeAnchor;
        instance.lightmapIndex = lightmapIndex;
        instance.realtimeLightmapIndex = realtimeLightmapIndex;
        instance.lightmapScaleOffset = lightmapScaleOffset;
        instance.realtimeLightmapScaleOffset = realtimeLightmapScaleOffset;
        instance.sharedMaterials = sharedMaterials;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.SpriteRenderer))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class RigidbodyZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Vector3 velocity;
    public UnityEngine.Vector3 angularVelocity;
    public System.Single drag;
    public System.Single angularDrag;
    public System.Single mass;
    public System.Boolean useGravity;
    public System.Single maxDepenetrationVelocity;
    public System.Boolean isKinematic;
    public System.Boolean freezeRotation;
    public UnityEngine.RigidbodyConstraints constraints;
    public UnityEngine.CollisionDetectionMode collisionDetectionMode;
    public UnityEngine.Vector3 centerOfMass;
    public UnityEngine.Quaternion inertiaTensorRotation;
    public UnityEngine.Vector3 inertiaTensor;
    public System.Boolean detectCollisions;
    public UnityEngine.Vector3 position;
    public UnityEngine.Quaternion rotation;
    public UnityEngine.RigidbodyInterpolation interpolation;
    public System.Int32 solverIterations;
    public System.Single sleepThreshold;
    public System.Single maxAngularVelocity;
    public System.Int32 solverVelocityIterations;
    public UnityEngine.HideFlags hideFlags;
    public RigidbodyZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.Rigidbody;
        velocity = instance.velocity;
        angularVelocity = instance.angularVelocity;
        drag = instance.drag;
        angularDrag = instance.angularDrag;
        mass = instance.mass;
        useGravity = instance.useGravity;
        maxDepenetrationVelocity = instance.maxDepenetrationVelocity;
        isKinematic = instance.isKinematic;
        freezeRotation = instance.freezeRotation;
        constraints = instance.constraints;
        collisionDetectionMode = instance.collisionDetectionMode;
        centerOfMass = instance.centerOfMass;
        inertiaTensorRotation = instance.inertiaTensorRotation;
        inertiaTensor = instance.inertiaTensor;
        detectCollisions = instance.detectCollisions;
        position = instance.position;
        rotation = instance.rotation;
        interpolation = instance.interpolation;
        solverIterations = instance.solverIterations;
        sleepThreshold = instance.sleepThreshold;
        maxAngularVelocity = instance.maxAngularVelocity;
        solverVelocityIterations = instance.solverVelocityIterations;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.Rigidbody))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.Rigidbody)component;
        instance.velocity = velocity;
        instance.angularVelocity = angularVelocity;
        instance.drag = drag;
        instance.angularDrag = angularDrag;
        instance.mass = mass;
        instance.useGravity = useGravity;
        instance.maxDepenetrationVelocity = maxDepenetrationVelocity;
        instance.isKinematic = isKinematic;
        instance.freezeRotation = freezeRotation;
        instance.constraints = constraints;
        instance.collisionDetectionMode = collisionDetectionMode;
        instance.centerOfMass = centerOfMass;
        instance.inertiaTensorRotation = inertiaTensorRotation;
        instance.inertiaTensor = inertiaTensor;
        instance.detectCollisions = detectCollisions;
        instance.position = position;
        instance.rotation = rotation;
        instance.interpolation = interpolation;
        instance.solverIterations = solverIterations;
        instance.sleepThreshold = sleepThreshold;
        instance.maxAngularVelocity = maxAngularVelocity;
        instance.solverVelocityIterations = solverVelocityIterations;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.Rigidbody))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class CharacterControllerZSerializer : ZSerializer.Internal.ZSerializer {
    public System.Single radius;
    public System.Single height;
    public UnityEngine.Vector3 center;
    public System.Single slopeLimit;
    public System.Single stepOffset;
    public System.Single skinWidth;
    public System.Single minMoveDistance;
    public System.Boolean detectCollisions;
    public System.Boolean enableOverlapRecovery;
    public System.Boolean enabled;
    public System.Boolean isTrigger;
    public System.Single contactOffset;
    public UnityEngine.HideFlags hideFlags;
    public CharacterControllerZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.CharacterController;
        radius = instance.radius;
        height = instance.height;
        center = instance.center;
        slopeLimit = instance.slopeLimit;
        stepOffset = instance.stepOffset;
        skinWidth = instance.skinWidth;
        minMoveDistance = instance.minMoveDistance;
        detectCollisions = instance.detectCollisions;
        enableOverlapRecovery = instance.enableOverlapRecovery;
        enabled = instance.enabled;
        isTrigger = instance.isTrigger;
        contactOffset = instance.contactOffset;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.CharacterController))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.CharacterController)component;
        instance.radius = radius;
        instance.height = height;
        instance.center = center;
        instance.slopeLimit = slopeLimit;
        instance.stepOffset = stepOffset;
        instance.skinWidth = skinWidth;
        instance.minMoveDistance = minMoveDistance;
        instance.detectCollisions = detectCollisions;
        instance.enableOverlapRecovery = enableOverlapRecovery;
        instance.enabled = enabled;
        instance.isTrigger = isTrigger;
        instance.contactOffset = contactOffset;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.CharacterController))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class MeshColliderZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Mesh sharedMesh;
    public System.Boolean convex;
    public UnityEngine.MeshColliderCookingOptions cookingOptions;
    public System.Boolean enabled;
    public System.Boolean isTrigger;
    public System.Single contactOffset;
    public UnityEngine.HideFlags hideFlags;
    public MeshColliderZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.MeshCollider;
        sharedMesh = instance.sharedMesh;
        convex = instance.convex;
        cookingOptions = instance.cookingOptions;
        enabled = instance.enabled;
        isTrigger = instance.isTrigger;
        contactOffset = instance.contactOffset;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.MeshCollider))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.MeshCollider)component;
        instance.sharedMesh = sharedMesh;
        instance.convex = convex;
        instance.cookingOptions = cookingOptions;
        instance.enabled = enabled;
        instance.isTrigger = isTrigger;
        instance.contactOffset = contactOffset;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.MeshCollider))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class CapsuleColliderZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Vector3 center;
    public System.Single radius;
    public System.Single height;
    public System.Int32 direction;
    public System.Boolean enabled;
    public System.Boolean isTrigger;
    public System.Single contactOffset;
    public UnityEngine.HideFlags hideFlags;
    public CapsuleColliderZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.CapsuleCollider;
        center = instance.center;
        radius = instance.radius;
        height = instance.height;
        direction = instance.direction;
        enabled = instance.enabled;
        isTrigger = instance.isTrigger;
        contactOffset = instance.contactOffset;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.CapsuleCollider))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.CapsuleCollider)component;
        instance.center = center;
        instance.radius = radius;
        instance.height = height;
        instance.direction = direction;
        instance.enabled = enabled;
        instance.isTrigger = isTrigger;
        instance.contactOffset = contactOffset;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.CapsuleCollider))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class BoxColliderZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Vector3 center;
    public UnityEngine.Vector3 size;
    public System.Boolean enabled;
    public System.Boolean isTrigger;
    public System.Single contactOffset;
    public UnityEngine.HideFlags hideFlags;
    public BoxColliderZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.BoxCollider;
        center = instance.center;
        size = instance.size;
        enabled = instance.enabled;
        isTrigger = instance.isTrigger;
        contactOffset = instance.contactOffset;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.BoxCollider))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.BoxCollider)component;
        instance.center = center;
        instance.size = size;
        instance.enabled = enabled;
        instance.isTrigger = isTrigger;
        instance.contactOffset = contactOffset;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.BoxCollider))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class SphereColliderZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Vector3 center;
    public System.Single radius;
    public System.Boolean enabled;
    public System.Boolean isTrigger;
    public System.Single contactOffset;
    public UnityEngine.HideFlags hideFlags;
    public SphereColliderZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.SphereCollider;
        center = instance.center;
        radius = instance.radius;
        enabled = instance.enabled;
        isTrigger = instance.isTrigger;
        contactOffset = instance.contactOffset;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.SphereCollider))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.SphereCollider)component;
        instance.center = center;
        instance.radius = radius;
        instance.enabled = enabled;
        instance.isTrigger = isTrigger;
        instance.contactOffset = contactOffset;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.SphereCollider))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class BoxCollider2DZSerializer : ZSerializer.Internal.ZSerializer {
    public UnityEngine.Vector2 size;
    public System.Single edgeRadius;
    public System.Boolean autoTiling;
    public System.Single density;
    public System.Boolean isTrigger;
    public System.Boolean usedByEffector;
    public System.Boolean usedByComposite;
    public UnityEngine.Vector2 offset;
    public System.Boolean enabled;
    public UnityEngine.HideFlags hideFlags;
    public BoxCollider2DZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.BoxCollider2D;
        size = instance.size;
        edgeRadius = instance.edgeRadius;
        autoTiling = instance.autoTiling;
        density = instance.density;
        isTrigger = instance.isTrigger;
        usedByEffector = instance.usedByEffector;
        usedByComposite = instance.usedByComposite;
        offset = instance.offset;
        enabled = instance.enabled;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.BoxCollider2D))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.BoxCollider2D)component;
        instance.size = size;
        instance.edgeRadius = edgeRadius;
        instance.autoTiling = autoTiling;
        instance.density = density;
        instance.isTrigger = isTrigger;
        instance.usedByEffector = usedByEffector;
        instance.usedByComposite = usedByComposite;
        instance.offset = offset;
        instance.enabled = enabled;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.BoxCollider2D))?.OnDeserialize?.Invoke(this, instance);
    }
}
[System.Serializable]
public sealed class HingeJoint2DZSerializer : ZSerializer.Internal.ZSerializer {
    public System.Boolean useMotor;
    public System.Boolean useLimits;
    public UnityEngine.JointMotor2D motor;
    public UnityEngine.JointAngleLimits2D limits;
    public UnityEngine.Vector2 anchor;
    public UnityEngine.Vector2 connectedAnchor;
    public System.Boolean autoConfigureConnectedAnchor;
    public UnityEngine.Rigidbody2D connectedBody;
    public System.Boolean enableCollision;
    public System.Single breakForce;
    public System.Single breakTorque;
    public System.Boolean enabled;
    public UnityEngine.HideFlags hideFlags;
    public Vector2 serializableLimits;
    public Vector2 serializableMotor;
    public HingeJoint2DZSerializer (string ZUID, string GOZUID) : base(ZUID, GOZUID) {
        var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID] as UnityEngine.HingeJoint2D;
        useMotor = instance.useMotor;
        useLimits = instance.useLimits;
        motor = instance.motor;
        limits = instance.limits;
        anchor = instance.anchor;
        connectedAnchor = instance.connectedAnchor;
        autoConfigureConnectedAnchor = instance.autoConfigureConnectedAnchor;
        connectedBody = instance.connectedBody;
        enableCollision = instance.enableCollision;
        breakForce = instance.breakForce;
        breakTorque = instance.breakTorque;
        enabled = instance.enabled;
        hideFlags = instance.hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.HingeJoint2D))?.OnSerialize?.Invoke(this, instance);
    }
    public override void RestoreValues(UnityEngine.Component component)
    {
        var instance = (UnityEngine.HingeJoint2D)component;
        instance.useMotor = useMotor;
        instance.useLimits = useLimits;
        instance.motor = motor;
        instance.limits = limits;
        instance.anchor = anchor;
        instance.connectedAnchor = connectedAnchor;
        instance.autoConfigureConnectedAnchor = autoConfigureConnectedAnchor;
        instance.connectedBody = connectedBody;
        instance.enableCollision = enableCollision;
        instance.breakForce = breakForce;
        instance.breakTorque = breakTorque;
        instance.enabled = enabled;
        instance.hideFlags = hideFlags;
        ZSerializerSettings.Instance.unityComponentDataList.FirstOrDefault(data => data.Type == typeof(UnityEngine.HingeJoint2D))?.OnDeserialize?.Invoke(this, instance);
    }
}
}