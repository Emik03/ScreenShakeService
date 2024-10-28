namespace ScreenShakeService;

/// <summary>The featherweight mod that disables the camera shake.</summary>
[CLSCompliant(false)]
public sealed class ScreenShakeServiceMod() : Mod(Assembly.GetExecutingAssembly().GetName().Name), ITogglableMod
{
    /// <inheritdoc />
    public override void Initialize()
    {
        ModHooks.SavegameLoadHook += DisableCameraShake;
        GameCameras.instance.cameraShakeFSM.enabled = false;
    }

    /// <inheritdoc />
    public void Unload()
    {
        ModHooks.SavegameLoadHook -= DisableCameraShake;
        GameCameras.instance.cameraShakeFSM.enabled = true;
    }

    /// <inheritdoc />
    public override string GetVersion() => Assembly.GetExecutingAssembly().GetName().Version.ToShortString();

    /// <summary>Disables the camera shake.</summary>
    /// <param name="_">Unused.</param>
    static void DisableCameraShake(int _) => GameCameras.instance.cameraShakeFSM.enabled = false;
}
