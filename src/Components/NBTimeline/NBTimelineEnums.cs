namespace NeoBrutalism.Blazor;

/// <summary>State of a single timeline step.</summary>
public enum NBTimelineStepState
{
    /// <summary>Step has been completed.</summary>
    Completed,
    /// <summary>Step is currently active.</summary>
    Active,
    /// <summary>Step is upcoming / not yet reached.</summary>
    Upcoming
}

/// <summary>Orientation of an <see cref="NBTimeline"/>.</summary>
public enum NBTimelineOrientation
{
    /// <summary>Vertical layout (default).</summary>
    Vertical,
    /// <summary>Horizontal layout.</summary>
    Horizontal
}
