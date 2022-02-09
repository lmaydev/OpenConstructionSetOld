﻿namespace OpenConstructionSet.Mods;

public class ModInstance : IInstance, IKeyedItem<string>
{
    private ModInstanceCollection? parent;

    /// <summary>
    /// Creates a new <see cref="ModInstance"/> from another.
    /// </summary>
    /// <param name="instance">The <see cref="IInstance"/> to copy.</param>
    public ModInstance(IInstance instance) : this(instance.Id, instance.TargetId, instance.Position, instance.Rotation, instance.States)
    {
    }

    /// <summary>
    /// Creates a new <see cref="ModInstance"/> from the provided data.
    /// </summary>
    /// <param name="id">The identifier for the <see cref="ModInstance"/>.</param>
    /// <param name="targetId">The <see cref="IItem.StringId"/> of the targeted <see cref="IItem"/>.</param>
    /// <param name="position">The <see cref="ModInstance"/>'s position.</param>
    /// <param name="rotation">The <see cref="ModInstance"/>'s rotation.</param>
    /// <param name="states">A collection of states for the <see cref="ModInstance"/>.</param>
    public ModInstance(string id, string targetId, Vector3 position, Vector4 rotation, IEnumerable<string> states)
    {
        Id = id;
        TargetId = targetId;
        Position = position;
        Rotation = rotation;
        States = new(states);
    }

    /// <summary>
    /// The <see cref="ModInstance"/>'s identifier.
    /// </summary>
    public string Id { get; }

    public string Key => Id;

    /// <summary>
    /// The <see cref="ModInstance"/>'s position.
    /// </summary>
    public Vector3 Position { get; set; }

    /// <summary>
    /// The <see cref="ModInstance"/>'s rotation.
    /// </summary>
    public Vector4 Rotation { get; set; }

    /// <summary>
    /// A collection of states for the <see cref="ModInstance"/>.
    /// </summary>
    public List<string> States { get; } = new();

    public ModItem? Target => parent?.Owner?.Items.TryGetValue(TargetId, out var target) == true ? target : null;

    /// <summary>
    /// The <see cref="Item.StringId"/> of the targeted <see cref="Item"/>.
    /// </summary>
    public string TargetId { get; set; }

    internal void SetParent(ModInstanceCollection? newParent)
    {
        parent?.Remove(this);
        parent = newParent;
    }
}
