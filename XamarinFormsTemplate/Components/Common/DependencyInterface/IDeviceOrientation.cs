using System;
namespace GoetiaGuide.Core.Common {
    /// <summary>
    /// Reference: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/dependency-service/device-orientation
    /// </summary>
    public enum DeviceOrientatione {
        Undefined,
        Landscape,
        Portrait
    }

    public interface IDeviceOrientation {
        DeviceOrientatione GetOrientation();
    }
}
